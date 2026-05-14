using Razorpay.Api;

namespace ratpdf.Services
{
    public class RazorpayService
    {
        private readonly RazorpayClient _client;
        private readonly string _keyId;
        private readonly ILogger<RazorpayService> _logger;

        public RazorpayService(IConfiguration config, ILogger<RazorpayService> logger)
        {
            _keyId = config["Razorpay:KeyId"]!;
            var keySecret = config["Razorpay:KeySecret"]!;
            _client = new RazorpayClient(_keyId, keySecret);
            _logger = logger;
        }

        public string KeyId => _keyId;

        public async Task<Razorpay.Api.Subscription> CreateSubscriptionAsync(string planId, string customerEmail, string internalUserId)
        {
            var options = new Dictionary<string, object>
        {
            { "plan_id", planId },
            { "total_count", 12 },   // number of billing cycles (can be set to 9999 for indefinite)
            { "quantity", 1 },
            { "customer_notify", 1 },
            { "notes", new Dictionary<string, object>
                {
                    { "internal_user_id", internalUserId },
                    { "email", customerEmail }
                }
            }
        };

            var subscription = await Task.Run(() => _client.Subscription.Create(options));
            return subscription;
        }

        public async Task<Razorpay.Api.Subscription> FetchSubscriptionAsync(string subscriptionId)
        {
            return await Task.Run(() => _client.Subscription.Fetch(subscriptionId));
        }

        public async Task CancelSubscriptionAsync(string subscriptionId, bool cancelAtCycleEnd = true)
        {
            var options = new Dictionary<string, object>
        {
            { "cancel_at_cycle_end", cancelAtCycleEnd ? 1 : 0 }
        };
            var subscription = await Task.Run(() => _client.Subscription.Fetch(subscriptionId));
            await Task.Run(() => subscription.Cancel(options));
            _logger.LogInformation("Razorpay subscription {SubId} cancelled", subscriptionId);
        }
    }
}
