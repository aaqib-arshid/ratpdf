using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
namespace ratpdf.Services
{
    public class ImageBackgroundAIRemovalService
    {
        private readonly InferenceSession _session;

        public ImageBackgroundAIRemovalService()
        {
            var modelPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "AIModels",
            "u2net.onnx"
        );

            _session = new InferenceSession(modelPath);
        }

        public async Task<byte[]> RemoveBackgroundAsync(Stream imageStream)
        {
            using var image = Image.Load<Rgb24>(imageStream);

            int originalWidth = image.Width;
            int originalHeight = image.Height;
            var resized = image.Clone(x => x.Resize(320, 320));
            var input = Preprocess(resized);

            var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input.1", input)
        };

            using var results = _session.Run(inputs);
            var maskResult = results.FirstOrDefault();

            if (maskResult == null)
                throw new Exception("Model returned no outputs.");

            var mask = maskResult.AsTensor<float>();

            var output = ApplyMask(image, mask, originalWidth, originalHeight);

            using var ms = new MemoryStream();
            await output.SaveAsPngAsync(ms);

            return ms.ToArray();
        }

        private DenseTensor<float> Preprocess(Image<Rgb24> image)
        {
            //image.Mutate(x => x.Resize(320, 320));

            var tensor = new DenseTensor<float>(new[] { 1, 3, 320, 320 });

            for (int y = 0; y < 320; y++)
            {
                for (int x = 0; x < 320; x++)
                {
                    var p = image[x, y];
                    tensor[0, 0, y, x] = p.R / 255f;
                    tensor[0, 1, y, x] = p.G / 255f;
                    tensor[0, 2, y, x] = p.B / 255f;
                }
            }

            return tensor;
        }

        private Image<Rgba32> ApplyMask(Image<Rgb24> original, Tensor<float> mask, int width, int height)
        {
            var output = new Image<Rgba32>(width, height);

            float min = mask.Min();
            float max = mask.Max();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int mx = x * 320 / width;
                    int my = y * 320 / height;

                    float m = mask[0, 0, my, mx];
                    m = (m - min) / (max - min);

                    // edge refinement
                    m = Math.Clamp((m - 0.2f) * 1.5f, 0, 1);

                    var p = original[x, y];

                    output[x, y] = new Rgba32(
                        p.R, p.G, p.B,
                        (byte)(m * 255)
                    );
                }
            }

            output.Mutate(x => x.GaussianBlur(1.5f));

            return output;
        }
    }
}
