using ratpdf.Constants;

namespace ratpdf.Models
{
    public sealed class AuthorProfilePageModel
    {
        public required SiteAuthor Author { get; init; }
        public IReadOnlyList<ContentEntry> Articles { get; init; } = [];
    }
}
