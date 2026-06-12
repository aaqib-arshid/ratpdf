param([string]$ProjectDir = $PSScriptRoot + '\..')
$files = @('install-python.sh', 'startup.sh')
foreach ($name in $files) {
    $path = Join-Path $ProjectDir $name
    if (-not (Test-Path $path)) { continue }
    $text = [IO.File]::ReadAllText($path) -replace "`r`n", "`n" -replace "`r", "`n"
    [IO.File]::WriteAllText($path, $text, (New-Object System.Text.UTF8Encoding $false))
}
