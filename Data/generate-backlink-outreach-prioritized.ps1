# Merges backlink lists into one prioritized outreach CSV (ratpdf vs iLovePDF gap playbook)
$outDir = Split-Path -Parent $MyInvocation.MyCommand.Path

$listings = Import-Csv (Join-Path $outDir "backlink-free-listings.csv")
$highValue = Import-Csv (Join-Path $outDir "backlink-high-value-targets.csv")

# Tier / outreach metadata for directory & editorial domains (iLovePDF-confirmed link patterns)
$tierMap = @{
    "alternativeto.net" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "g2.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "capterra.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "getapp.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "softwareadvice.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "trustpilot.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "sourceforge.net" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "softonic.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "softpedia.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "filehippo.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "producthunt.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "saashub.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
    "slant.co" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Likely" }
    "stackshare.io" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Likely" }
    "crunchbase.com" = @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Yes" }
}

function Get-TierInfo {
    param($Domain, $TargetType, $ListingType)
    if ($tierMap.ContainsKey($Domain)) { return $tierMap[$Domain] }
    if ($ListingType -match "Editorial|Blog mention") { return @{ Tier = "B"; OutreachType = "Editorial pitch"; Competitor = "Yes" } }
    if ($ListingType -match "Gov resource") { return @{ Tier = "C"; OutreachType = "Resource page outreach"; Competitor = "Likely" } }
    if ($ListingType -match "Resource") { return @{ Tier = "C"; OutreachType = "Resource page outreach"; Competitor = "Likely" } }
    if ($ListingType -match "Community|Q&A") { return @{ Tier = "D"; OutreachType = "Community"; Competitor = "Varies" } }
    if ($ListingType -match "GitHub") { return @{ Tier = "D"; OutreachType = "GitHub PR"; Competitor = "Varies" } }
    if ($ListingType -match "SaaS|Software|Tool directory|Startup|Review|Directory|B2B|Company profile|Maker|Dev tool") {
        return @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Likely" }
    }
    if ($TargetType -match "Editorial|Blog") { return @{ Tier = "B"; OutreachType = "Editorial pitch"; Competitor = "Yes" } }
    if ($TargetType -match "Gov") { return @{ Tier = "C"; OutreachType = "Resource page outreach"; Competitor = "Likely" } }
    if ($Domain -match '\.edu$|\.ac\.uk$|\.edu\.') { return @{ Tier = "C"; OutreachType = "Resource page outreach"; Competitor = "Likely" } }
    if ($TargetType -match "GitHub|Community|Q&A") { return @{ Tier = "D"; OutreachType = "Community / PR"; Competitor = "Varies" } }
    if ($TargetType -match "Resource") { return @{ Tier = "C"; OutreachType = "Resource page outreach"; Competitor = "Likely" } }
    if ($ListingType) { return @{ Tier = "A"; OutreachType = "Directory submit"; Competitor = "Likely" } }
    return @{ Tier = "C"; OutreachType = "Cold outreach"; Competitor = "Unknown" }
}

function Get-DrSort {
    param($DrEst)
    if ($DrEst -match '^(\d+)') { return [int]$Matches[1] }
    if ($DrEst -match '(\d+)-') { return [int]$Matches[1] }
    return 0
}

function Get-PrioritySort {
    param($p)
    switch ($p) { "P0" { 0 } "P1" { 1 } "P2" { 2 } default { 3 } }
}

$rows = @()

foreach ($r in $listings) {
    $info = Get-TierInfo -Domain $r.Domain -TargetType "" -ListingType $r.ListingType
    $rows += [PSCustomObject]@{
        SourceId = "L-$($r.Id)"
        Category = "Free listing"
        Tier = $info.Tier
        OutreachType = $info.OutreachType
        iLovePDF_Has_Link = $info.Competitor
        Priority = $r.Priority
        Cluster = ""
        TargetType = $r.ListingType
        Domain = $r.Domain
        SiteName = $r.SiteName
        TargetUrl = $r.SubmitUrl
        Contact = $r.SubmitUrl
        DR_Est = $r.DR_Est
        Cost = $r.Cost
        RatPDF_Page = $r.RatPDF_Page
        Anchor_Text = $r.SuggestedAnchor
        Pitch = $r.Notes
        Status = $r.Status
    }
}

# Dedupe high-value by domain — keep row with highest DR + compress/OCR hub preference
$hvByDomain = @{}
foreach ($r in $highValue) {
    $key = $r.Domain.ToLower()
    if (-not $hvByDomain.ContainsKey($key)) {
        $hvByDomain[$key] = $r
        continue
    }
    $existing = $hvByDomain[$key]
    $existingDr = Get-DrSort $existing.DR_Est
    $newDr = Get-DrSort $r.DR_Est
    if ($newDr -gt $existingDr) { $hvByDomain[$key] = $r; continue }
    if ($newDr -eq $existingDr -and $r.Cluster -eq "Compress PDF") { $hvByDomain[$key] = $r }
}

foreach ($r in $hvByDomain.Values) {
    $info = Get-TierInfo -Domain $r.Domain -TargetType $r.TargetType -ListingType ""
    $rows += [PSCustomObject]@{
        SourceId = "H-$($r.Id)"
        Category = "High value"
        Tier = $info.Tier
        OutreachType = $info.OutreachType
        iLovePDF_Has_Link = $info.Competitor
        Priority = $r.Priority
        Cluster = $r.Cluster
        TargetType = $r.TargetType
        Domain = $r.Domain
        SiteName = $r.Domain
        TargetUrl = $r.TargetUrl
        Contact = $r.Contact
        DR_Est = $r.DR_Est
        Cost = $r.Cost
        RatPDF_Page = $r.RatPDF_Page
        Anchor_Text = $r.Anchor_Text
        Pitch = $r.Pitch
        Status = $r.Status
    }
}

function Get-SortScore {
    param($r)
    $score = 0
    if ($r.iLovePDF_Has_Link -eq "Yes") { $score += 10000 }
    elseif ($r.iLovePDF_Has_Link -eq "Likely") { $score += 5000 }
    if ($r.Tier -eq "A") { $score += 3000 }
    elseif ($r.Tier -eq "B") { $score += 2000 }
    elseif ($r.Tier -eq "C") { $score += 1000 }
    if ($r.OutreachType -eq "Directory submit") { $score += 500 }
    $score += (Get-DrSort $r.DR_Est)
    $score -= (Get-PrioritySort $r.Priority) * 100
    return $score
}

# Sort: iLovePDF-confirmed directories first, then DR
$sorted = $rows | Sort-Object @{
    Expression = { Get-SortScore $_ }; Descending = $true
}, Domain

# Assign SortRank + 30-day week bucket
$rank = 1
$week1End = 25
$week2End = 55
$week3End = 120
$output = foreach ($r in $sorted) {
    $week = if ($rank -le $week1End) { 1 }
            elseif ($rank -le $week2End) { 2 }
            elseif ($rank -le $week3End) { 3 }
            else { 4 }
    [PSCustomObject]@{
        SortRank = $rank++
        Week = $week
        SourceId = $r.SourceId
        Category = $r.Category
        Tier = $r.Tier
        OutreachType = $r.OutreachType
        iLovePDF_Has_Link = $r.iLovePDF_Has_Link
        Priority = $r.Priority
        Cluster = $r.Cluster
        TargetType = $r.TargetType
        Domain = $r.Domain
        SiteName = $r.SiteName
        TargetUrl = $r.TargetUrl
        Contact = $r.Contact
        DR_Est = $r.DR_Est
        Cost = $r.Cost
        RatPDF_Page = $r.RatPDF_Page
        Anchor_Text = $r.Anchor_Text
        Pitch = $r.Pitch
        Status = $r.Status
    }
}

$outPath = Join-Path $outDir "backlink-outreach-prioritized.csv"
$output | Export-Csv -Path $outPath -NoTypeInformation -Encoding UTF8

Write-Host "Wrote $($output.Count) rows to backlink-outreach-prioritized.csv"
Write-Host "  Week 1 (directory blitz): $(($output | Where-Object Week -eq 1).Count)"
Write-Host "  Week 2 (editorial + gov): $(($output | Where-Object Week -eq 2).Count)"
Write-Host "  Week 3 (edu + resource): $(($output | Where-Object Week -eq 3).Count)"
Write-Host "  Week 4 (long tail): $(($output | Where-Object Week -eq 4).Count)"
