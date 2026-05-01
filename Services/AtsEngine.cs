using ratpdf.Models;
namespace ratpdf.Services
{
    public class AtsEngine
    {

        private readonly EmbeddingService _embedding;

        public AtsEngine(EmbeddingService embedding)
        {
            _embedding = embedding;
        }

        public AtsResult Score(string resume)
        {
            var result = new AtsResult();
            var validity = ResumeValidity(resume);

            if (validity < 0.4)
            {
                return new AtsResult
                {
                    Score = 0,
                    StructureScore = 0,
                    ContentScore = 0,
                    SemanticScore = 0,
                    FormattingScore = 0
                };
            }
            result.StructureScore = StructureScore(resume);
            result.ContentScore = ContentScore(resume);
            result.SemanticScore = SemanticScore(resume);
            result.FormattingScore = FormattingScore(resume);

            result.Score =
                result.StructureScore * 0.30 +
                result.ContentScore * 0.30 +
                result.SemanticScore * 0.25 +
                result.FormattingScore * 0.15;

            return result;
        }

        private double StructureScore(string text)
        {
            text = text.ToLower();

            string[] sections =
            {
            "experience",
            "education",
            "projects",
            "certifications",
            "languages",
            "awards",
            "skills"
            };

            return sections.Count(s => text.Contains(s)) / (double)sections.Length;
        }

        private double ContentScore(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var segments = text
                .Split(new[] { '\n', '.', '•', '-' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => s.Length > 5)
                .ToList();

            if (segments.Count == 0)
                return 0;

            var anchors = new[]
            {
                "professional experience and responsibilities",
                "achievements and measurable impact",
                "skills and competencies",
                "projects and work contributions"
            };

            double score = 0;

            foreach (var a in anchors)
            {
                var aVec = _embedding.Embed(a);

                foreach (var s in segments)
                {
                    var vec = _embedding.Embed(s);
                    var c = CosineSimilarity.Compute(vec, aVec);
                    score += (c + 1) / 2.0;
                }
            }

            return score / (segments.Count * anchors.Length);
        }

        private double SemanticScore(string resume)
        {
            if (string.IsNullOrWhiteSpace(resume))
                return 0;

            var resumeVec = _embedding.Embed(resume);

            var anchors = new[]
            {
                "work experience responsibilities achievements",
                "professional skills and competencies",
                "education certifications training",
                "projects accomplishments outcomes"
           };

            double score = 0;

            foreach (var a in anchors)
            {
                var vec = _embedding.Embed(a);
                var c = CosineSimilarity.Compute(resumeVec, vec);
                score += (c + 1) / 2.0;
            }

            return Math.Clamp(score / anchors.Length, 0, 1);
        }

        private double FormattingScore(string text)
        {
            double score = 0;

            if (text.Contains("\n")) score += 0.3;
            if (text.Contains("•") || text.Contains("-")) score += 0.3;

            if (text.Length > 500 && text.Length < 8000)
                score += 0.4;

            return Math.Clamp(score, 0, 1);
        }
        private double ResumeValidity(string text)
        {
            text = text.ToLower();

            double score = 0;

            if (text.Contains("experience")) score += 0.25;
            if (text.Contains("education")) score += 0.20;
            if (text.Contains("skills")) score += 0.20;
            if (text.Contains("projects")) score += 0.10;
            if (text.Contains("contact")) score += 0.10;

            if (text.Contains("@gmail") || text.Contains("@hotmail")|| text.Contains("@outlook")|| text.Contains("@rediffmail")) score += 0.10;
            if (text.Contains("linkedin")) score += 0.05;

            return Math.Clamp(score, 0, 1);
        }
    }
}

