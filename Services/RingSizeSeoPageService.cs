using ratpdf.Models;

namespace ratpdf.Services
{
    public static class RingSizeSeoPageService
    {
        public static List<SEOPageModel> GeneratePages()
        {
            var pages = new List<SEOPageModel>();

            var sizes = Enumerable.Range(3, 13); // Ring sizes 3–15
            var countries = new[] { "us", "uk", "eu", "canada", "australia", "india" };
            var genders = new[] { "men", "women" };
            var measurementGuides = new[] { "how-to-measure-ring-size", "measure-ring-size-at-home", "measure-ring-size-with-string" };

            // 1. Individual ring size pages
            foreach (var size in sizes)
            {
                string keyword = $"Ring Size {size}";
                pages.Add(new SEOPageModel
                {
                    Title = $"{keyword} – Diameter, Circumference & Conversion Chart",
                    Description = $"Learn about {keyword}, including mm diameter, circumference, and international ring size conversion.",
                    Slug = $"ring-size-{size}",
                    FullContentHtml = GenerateContent(keyword),
                    FAQ = GenerateFaq(keyword)
                });
            }

            // 2. Main chart page
            pages.Add(new SEOPageModel
            {
                Title = "Ring Size Chart – International Ring Size Conversion Guide",
                Description = "Use our ring size chart to convert US, UK, and EU ring sizes easily.",
                Slug = "ring-size-chart",
                FullContentHtml = GenerateContent("Ring Size Chart"),
                FAQ = GenerateFaq("Ring Size Chart")
            });

            // 3. Country-specific charts
            foreach (var country in countries)
            {
                string keyword = $"Ring Size Chart {country.ToUpper()}";
                pages.Add(new SEOPageModel
                {
                    Title = $"{keyword} – Complete Conversion Guide",
                    Description = $"View the {keyword} and convert ring sizes easily between US, UK, EU, and other international systems.",
                    Slug = $"ring-size-chart-{country}",
                    FullContentHtml = GenerateContent(keyword),
                    FAQ = GenerateFaq(keyword)
                });
            }

            // 4. Gender-specific charts
            foreach (var gender in genders)
            {
                string keyword = $"Average Ring Size {gender}";
                pages.Add(new SEOPageModel
                {
                    Title = $"{keyword} – Measurement Guide & Chart",
                    Description = $"Find the average ring size for {gender} and use our chart to measure accurately.",
                    Slug = $"average-ring-size-{gender}",
                    FullContentHtml = GenerateContent(keyword),
                    FAQ = GenerateFaq(keyword)
                });
            }

            // 5. Measurement guide pages
            foreach (var guide in measurementGuides)
            {
                string keyword = guide.Replace("-", " ");
                pages.Add(new SEOPageModel
                {
                    Title = $"{keyword} – Step by Step Guide",
                    Description = $"Learn {keyword} easily at home with our step by step guide and chart.",
                    Slug = guide,
                    FullContentHtml = GenerateContent(keyword),
                    FAQ = GenerateFaq(keyword)
                });
            }

            // 6. Ring Size Calculator / Converter landing page
            pages.Add(new SEOPageModel
            {
                Title = "Ring Size Calculator – Convert & Measure Your Ring Size",
                Description = "Use our Ring Size Calculator to quickly find your US, UK, or EU ring size and measure accurately.",
                Slug = "ring-size-calculator",
                FullContentHtml = GenerateContent("Ring Size Calculator"),
                FAQ = GenerateFaq("Ring Size Calculator")
            });

            pages.Add(new SEOPageModel
            {
                Title = "Ring Size Converter – Convert Between US, UK, EU, & More",
                Description = "Our Ring Size Converter allows you to instantly convert ring sizes between US, UK, EU, and other international systems.",
                Slug = "ring-size-converter",
                FullContentHtml = GenerateContent("Ring Size Converter"),
                FAQ = GenerateFaq("Ring Size Converter")
            });

            return pages;
        }
        static string GenerateContent(string keyword)
        {
            var sb = new System.Text.StringBuilder();

            sb.Append(SectionIntro(keyword));
            sb.Append(SectionImportance(keyword));
            sb.Append(SectionMeasurement(keyword));
            sb.Append(SectionConversionChart());
            sb.Append(SectionInternational(keyword));
            sb.Append(SectionTips(keyword));
            sb.Append(SectionMistakes(keyword));
            sb.Append(SectionToolPromotion());
            sb.Append(SectionConclusion(keyword));

            return sb.ToString();
        }
        static string SectionIntro(string keyword)
        {
            return $@"
            <h1>{keyword}</h1>

            <p>The {keyword} guide helps you determine the correct ring size before buying a ring online or in a jewelry store. 
            Finding the correct ring size is extremely important because a ring that is too tight can feel uncomfortable, 
            while a ring that is too loose may slip off your finger.</p>

            <p>Ring sizing systems differ between countries such as the United States, the United Kingdom, Europe, 
            and Japan. Because of these differences, many people rely on a reliable {keyword.ToLower()} guide 
            to convert ring measurements accurately.</p>

            <p>In this guide, you will learn how ring sizes work, how to measure your finger at home, 
            and how to convert sizes between different international systems.</p>
            ";
        }
        static string SectionImportance(string keyword)
        {
            return $@"
            <h2>Why {keyword} Is Important</h2>

            <p>Choosing the correct ring size is essential when purchasing engagement rings, wedding bands, 
            or fashion jewelry. Many people underestimate how much finger size can vary depending on temperature, 
            time of day, and finger shape.</p>

            <p>A detailed {keyword.ToLower()} helps you compare measurements and select the closest matching size. 
            Without using a reliable chart or measurement guide, it is easy to accidentally purchase the wrong size.</p>

            <p>Jewelry retailers across the world rely on standardized ring sizing systems. 
            By understanding these systems, you can confidently purchase rings from international stores.</p>
            ";
        }
        static string SectionMeasurement(string keyword)
        {
            return $@"
            <h2>How to Measure Your Ring Size</h2>

            <p>Before using a {keyword.ToLower()}, you need to measure your finger accurately. 
            Fortunately, there are several simple methods that you can use at home.</p>

            <h3>1. String Method</h3>

            <p>Wrap a thin piece of string or thread around the base of your finger. 
            Mark the point where the string overlaps and measure the length with a ruler. 
            This measurement represents the circumference of your finger.</p>

            <h3>2. Paper Strip Method</h3>

            <p>Cut a narrow strip of paper and wrap it around your finger. 
            Mark where the paper meets and measure the distance with a ruler. 
            You can then compare the measurement with a {keyword.ToLower()}.</p>

            <h3>3. Existing Ring Method</h3>

            <p>If you already have a ring that fits comfortably, measure its inside diameter 
            and compare it with a ring size conversion chart.</p>
            ";
        }
        static string SectionConversionChart()
        {
            return @"
                <h2>Ring Size Conversion Chart</h2>

                <table>
                <tr>
                <th>US Size</th>
                <th>UK Size</th>
                <th>EU Size</th>
                <th>Diameter (mm)</th>
                </tr>

                <tr><td>5</td><td>J</td><td>49</td><td>15.7</td></tr>
                <tr><td>6</td><td>L</td><td>52</td><td>16.5</td></tr>
                <tr><td>7</td><td>N</td><td>54</td><td>17.3</td></tr>
                <tr><td>8</td><td>P</td><td>57</td><td>18.1</td></tr>
                <tr><td>9</td><td>R</td><td>59</td><td>18.9</td></tr>
                <tr><td>10</td><td>T</td><td>62</td><td>19.8</td></tr>
                </table>
                ";
        }
        static string SectionInternational(string keyword)
        {
            return $@"
            <h2>International Ring Size Systems</h2>

            <p>Different countries use different methods to measure ring sizes. 
            For example, the United States and Canada use a numerical system, 
            while the United Kingdom uses letters such as J, K, and L.</p>

            <p>European ring sizes are usually based on the circumference of the finger in millimeters. 
            Because of these differences, an international {keyword.ToLower()} is extremely useful 
            when purchasing jewelry from overseas retailers.</p>
            ";
        }
        static string SectionTips(string keyword)
        {
            return $@"
                <h2>Tips for Getting the Most Accurate Ring Size</h2>

                <ul>
                <li>Measure your finger at the end of the day.</li>
                <li>Avoid measuring when your hands are cold.</li>
                <li>Measure your finger multiple times.</li>
                <li>Choose the larger size if you are between sizes.</li>
                </ul>

                <p>Following these tips will help you use a {keyword.ToLower()} more accurately 
                and avoid ordering the wrong ring size.</p>
                ";
        }
        static string SectionMistakes(string keyword)
        {
            return $@"
                <h2>Common Ring Size Mistakes</h2>

                <p>Many people accidentally choose the wrong ring size due to measurement mistakes. 
                One common mistake is measuring the finger too tightly, which results in selecting 
                a ring that feels uncomfortable.</p>

                <p>Another mistake is ignoring knuckle size. If your knuckle is significantly larger 
                than the base of your finger, you should select a size that comfortably passes over 
                the knuckle.</p>

                <p>Using a reliable {keyword.ToLower()} and measuring carefully can help prevent these issues.</p>
                ";
        }
        static string SectionToolPromotion()
        {
            return @"
            <h2>Use Our Ring Size Converter Tool</h2>

            <p>If you already know your measurement but need to convert it between 
            different international sizing systems, you can use our 
            <a href='/Tools/RingSizeConverter'>Ring Size Converter Tool</a>.</p>

            <p>This tool allows you to instantly convert ring sizes between 
            US, UK, EU, and other global standards.</p>
            ";
        }
        static string SectionConclusion(string keyword)
        {
            return $@"
            <h2>Final Thoughts</h2>

            <p>A detailed {keyword.ToLower()} makes it much easier to choose the correct ring size 
            when purchasing jewelry online. By measuring your finger accurately and understanding 
            international ring size systems, you can avoid costly resizing or returns.</p>

            <p>Always double-check your measurements and consider using a reliable ring size 
            conversion tool before placing your order.</p>
            ";
        }
        static List<(string Question, string Answer)> GenerateFaq(string keyword)
        {
            return new()
            {
                ($"How do I measure {keyword}?",
                $"You can measure {keyword} using a string, paper strip, or ruler and compare the measurement with a ring size chart."),

                ($"What does {keyword} mean?",
                $"{keyword} refers to the standardized measurement used to determine the correct ring size for your finger."),

                ($"How can I convert {keyword} to other international sizes?",
                $"You can convert {keyword} to US, UK, or EU sizes using an online ring size converter tool."),

                ($"Can I find {keyword} at home?",
                $"Yes, you can determine {keyword} at home by measuring your finger circumference and comparing it to a ring size chart.")
            };
        }
    }
}
