# Regenerate compress PDF urlset chunks (compress-pdf-001.xml, …) under wwwroot/sitemaps/.
# Chunks are listed directly from /sitemap.xml — do not submit compress-pdf-index.xml to Search Console.
Set-Location $PSScriptRoot\..

dotnet run --project ratpdf.csproj -- --generate-compress-sitemap
