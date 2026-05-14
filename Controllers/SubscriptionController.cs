using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;
using ratpdf.Models.Invoice.Razorpay;
using ratpdf.Services;
using ratpdf.Services.Invoice;
using System.Security.Claims;

namespace ratpdf.Controllers
{
    [Authorize]
    public class SubscriptionController : Controller
    {
        private readonly RazorpayService _razorpay;
        private readonly SubscriptionManager _subManager;
        private readonly IConfiguration _config;

        public SubscriptionController(
            RazorpayService razorpay,
            SubscriptionManager subManager,
            IConfiguration config)
        {
            _razorpay = razorpay;
            _subManager = subManager;
            _config = config;
        }

        // GET: /Subscription/Plans
        [AllowAnonymous]
        public IActionResult Plans()
        {
            return View();
        }

        // POST: /Subscription/CreateCheckout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCheckout(string planId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var name = User.FindFirstValue("FullName") ?? email;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(email))
                return Challenge();

            var validPlans = new[] { Plan.Pro_Monthly, Plan.Business_Monthly };
            if (!validPlans.Contains(planId))
                return BadRequest("Invalid plan");

            try
            {
                var subscription = await _razorpay.CreateSubscriptionAsync(planId, email, userId);
                var checkoutModel = new RazorpayCheckoutViewModel
                {
                    Key = _razorpay.KeyId,
                    SubscriptionId = subscription["id"].ToString(),
                    Name = "Rat Pdf InvoiceIQ",
                    Description = planId == Plan.Pro_Monthly ? "Pro Monthly" : "Business Monthly",
                    PrefillEmail = email,
                    PrefillContact = "", // optional
                    Notes = new Dictionary<string, string> { { "user_id", userId } }
                };

                return View("Checkout", checkoutModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Subscription creation failed: {ex.Message}");
            }
        }
        public IActionResult Success()
        {
            return View();
        }
        // POST: /Subscription/Webhook
        [HttpPost("subscription/webhook")]
        [AllowAnonymous]
        public async Task<IActionResult> Webhook()
        {
            var payload = await new StreamReader(Request.Body).ReadToEndAsync();
            var razorpaySignature = Request.Headers["X-Razorpay-Signature"].FirstOrDefault();
            var secret = _config["Razorpay:WebhookSecret"];

            if (!VerifySignature(payload, razorpaySignature, secret))
                return Unauthorized();

            dynamic eventObj = Newtonsoft.Json.JsonConvert.DeserializeObject(payload);
            string eventType = eventObj.@event;

            if (eventType == "subscription.activated" || eventType == "subscription.charged")
            {
                string subId = eventObj.payload.subscription.entity.id;
                string planId = eventObj.payload.subscription.entity.plan_id;
                string status = eventObj.payload.subscription.entity.status; 
                int? startAt = eventObj.payload.subscription.entity.current_start;
                int? endAt = eventObj.payload.subscription.entity.current_end;

                string internalUserId = eventObj.payload.subscription.entity.notes?.internal_user_id;

                if (!string.IsNullOrEmpty(internalUserId) && Guid.TryParse(internalUserId, out var uid))
                {
                    await _subManager.ActivateOrUpdateSubscriptionAsync(
                        uid, planId, subId,
                        startAt.HasValue ? DateTimeOffset.FromUnixTimeSeconds(startAt.Value).UtcDateTime : null,
                        endAt.HasValue ? DateTimeOffset.FromUnixTimeSeconds(endAt.Value).UtcDateTime : null);
                }
            }
            else if (eventType == "subscription.cancelled" || eventType == "subscription.expired")
            {
                string subId = eventObj.payload.subscription.entity.id;
                string internalUserId = eventObj.payload.subscription.entity.notes?.internal_user_id;
                if (Guid.TryParse(internalUserId, out var uid))
                {
                    if (eventType == "subscription.expired")
                        await _subManager.ExpireSubscriptionAsync(uid);
                    else
                        await _subManager.CancelSubscriptionAsync(uid);
                }
            }

            return Ok();
        }

        // POST: /Subscription/Cancel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Challenge();

            var sub = await _subManager.GetActiveSubscriptionAsync(Guid.Parse(userId));
            if (sub?.RazorpaySubscriptionId != null)
            {
                await _razorpay.CancelSubscriptionAsync(sub.RazorpaySubscriptionId, true);
                await _subManager.CancelSubscriptionAsync(sub.UserId);
            }

            return RedirectToAction("Plans");
        }

        private bool VerifySignature(string payload, string? signature, string? secret)
        {
            if (string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(secret)) return false;

            using var hmac = new System.Security.Cryptography.HMACSHA256(System.Text.Encoding.UTF8.GetBytes(secret));
            var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(payload));
            var computedSignature = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return computedSignature == signature;
        }
    }
}
