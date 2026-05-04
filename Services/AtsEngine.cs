using ratpdf.Models;

namespace ratpdf.Services
{
    public class AtsEngine
    {
        private readonly RemoteEmbeddingService _embedding;

        public AtsEngine(RemoteEmbeddingService embedding)
        {
            _embedding = embedding;
        }

        public async Task<AtsResult> ScoreAsync(string resume)
        {
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

            var result = new AtsResult
            {
                StructureScore = StructureScore(resume),
                ContentScore = await ContentScoreAsync(resume),
                SemanticScore = await SemanticScoreAsync(resume),
                FormattingScore = FormattingScore(resume)
            };

            result.Score =
                result.StructureScore * 0.30 +
                result.ContentScore * 0.30 +
                result.SemanticScore * 0.25 +
                result.FormattingScore * 0.15;

            return result;
        }

        // ---------------- STRUCTURE ----------------
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

        // ---------------- CONTENT (ASYNC FIXED) ----------------
        private async Task<double> ContentScoreAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var segments = text
                .Split(new[] { '\n', '.', '•', '-' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => s.Length > 5)
                .Distinct()
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

            var anchorTasks = anchors.Select(a => _embedding.EmbedAsync(a)).ToList();
            var anchorVectors = await Task.WhenAll(anchorTasks);

            var segmentTasks = segments.Select(s => _embedding.EmbedAsync(s)).ToList();
            var segmentVectors = await Task.WhenAll(segmentTasks);

            double score = 0;

            foreach (var aVec in anchorVectors)
            {
                foreach (var vec in segmentVectors)
                {
                    var c = CosineSimilarity.Compute(vec, aVec);
                    score += (c + 1) / 2.0;
                }
            }

            return score / (segments.Count * anchors.Length);
        }

        // ---------------- SEMANTIC (ASYNC FIXED) ----------------
        private async Task<double> SemanticScoreAsync(string resume)
        {
            if (string.IsNullOrWhiteSpace(resume))
                return 0;

            var anchors = new[]
            {
        "work experience responsibilities achievements",
        "professional skills and competencies",
        "education certifications training",
        "projects accomplishments outcomes"
    };

            // STEP 1: embed resume once
            var resumeVec = await _embedding.EmbedAsync(resume);

            // STEP 2: parallelize anchor embeddings
            var anchorTasks = anchors.Select(a => _embedding.EmbedAsync(a));
            var anchorVectors = await Task.WhenAll(anchorTasks);

            // STEP 3: compute in-memory only
            double score = 0;

            foreach (var vec in anchorVectors)
            {
                var c = CosineSimilarity.Compute(resumeVec, vec);
                score += (c + 1) / 2.0;
            }

            return Math.Clamp(score / anchors.Length, 0, 1);
        }

        // ---------------- FORMATTING ----------------
        private double FormattingScore(string text)
        {
            double score = 0;

            if (text.Contains("\n")) score += 0.3;
            if (text.Contains("•") || text.Contains("-")) score += 0.3;

            if (text.Length > 500 && text.Length < 8000)
                score += 0.4;

            return Math.Clamp(score, 0, 1);
        }

        // ---------------- VALIDITY ----------------
        private double ResumeValidity(string text)
        {
            text = text.ToLower();

            double score = 0;

            if (text.Contains("experience")) score += 0.25;
            if (text.Contains("education")) score += 0.20;
            if (text.Contains("skills")) score += 0.20;
            if (text.Contains("projects")) score += 0.10;
            if (text.Contains("contact")) score += 0.10;

            if (text.Contains("@gmail") ||
                text.Contains("@hotmail") ||
                text.Contains("@outlook") ||
                text.Contains("@rediffmail"))
                score += 0.10;

            if (text.Contains("linkedin")) score += 0.05;

            return Math.Clamp(score, 0, 1);
        }
    }
}