using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using DnsClient;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;
using ratpdf.Models;
using ratpdf.Services;
using System.Text.RegularExpressions;
namespace ratpdf.Controllers
{
    public class ToolsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly BlobContainerClient _blobContainer;
        private readonly QueueClient _queueClient;
        private readonly AtsEngine _atsEngine;
        private readonly PdfConversionService _pdf = new();
        private readonly SearchConsoleService _gsc;
        private readonly DecayCalculatorService _calculator;
        private readonly GoogleOAuthService _googleOAuth;
        private readonly RazorpayService _razorpayService;
        private readonly RatPDFDbContext _context;
        private readonly IConfiguration _configuration;
        public ToolsController(IHttpClientFactory httpClientFactory, AtsEngine atsEngine,
            SearchConsoleService gsc, DecayCalculatorService calculator,
            GoogleOAuthService googleOAuth, RazorpayService razorpayService,
            RatPDFDbContext context, IConfiguration configuration)
        {
            _blobContainer = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=ratpdfstorageaccount;AccountKey=F0sGPtubIGrYvUCOe9aCzNB1FUq0swKnh0x/egP6c3+XQcekNdQeMYJEIh6FL7Mrc2xXmSHZFqAT+ASts5qCKw==;EndpointSuffix=core.windows.net", "ratpdf");
            _queueClient = new QueueClient("DefaultEndpointsProtocol=https;AccountName=ratpdfstorageaccount;AccountKey=F0sGPtubIGrYvUCOe9aCzNB1FUq0swKnh0x/egP6c3+XQcekNdQeMYJEIh6FL7Mrc2xXmSHZFqAT+ASts5qCKw==;EndpointSuffix=core.windows.net", "ratpdfai-queue");
            _httpClient = httpClientFactory.CreateClient();
            _atsEngine = atsEngine;
            _gsc = gsc;
            _calculator = calculator;
            _googleOAuth = googleOAuth;
            _razorpayService = razorpayService;
            _context = context;
            _configuration = configuration;
        }
        public IActionResult RingSizeConverter()
        {
            #region Ring Sizes
            var ringSizes = new List<RingSize>
            {
                // US 1–2.5 (children / small)
                new RingSize { US="1",    UK="B½",  AU="B½",  EU="40", FR_RU="40", JP="2",  CH="40", CN="2",  IN="1",  DiameterMM=12.7, CircumferenceMM=39.8 },
                new RingSize { US="1.5",  UK="C½",  AU="C½",  EU="41", FR_RU="41", JP="2",  CH="41", CN="2",  IN="2",  DiameterMM=13.0, CircumferenceMM=40.8 },
                new RingSize { US="2",    UK="D½",  AU="D½",  EU="42", FR_RU="42", JP="3",  CH="42", CN="3",  IN="3",  DiameterMM=13.4, CircumferenceMM=42.0 },
                new RingSize { US="2.5",  UK="E½",  AU="E½",  EU="43", FR_RU="43", JP="4",  CH="43", CN="4",  IN="4",  DiameterMM=13.8, CircumferenceMM=43.4 },

                // US 3–16 (adults)
                new RingSize { US="3",    UK="F",   AU="F",   EU="44", FR_RU="44", JP="5",  CH="44", CN="5",  IN="5",  DiameterMM=14.1, CircumferenceMM=44.2 },
                new RingSize { US="3.5",  UK="G",   AU="G",   EU="46", FR_RU="46", JP="6",  CH="46", CN="6",  IN="6",  DiameterMM=14.5, CircumferenceMM=45.5 },
                new RingSize { US="4",    UK="H",   AU="H",   EU="47", FR_RU="47", JP="7",  CH="47", CN="7",  IN="7",  DiameterMM=14.8, CircumferenceMM=46.5 },
                new RingSize { US="4.5",  UK="I",   AU="I",   EU="48", FR_RU="48", JP="8",  CH="48", CN="8",  IN="8",  DiameterMM=15.2, CircumferenceMM=47.8 },
                new RingSize { US="5",    UK="J",   AU="J",   EU="49", FR_RU="49", JP="9",  CH="49", CN="9",  IN="9",  DiameterMM=15.6, CircumferenceMM=49.0 },
                new RingSize { US="5.5",  UK="K",   AU="K",   EU="50", FR_RU="50", JP="10", CH="50", CN="10", IN="10", DiameterMM=16.0, CircumferenceMM=50.3 },
                new RingSize { US="6",    UK="L",   AU="L",   EU="52", FR_RU="52", JP="11", CH="52", CN="11", IN="11", DiameterMM=16.5, CircumferenceMM=51.8 },
                new RingSize { US="6.5",  UK="M",   AU="M",   EU="53", FR_RU="53", JP="12", CH="53", CN="12", IN="12", DiameterMM=16.9, CircumferenceMM=53.1 },
                new RingSize { US="7",    UK="N½",  AU="N½",  EU="54", FR_RU="54", JP="13", CH="54", CN="13", IN="13", DiameterMM=17.3, CircumferenceMM=54.4 },
                new RingSize { US="7.5",  UK="O",   AU="O",   EU="56", FR_RU="56", JP="14", CH="56", CN="14", IN="14", DiameterMM=17.7, CircumferenceMM=55.6 },
                new RingSize { US="8",    UK="P½",  AU="P½",  EU="57", FR_RU="57", JP="15", CH="57", CN="15", IN="15", DiameterMM=18.1, CircumferenceMM=56.9 },
                new RingSize { US="8.5",  UK="Q",   AU="Q",   EU="58", FR_RU="58", JP="16", CH="58", CN="16", IN="16", DiameterMM=18.5, CircumferenceMM=58.1 },
                new RingSize { US="9",    UK="R½",  AU="R½",  EU="59", FR_RU="59", JP="17", CH="59", CN="17", IN="17", DiameterMM=18.9, CircumferenceMM=59.4 },
                new RingSize { US="9.5",  UK="S½",  AU="S½",  EU="61", FR_RU="61", JP="18", CH="61", CN="18", IN="18", DiameterMM=19.4, CircumferenceMM=60.9 },
                new RingSize { US="10",   UK="T½",  AU="T½",  EU="62", FR_RU="62", JP="20", CH="62", CN="20", IN="19", DiameterMM=19.8, CircumferenceMM=62.2 },
                new RingSize { US="10.5", UK="U½",  AU="U½",  EU="64", FR_RU="64", JP="21", CH="64", CN="21", IN="20", DiameterMM=20.2, CircumferenceMM=63.5 },
                new RingSize { US="11",   UK="V½",  AU="V½",  EU="65", FR_RU="65", JP="22", CH="65", CN="22", IN="21", DiameterMM=20.6, CircumferenceMM=64.8 },
                new RingSize { US="11.5", UK="W½",  AU="W½",  EU="66", FR_RU="66", JP="23", CH="66", CN="23", IN="22", DiameterMM=21.0, CircumferenceMM=66.0 },
                new RingSize { US="12",   UK="X½",  AU="X½",  EU="67", FR_RU="67", JP="24", CH="67", CN="24", IN="23", DiameterMM=21.4, CircumferenceMM=67.3 },
                new RingSize { US="12.5", UK="Y½",  AU="Y½",  EU="69", FR_RU="69", JP="25", CH="69", CN="25", IN="24", DiameterMM=21.8, CircumferenceMM=68.6 },
                new RingSize { US="13",   UK="Z½",  AU="Z½",  EU="70", FR_RU="70", JP="26", CH="70", CN="26", IN="25", DiameterMM=22.2, CircumferenceMM=69.8 },
                new RingSize { US="13.5", UK="Z1½", AU="Z1½", EU="71", FR_RU="71", JP="27", CH="71", CN="27", IN="26", DiameterMM=22.6, CircumferenceMM=71.1 },
                new RingSize { US="14",   UK="Z2½", AU="Z2½", EU="72", FR_RU="72", JP="28", CH="72", CN="28", IN="27", DiameterMM=23.0, CircumferenceMM=72.3 },
                new RingSize { US="14.5", UK="Z3½", AU="Z3½", EU="74", FR_RU="74", JP="29", CH="74", CN="29", IN="28", DiameterMM=23.4, CircumferenceMM=73.6 },
                new RingSize { US="15",   UK="Z4½", AU="Z4½", EU="75", FR_RU="75", JP="30", CH="75", CN="30", IN="29", DiameterMM=23.8, CircumferenceMM=74.8 },
                new RingSize { US="16",   UK="Z5½", AU="Z5½", EU="76", FR_RU="76", JP="31", CH="76", CN="31", IN="30", DiameterMM=24.2, CircumferenceMM=76.0 },
            };
            #endregion

            return View(ringSizes);
        }
        public ActionResult WordCounter()
        {
            return View();
        }
        [HttpGet("binary-to-decimal")] public IActionResult BinaryToDecimal() => View();
        [HttpGet("decimal-to-binary")] public IActionResult DecimalToBinary() => View();
        [HttpGet("qr-code-generator")] public IActionResult QRGenerator() => View();
        [HttpGet("password-generator")] public IActionResult PasswordGenerator() => View();
        [HttpGet("url-encoder")] public IActionResult UrlEncoder() => View();
        [HttpGet("url-decoder")] public IActionResult UrlDecoder() => View();
        [HttpGet("image-format-converter")] public IActionResult ImageFormatConverter() => View();
        [HttpGet("bulk-image-compressor")] public IActionResult BulkImageCompressor() => View();
        [HttpGet("image-resizer")] public IActionResult ImageResizer() => View();
        [HttpGet] public IActionResult ImgBackgroundRemove() => View();
        [HttpGet]
        public IActionResult IpLookup() => View();
        [HttpGet]
        public IActionResult DnsLookup() => View();
        [HttpGet] public IActionResult AtsDashboard() => throw new Exception("Service unavailable"); // View();
        [HttpGet]
        public async Task<IActionResult> WhatIsMyIP()
        {
            var ip = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            if (string.IsNullOrEmpty(ip))
                ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (ip == "::1")
                ip = "8.8.8.8"; // fallback for localhost testing

            var url = $"http://ip-api.com/json/{ip}";
            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<IpResult>(response);

            return View(result);
        }

        [HttpPost]
        public JsonResult GetWordStats(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return Json(new WordStats());
            var stats = CalculateStats(text);
            return Json(stats);
        }
        [HttpPost]
        public async Task<IActionResult> IpLookup(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                ModelState.AddModelError("", "Please enter a valid IP address.");
                return View();
            }

            var url = $"http://ip-api.com/json/{ipAddress}";
            var response = await _httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<IpResult>(response);

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> DnsLookup(string domain)
        {
            if (string.IsNullOrWhiteSpace(domain))
            {
                ModelState.AddModelError("", "Enter a valid domain.");
                return View();
            }

            var lookup = new LookupClient();

            var aRecords = await lookup.QueryAsync(domain, QueryType.A);
            var mxRecords = await lookup.QueryAsync(domain, QueryType.MX);

            ViewBag.ARecords = aRecords.Answers.ARecords().Select(x => x.Address.ToString()).ToList();
            ViewBag.MXRecords = mxRecords.Answers.MxRecords().Select(x => x.Exchange.Value).ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImgBackground(RemoveImgBgModel model)
        {
            throw new Exception("Service unavailable!");
            //if (model.File == null || model.File.Length == 0)
            //{
            //    return Json(new
            //    {
            //        success = false,
            //        message = "Please upload image"
            //    });
            //}

            //var userKey = HttpContext.Connection.RemoteIpAddress?.ToString();

            //// CHECKing ACTIVE PLAN
            //var activePlan = await _context.ImgBgUserSubscriptions
            //    .FirstOrDefaultAsync(x =>
            //        x.UserKey == userKey &&
            //        x.IsActive &&
            //        x.EndDate > DateTime.UtcNow);

            //bool unlimited = activePlan != null;

            //// FREE LIMIT LOGIC
            //if (!unlimited)
            //{
            //    var usage = await _context.ImgBgUserUsages
            //        .FirstOrDefaultAsync(x => x.UserKey == userKey);

            //    if (usage == null)
            //    {
            //        usage = new ImgBgUserUsage
            //        {
            //            UserKey = userKey ?? string.Empty,
            //            FreeDownloadsUsed = 0,
            //            LastResetDate = DateTime.UtcNow.Date
            //        };

            //        _context.ImgBgUserUsages.Add(usage);
            //    }

            //    // RESET DAILY
            //    if (usage.LastResetDate.Date != DateTime.UtcNow.Date)
            //    {
            //        usage.FreeDownloadsUsed = 0;
            //        usage.LastResetDate = DateTime.UtcNow.Date;
            //    }

            //    if (usage.FreeDownloadsUsed >= 3)
            //    {
            //        return Json(new
            //        {
            //            success = false,
            //            paymentRequired = true,
            //            message = "Daily limit exceeded"
            //        });
            //    }

            //    usage.FreeDownloadsUsed++;

            //    await _context.SaveChangesAsync();
            //}

            //// VALIDATIONS
            //var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

            //var ext = Path.GetExtension(model.File.FileName).ToLower();

            //if (!allowedExtensions.Contains(ext))
            //{
            //    return Json(new
            //    {
            //        success = false,
            //        message = "Invalid format"
            //    });
            //}

            //// PROCESSing IMAGE
            //var jobId = Guid.NewGuid().ToString();

            //var blobName = $"input/{jobId}.png";

            //var blobClient = _blobContainer.GetBlobClient(blobName);

            //await blobClient.UploadAsync(model.File.OpenReadStream());

            //var job = new
            //{
            //    JobId = jobId,
            //    InputUrl = blobName,
            //    OutputPath = $"output/{jobId}.png"
            //};

            //await _queueClient.SendMessageAsync(
            //    System.Text.Json.JsonSerializer.Serialize(job));

            //return Json(new
            //{
            //    success = true,
            //    jobId = jobId,
            //    message = "Processing started"
            //});
        }
        [HttpGet]
        public async Task<IActionResult> GetJobStatus(string jobId)
        {
            var resultBlob = _blobContainer.GetBlobClient($"output/{jobId}.png");

            if (await resultBlob.ExistsAsync())
            {
                return Json(new
                {
                    status = "completed",
                    url = resultBlob.Uri.ToString()
                });
            }

            return Json(new
            {
                status = "processing"
            });
        }



        [HttpPost]
        public async Task<IActionResult> AtsDashboard(IFormFile file)
        {
            throw new Exception("Service unavailable");
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Please upload a file.");
                return View();
            }

            var extension = Path.GetExtension(file.FileName).ToLower();

            if (extension != ".pdf")
            {
                ModelState.AddModelError("", "Only PDF files are allowed.");
                return View();
            }

            const long maxSize = 1 * 1024 * 1024;

            if (file.Length > maxSize)
            {
                ModelState.AddModelError("", "File size must be less than or equal to 1 MB.");
                return View();
            }

            var resumeText = _pdf.ExtractTextFromPdf(file);
            var result = await _atsEngine.ScoreAsync(resumeText);
            var structure = (int)(result.StructureScore * 100);
            var content = (int)(result.ContentScore * 100);
            var semantic = (int)(result.SemanticScore * 100);
            var formatting = (int)(result.FormattingScore * 100);

            var uiResult = new AtsUiResult
            {
                Structure = $"{structure}/100 - {Explain("Structure", structure)}",
                Content = $"{content}/100 - {Explain("Content", content)}",
                Semantic = $"{semantic}/100 - {Explain("Semantic", semantic)}",
                Formatting = $"{formatting}/100 - {Explain("Formatting", formatting)}",
                TotalScore =
            (int)Math.Round(
                (result.StructureScore * 30 +
                 result.ContentScore * 30 +
                 result.SemanticScore * 25 +
                 result.FormattingScore * 15)
            )
            };
            return View("AtsScoreDashboard", uiResult);
        }
        [HttpGet]
        public IActionResult LoginGoogle()
        {
            var redirectUrl = Url.Action("GoogleCallback", "Tools");

            var properties = new AuthenticationProperties
            {
                RedirectUri = redirectUrl,
                Items =
                {
                    { "prompt", "select_account" }
                }
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        [HttpGet]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
                return RedirectToAction("GSCIndex");

            var accessToken = result.Properties.GetTokenValue("access_token");

            HttpContext.Session.SetString("gsc_token", accessToken ?? "");

            return RedirectToAction("GSCIndex");
        }
        [HttpGet]
        public IActionResult GSCIndex()
        {
            ViewData["Title"] = "Free Content Decay Detector — Find Dying SEO Pages Instantly";
            ViewData["MetaDescription"] = "Paste your domain and instantly see which articles are losing Google rankings. Free, no signup required.";
            ViewData["Canonical"] = "https://ratpdf.com/Tools/GSCIndex";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Analyze(DecayRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Domain))
            {
                ModelState.AddModelError("Domain", "Domain is required");
                return View("GSCIndex", request);
            }

            var accessToken = HttpContext.Session.GetString("gsc_token");

            if (string.IsNullOrEmpty(accessToken))
            {
                ModelState.AddModelError(string.Empty, "Google Search Console not connected");
                return View("GSCIndex", request);
            }
            var cleanDomain = NormalizeGscSite(request.Domain);

            var credential = GoogleCredential
            .FromAccessToken(accessToken)
            .CreateScoped("https://www.googleapis.com/auth/webmasters.readonly");

            var articles = await _gsc.GetPagePerformanceAsync(credential, cleanDomain);
            if (articles.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid site or no permission");
                return View("GSCIndex", request);
            }

            var result = _calculator.Calculate(cleanDomain, articles);

            return View("SeoResults", result);
        }

        [HttpGet]
        public IActionResult Embed()
        {
            Response.Headers.Add("X-Frame-Options", "ALLOWALL");
            return View();
        }
        #region Img BG RazorPay
        //[HttpPost]
        //public IActionResult CreateImgBgOrder(string plan)
        //{
        //    decimal amount = 0;

        //    if (plan == "daily")
        //        amount = 29;

        //    if (plan == "monthly")
        //        amount = 199;

        //    var order = _razorpayService.CreateImgBgOrder(amount);

        //    return Json(new
        //    {
        //        success = true,
        //        orderId = order["id"].ToString(),
        //        amount = amount,
        //        key = _configuration["Razorpay:KeyId"]
        //    });
        //}
        //[HttpPost]
        //public async Task<IActionResult> VerifyImgBgPayment(
        //string razorpay_payment_id,
        //string razorpay_order_id,
        //string razorpay_signature,
        //string plan)
        //{
        //    try
        //    {
        //        Dictionary<string, string> attributes = new();

        //        attributes.Add(
        //            "razorpay_payment_id",
        //            razorpay_payment_id);

        //        attributes.Add(
        //            "razorpay_order_id",
        //            razorpay_order_id);

        //        attributes.Add(
        //            "razorpay_signature",
        //            razorpay_signature);

        //        Razorpay.Api.Utils.verifyPaymentSignature(attributes);

        //        var userKey =
        //            HttpContext.Connection.RemoteIpAddress?.ToString();

        //        int days = plan == "monthly" ? 30 : 1;

        //        decimal amount = plan == "monthly"
        //            ? 199
        //            : 29;

        //        var subscription = new ImgBgUserSubscription
        //        {
        //            UserKey = userKey ?? string.Empty,
        //            PlanName = plan,
        //            Amount = amount,
        //            StartDate = DateTime.UtcNow,
        //            EndDate = DateTime.UtcNow.AddDays(days),
        //            IsActive = true
        //        };

        //        //_context.ImgBgUserSubscriptions.Add(subscription);

        //        await _context.SaveChangesAsync();

        //        return Json(new
        //        {
        //            success = true
        //        });
        //    }
        //    catch
        //    {
        //        return Json(new
        //        {
        //            success = false
        //        });
        //    }
        //}
        #endregion
        #region private methods
        private string NormalizeGscSite(string domain)
        {
            return domain.Trim()
            .Replace("https://", "")
            .Replace("http://", "")
            .TrimEnd('/')
            .ToLower();
        }
        private WordStats CalculateStats(string text)
        {
            var wordArray = Regex.Matches(text, @"\b[a-zA-Z]+(?:-[a-zA-Z]+)*\b")
                     .Cast<Match>()
                     .Select(m => m.Value.ToLower())
                     .ToArray();

            var sentenceCount = Regex.Split(text.Trim(), @"(?<=[.!?])\s*")
                                     .Where(s => !string.IsNullOrWhiteSpace(s))
                                     .Count();

            var normalized = text.Replace("\r\n", "\n").Replace("\r", "\n");
            int paragraphCount;
            if (normalized.Contains("\n\n"))
                paragraphCount = Regex.Split(normalized.Trim(), @"\n{2,}")
                                      .Where(p => !string.IsNullOrWhiteSpace(p))
                                      .Count();
            else
                paragraphCount = normalized.Split('\n')
                                           .Where(p => !string.IsNullOrWhiteSpace(p))
                                           .Count();

            int charCount = text.Count(c => c != '\r' && c != '\n');
            var charCountNoSpaces = Regex.Replace(text, @"\s+", "").Length;

            double readingTimeSec = wordArray.Length / 265.0 * 60;
            double speakingTimeSec = wordArray.Length / 180.0 * 60;

            var stopWords = new HashSet<string>
            {
                "the","a","an","and","or","but","in","on","at","to","for",
                "of","with","by","from","is","it","its","as","be","was",
                "are","were","been","has","have","had","not","this","that",
                "these","those","i","you","he","she","we","they","my","your",
                "his","her","our","their","do","did","will","would","can",
                "could","should","may","might","so","if","than","then","into",
                "about","up","out","no","what","all","more","also","any","just"
            };

            var topKeywords = wordArray
                .Where(w => !stopWords.Contains(w) && w.Length > 1)
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .ToDictionary(g => g.Key, g => g.Count());

            double fkGrade = 0;
            if (wordArray.Length > 0 && sentenceCount > 0)
            {
                var syllables = wordArray.Sum(w => CountSyllables(w));
                fkGrade = 0.39 * (wordArray.Length / (double)sentenceCount)
                          + 11.8 * (syllables / (double)wordArray.Length) - 15.59;
            }

            return new WordStats
            {
                WordCount = wordArray.Length,
                CharacterCount = charCount,
                CharacterCountNoSpaces = charCountNoSpaces,
                SentenceCount = sentenceCount,
                ParagraphCount = paragraphCount,
                ReadingTimeSeconds = (int)Math.Round(readingTimeSec),
                SpeakingTimeSeconds = (int)Math.Round(speakingTimeSec),
                TopKeywords = topKeywords,
                FleschKincaidGrade = Math.Round(fkGrade, 2),
                ReadingLevel = GetReadingLevel(fkGrade)
            };
        }

        private string GetReadingLevel(double grade)
        {
            if (grade <= 6) return "Elementary";
            if (grade <= 8) return "Middle School";
            if (grade <= 9) return "High School";
            if (grade <= 12) return "College Graduate";
            if (grade <= 16) return "Post Graduate";
            return "Professional";
        }

        private int CountSyllables(string word)
        {
            word = word.ToLower();

            var vowels = "aeiouy";
            int count = 0;
            bool lastWasVowel = false;

            foreach (var c in word)
            {
                bool isVowel = vowels.Contains(c);
                if (isVowel && !lastWasVowel) count++;
                lastWasVowel = isVowel;
            }

            bool endsInConsonantLE = word.Length >= 3
                                     && word.EndsWith("le")
                                     && !vowels.Contains(word[word.Length - 3]);

            if (word.EndsWith("e") && !endsInConsonantLE)
                count--;

            return Math.Max(count, 1);
        }
        public static string Explain(string metric, int score)
        {
            return metric switch
            {
                "Structure" when score < 60 =>
                    "Your resume is missing key sections.",

                "Content" when score < 60 =>
                    "Your resume lacks strong achievement-based statements.",

                "Semantic" when score < 60 =>
                    "Your content is not strongly aligned with professional language.",

                "Formatting" when score < 60 =>
                    "Improve spacing, bullet points, and readability.",

                _ =>
                    "Well optimized for ATS systems."
            };
        }
        #endregion
    }
}
