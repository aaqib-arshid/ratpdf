# Opens directory submission URLs and prints copy-paste field values for RatPDF listings.
# Run: .\Data\submit-backlink-listings.ps1
# Most sites require login with ethan.brooks@ratpdf.com (or your vendor email) + email verification.

$ErrorActionPreference = "Stop"
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$copy = Get-Content (Join-Path $scriptDir "backlink-submission-copy.json") -Raw | ConvertFrom-Json

function Show-CopyBlock {
    param([string]$Title, [hashtable]$Fields)
    Write-Host "`n========== $Title ==========" -ForegroundColor Cyan
    foreach ($k in $Fields.Keys) {
        Write-Host "$k`: " -NoNewline -ForegroundColor Yellow
        Write-Host $Fields[$k]
    }
}

Write-Host "RatPDF directory submission helper" -ForegroundColor Green
Write-Host "Contact: $($copy.product.contactEmail) | URL: $($copy.product.url)`n"

# Phase 1 — directory listings (login required except Launching Next)
$phase1 = @(
    @{ Name = "AlternativeTo"; Url = "https://alternativeto.net/manage/add-application/" },
    @{ Name = "G2"; Url = "https://www.g2.com/products/new" },
    @{ Name = "Capterra (Gartner network)"; Url = "https://www.capterra.com/vendors/sign-up" },
    @{ Name = "GetApp"; Url = "https://www.getapp.com/vendors/sign-up" },
    @{ Name = "Software Advice"; Url = "https://www.softwareadvice.com/vendors/" },
    @{ Name = "Product Hunt"; Url = "https://www.producthunt.com/posts/new" },
    @{ Name = "SourceForge"; Url = "https://sourceforge.net/projects/new" },
    @{ Name = "Softpedia"; Url = "https://www.softpedia.com/user/submit.shtml" },
    @{ Name = "FileHippo"; Url = "https://filehippo.com/form-submit-software/" },
    @{ Name = "Softonic Developers"; Url = "https://developers.softonic.com/" },
    @{ Name = "Trustpilot Business"; Url = "https://business.trustpilot.com/signup" },
    @{ Name = "Launching Next (no login)"; Url = "https://www.launchingnext.com/submit/" },
    @{ Name = "Startup Fame — verify badge"; Url = "https://startupfa.me/s/ratpdf" },
    @{ Name = "SaaSHub"; Url = "https://www.saashub.com/submit" },
    @{ Name = "StackShare"; Url = "https://stackshare.io/submit/tool" },
    @{ Name = "Toolify"; Url = "https://www.toolify.ai/submit-tool" },
    @{ Name = "Futurepedia"; Url = "https://www.futurepedia.io/submit-tool" },
    @{ Name = "BetaList"; Url = "https://betalist.com/submit" },
    @{ Name = "Indie Hackers"; Url = "https://www.indiehackers.com/products" },
    @{ Name = "DevHunt"; Url = "https://devhunt.org/" },
    @{ Name = "free-for.dev PR"; Url = "https://github.com/ripienaar/free-for-dev/compare" }
)

Show-CopyBlock "Standard fields (most forms)" @{
    "Product name"     = $copy.product.name
    "Website URL"      = $copy.product.url
    "Tagline"          = $copy.copy.tagline
    "Short description"= $copy.copy.shortDescription
    "Long description" = $copy.copy.longDescription
    "Category"         = $copy.product.category
    "Logo URL"         = $copy.product.logoUrl
    "Contact name"     = $copy.product.contactName
    "Contact email"    = $copy.product.contactEmail
    "Twitter"          = $copy.product.twitter
    "Pricing"          = $copy.product.pricing
    "Tags"             = $copy.copy.tags
    "Alternatives"     = $copy.copy.alternativetoAlternatives
    "Primary link URL" = $copy.landingPages.compare
}

Show-CopyBlock "Launching Next (public form — no account)" @{
    "Startup Name"     = $copy.product.name
    "Startup URL"      = $copy.product.url
    "Headline"         = $copy.copy.headline8words
    "Description"      = $copy.copy.mediumDescription
    "Tags"             = $copy.launchingNext.tags
    "Type"             = $copy.launchingNext.startupType
    "Marketing budget" = $copy.launchingNext.marketingBudget
    "Your Name"        = $copy.product.contactName
    "Your Email"       = $copy.product.contactEmail
    "Quick check 2+3"  = "5"
}

Show-CopyBlock "GitHub PR — free-for.dev (add under Storage and Media Processing, near MConverter)" @{
    "Line to add"      = $copy.freeForDevPrLine
}

Show-CopyBlock "Startup Fame verification" @{
    "Status"           = "Badge already on ratpdf.com homepage + footer (_Layout.cshtml, Index.cshtml)"
    "Action"           = "Log in at startupfa.me → open https://startupfa.me/s/ratpdf → click Verify"
}

$open = Read-Host "`nOpen Phase 1 submission URLs in browser? (y/n)"
if ($open -eq 'y') {
    foreach ($item in $phase1) {
        Write-Host "Opening $($item.Name)..." -ForegroundColor DarkGray
        Start-Process $item.Url
        Start-Sleep -Milliseconds 800
    }
}

Write-Host "`nDone. Update Status column in Data/backlink-free-listings.csv as you complete each." -ForegroundColor Green
