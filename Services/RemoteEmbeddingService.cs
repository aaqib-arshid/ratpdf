namespace ratpdf.Services
{
    public class RemoteEmbeddingService
    {
        private readonly HttpClient _http;

        public RemoteEmbeddingService(HttpClient http)
        {
            _http = http;
        }

        public async Task<float[]> EmbedAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new float[384];

            var response = await _http.PostAsJsonAsync(
                "api/embed",
                text
            );

            if (!response.IsSuccessStatusCode)
                return new float[384];

            var vector = await response.Content.ReadFromJsonAsync<float[]>();

            return vector ?? new float[384];
        }
    }
}

