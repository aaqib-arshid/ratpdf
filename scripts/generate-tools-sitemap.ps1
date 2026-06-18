# Regenerate wwwroot/sitemaps/sitemaptools.xml from PdfToolSeo.AllTools and nav catalogs.
Set-Location (Split-Path $PSScriptRoot -Parent)
dotnet run --project ratpdf.csproj -- --generate-tools-sitemap
