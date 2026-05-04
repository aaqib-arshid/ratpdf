using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;

namespace ratpdf.Services
{
    public class GoogleOAuthService
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public GoogleOAuthService(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public async Task<UserCredential> GetUserCredentialAsync()
        {
            var clientId = _config["GoogleOAuth:ClientId"];
            var clientSecret = _config["GoogleOAuth:ClientSecret"];

            var secrets = new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            var tokenPath = Path.Combine(_env.ContentRootPath, "tokens");

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets,
                new[]
                {
                "https://www.googleapis.com/auth/webmasters.readonly"
                },
                "user",
                CancellationToken.None,
                new FileDataStore(tokenPath, true)
            );

            return credential;
        }
    }
}
