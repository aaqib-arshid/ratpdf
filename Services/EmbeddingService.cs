using Microsoft.Extensions.Caching.Memory;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Tokenizers.HuggingFace.Tokenizer;

namespace ratpdf.Services
{
    public class EmbeddingService
    {
        private readonly InferenceSession _session;
        private readonly Tokenizer _tokenizer;
        private readonly IMemoryCache _cache;

        private const int MaxLength = 128;
        private const int EmbeddingSize = 384; 

        public EmbeddingService(IMemoryCache cache, IWebHostEnvironment env)
        {
            var path = Path.Combine(
            env.ContentRootPath,
            "wwwroot",
            "AIModels",
            "onnx-minilm"
        );

            _session = new InferenceSession(Path.Combine(path, "model.onnx"));
            _tokenizer = Tokenizer.FromFile(Path.Combine(path, "tokenizer.json"));
            _cache = cache;
        }

        public float[] Embed(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new float[EmbeddingSize];

            var key = text.Trim().ToLowerInvariant();

            if (_cache.TryGetValue(key, out float[] cached))
                return cached;

            try
            {
                text = text.Length > 2000 ? text[..2000] : text;

                var encodings = _tokenizer.Encode(text, addSpecialTokens: true);

                if (encodings == null || !encodings.Any())
                    return new float[EmbeddingSize];

                var encoding = encodings.First();

                if (encoding.Ids == null || encoding.Ids.Count == 0)
                    return new float[EmbeddingSize];

                if (encoding.AttentionMask == null || encoding.AttentionMask.Count == 0)
                    return new float[EmbeddingSize];

                var inputIdsList = encoding.Ids.Select(x => (long)x).ToList();
                var maskList = encoding.AttentionMask.Select(x => (long)x).ToList();

                if (inputIdsList.Count > MaxLength)
                {
                    inputIdsList = inputIdsList.Take(MaxLength).ToList();
                    maskList = maskList.Take(MaxLength).ToList();
                }
                else
                {
                    while (inputIdsList.Count < MaxLength)
                    {
                        inputIdsList.Add(0);
                        maskList.Add(0);
                    }
                }

                var inputIds = inputIdsList.ToArray();
                var attentionMask = maskList.ToArray();
                var tokenTypeIds = new long[MaxLength];

                var inputs = new List<NamedOnnxValue>
                {
                    NamedOnnxValue.CreateFromTensor(
                        "input_ids",
                        new DenseTensor<long>(inputIds, new[] { 1, MaxLength })
                    ),

                    NamedOnnxValue.CreateFromTensor(
                        "attention_mask",
                        new DenseTensor<long>(attentionMask, new[] { 1, MaxLength })
                    ),

                    NamedOnnxValue.CreateFromTensor(
                        "token_type_ids",
                        new DenseTensor<long>(tokenTypeIds, new[] { 1, MaxLength })
                    )
                };

                using var results = _session.Run(inputs);

                var output = results.FirstOrDefault()?.AsTensor<float>();

                if (output == null)
                    return new float[EmbeddingSize];

                var embedding = CLS_Pool(output);

                _cache.Set(key, embedding);

                return embedding;
            }
            catch
            {
                return new float[EmbeddingSize];
            }
        }

        private float[] CLS_Pool(Tensor<float> tokenEmbeddings)
        {
            try
            {
                int dim = tokenEmbeddings.Dimensions[2];

                float[] result = new float[dim];

                for (int i = 0; i < dim; i++)
                    result[i] = tokenEmbeddings[0, 0, i];

                return result;
            }
            catch
            {
                return new float[EmbeddingSize];
            }
        }
    }
}