namespace ratpdf.Models
{
    public class WordStats
    {
        public int WordCount { get; set; }
        public int CharacterCount { get; set; }
        public int CharacterCountNoSpaces { get; set; }
        public int SentenceCount { get; set; }
        public int ParagraphCount { get; set; }
        public int ReadingTimeSeconds { get; set; }   
        public int SpeakingTimeSeconds { get; set; }
        public double FleschKincaidGrade { get; set; }
        public Dictionary<string, int> TopKeywords { get; set; } = new();
        public string ReadingLevel { get; set; } = string.Empty;
    }
}
