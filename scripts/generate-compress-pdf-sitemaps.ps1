# Regenerate compress PDF sitemaps + robots.txt after updating compress-pdf-keywords.txt
# Output: wwwroot/robots.txt, wwwroot/sitemaps/compress-pdf-index.xml, compress-pdf-001.xml, ...
Set-Location $PSScriptRoot\..

dotnet run --project ratpdf.csproj -- --generate-compress-sitemap
