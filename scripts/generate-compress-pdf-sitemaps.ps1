# Regenerate compress PDF sitemaps (index + urlset chunks) after updating compress-pdf-keywords.txt
# Output: wwwroot/sitemaps/compress-pdf-index.xml, compress-pdf-001.xml, ...
Set-Location $PSScriptRoot\..

dotnet run --project ratpdf.csproj -- --generate-compress-sitemap
