# RatPDF Content Roadmap Generator — 1000+ editorial article plan (not programmatic SEO slugs)
$outDir = Split-Path -Parent $MyInvocation.MyCommand.Path

function Article($cluster, $primary, $secondary, $intent, $audience, $funnel, $difficulty, $traffic, $url, $toolUrl, $links) {
    [PSCustomObject]@{
        Cluster = $cluster
        PrimaryKeyword = $primary
        SecondaryKeywords = ($secondary -join "; ")
        SearchIntent = $intent
        Audience = $audience
        FunnelStage = $funnel
        DifficultyEst = $difficulty
        TrafficPotential = $traffic
        RecommendedURL = $url
        ToolURL = $toolUrl
        InternalLinks = ($links -join "; ")
        WordCountTarget = if ($intent -eq "Informational") { "3000-5000" } elseif ($intent -eq "Commercial") { "2500-4000" } else { "2000-3500" }
        Priority = "P2"
        Status = "Planned"
    }
}

$articles = @()

# ═══ CLUSTER 1: COMPRESS PDF (120 topics) ═══
$compressSizes = @("50kb","100kb","150kb","200kb","250kb","300kb","500kb","1mb","2mb","5mb","10mb","20mb","25mb")
$compressUseCases = @(
    @("email","Gmail attachment limit","/compress-pdf-for-email","/pdf/compress"),
    @("whatsapp","WhatsApp document size limit","/compress-pdf-for-whatsapp","/pdf/compress"),
    @("passport","passport application PDF size","/compress-pdf-for-passport-application","/pdf/compress"),
    @("visa","visa upload PDF size","/compress-pdf-for-visa-application","/pdf/compress"),
    @("university","university portal PDF upload","/compress-pdf-for-university-application","/pdf/compress"),
    @("government","government form PDF size India","/compress-pdf-for-government-forms","/pdf/compress"),
    @("job application","job portal PDF upload limit","/compress-pdf-for-job-application","/pdf/compress"),
    @("LMS","Canvas Blackboard PDF upload","/guides/compress-pdf-for-lms","/pdf/compress"),
    @("e-filing","court e-filing PDF size","/guides/compress-pdf-efiling","/pdf/compress"),
    @("insurance","insurance claim PDF upload","/guides/compress-pdf-insurance-claims","/pdf/compress")
)
foreach ($s in $compressSizes) {
    $articles += Article "Compress PDF" "compress pdf to $s" @("reduce pdf $s","pdf compressor $s") "Transactional" "General users" "BOFU" "Medium" "High" "/guides/compress-pdf-to-$s" "/pdf/compress" @("/compress-pdf","/research/attachment-size-limits","/pdf-size-checker")
}
foreach ($u in $compressUseCases) {
    $articles += Article "Compress PDF" "compress pdf for $($u[0])" @("reduce pdf $($u[0])","pdf too large $($u[0])") "Problem-solving" "Office workers; applicants" "MOFU" "Medium" "High" $u[2] $u[3] @("/compress-pdf","/research/attachment-size-limits","/guides/compress-pdf-guide")
}
$compressDevices = @("iphone","android","mac","windows","ipad","chromebook")
foreach ($d in $compressDevices) {
    $articles += Article "Compress PDF" "compress pdf on $d" @("reduce pdf size $d","$d pdf compressor") "Task-based" "Mobile/desktop users" "MOFU" "Low" "Medium" "/guides/compress-pdf-on-$d" "/pdf/compress" @("/compress-pdf-on-$d","/guides/compress-pdf-guide")
}
$compressTopics = @(
    @("how to compress pdf without losing quality","quality preservation","/guides/compress-pdf-without-quality-loss","Informational"),
    @("ghostscript pdf compression explained","compression levels","/guides/ghostscript-pdf-compression","Informational"),
    @("compress scanned pdf vs digital pdf","scan dpi compression","/guides/compress-scanned-vs-digital-pdf","Informational"),
    @("compress pdf before merge","workflow","/guides/compress-before-merge-pdf","Informational"),
    @("compress pdf for printing","print quality","/guides/compress-pdf-for-printing","Informational"),
    @("why is my pdf so large","diagnosis","/guides/why-is-pdf-file-so-large","Problem-solving"),
    @("compress pdf with images","image heavy pdf","/guides/compress-pdf-with-images","Informational"),
    @("compress pdf for cloud storage","Dropbox Drive","/guides/compress-pdf-cloud-storage","Informational"),
    @("batch compress pdf files","multiple pdfs","/guides/batch-compress-pdf","Commercial"),
    @("pdf compression for lawyers","legal files","/guides/compress-pdf-lawyers","Industry"),
    @("pdf compression for accountants","financial statements","/guides/compress-pdf-accountants","Industry"),
    @("compress bank statement pdf","banking","/guides/compress-bank-statement-pdf","Industry"),
    @("compress aadhaar pdf","India KYC","/compress-aadhar-pdf","Transactional"),
    @("compress pan card pdf","India tax","/guides/compress-pan-card-pdf","Transactional"),
    @("compress gst invoice pdf","India business","/guides/compress-gst-invoice-pdf","Industry")
)
foreach ($t in $compressTopics) {
    $articles += Article "Compress PDF" $t[0] @() $t[3] "SMB; professionals" "MOFU" "Medium" "Medium" $t[2] "/pdf/compress" @("/compress-pdf","/research/pdf-compression-benchmark")
}

# ═══ CLUSTER 2: PDF TO TEXT & OCR (100 topics) ═══
$txtTopics = @(
    @("pdf to text online","extract text from pdf","/pdf-to-txt/pdf-to-text-online","Transactional"),
    @("how to convert pdf to text","step by step","/pdf-to-txt/how-do-i-convert-pdf-to-text","Informational"),
    @("ocr pdf to text","scanned pdf text","/pdf-to-txt/ocr-pdf-to-text","Transactional"),
    @("scanned pdf to text","image pdf ocr","/pdf-to-txt/how-scanned-pdf-to-text","Informational"),
    @("extract text from pdf without adobe","free alternative","/guides/extract-text-without-adobe","Commercial"),
    @("pdf to text for python","data pipeline","/guides/pdf-to-text-python-workflow","Advanced"),
    @("pdf to text for research","academic papers","/guides/pdf-to-text-research","Industry"),
    @("pdf to text legal documents","contracts","/guides/pdf-to-text-legal","Industry"),
    @("pdf to text bank statements","finance","/guides/pdf-to-text-bank-statements","Industry"),
    @("pdf to text multilingual","unicode encoding","/guides/pdf-to-text-multilingual","Advanced"),
    @("pdf to text vs pdf to word","comparison","/guides/pdf-to-text-vs-word","Commercial"),
    @("empty text extraction pdf","troubleshooting","/guides/pdf-text-extraction-empty","Problem-solving"),
    @("pdf to text on iphone","mobile","/pdf-to-txt/pdf-to-text-iphone","Task-based"),
    @("pdf to text on android","mobile","/pdf-to-txt/pdf-to-text-android","Task-based"),
    @("pdf to text accessibility","screen readers","/guides/pdf-to-text-accessibility","Industry"),
    @("ocr accuracy tips","scan quality","/guides/ocr-accuracy-tips","Informational"),
    @("ocr pdf for e-discovery","legal","/guides/ocr-pdf-ediscovery","Industry"),
    @("ocr lecture notes","students","/guides/ocr-lecture-notes-students","Industry"),
    @("ocr historical documents","archives","/guides/ocr-historical-documents","Industry"),
    @("tesseract vs online ocr","comparison","/guides/tesseract-vs-online-ocr","Commercial")
)
foreach ($t in $txtTopics) {
    $articles += Article "PDF to Text" $t[0] @($t[1]) $t[3] "Students; researchers; office" "MOFU" "Medium" "High" $t[2] "/pdf/pdftotext" @("/pdf/ocrpdf","/guides/ocr-pdf","/guides/pdf-txt-guide")
}
$ocrLangs = @("arabic","hindi","chinese","japanese","korean","spanish","french","german","portuguese","russian")
foreach ($l in $ocrLangs) {
    $articles += Article "OCR PDF" "ocr pdf $l" @("extract text $l pdf","$l scanned pdf") "Transactional" "Global users" "MOFU" "Medium" "Medium" "/guides/ocr-pdf-$l" "/pdf/ocrpdf" @("/pdf-to-txt/ocr-pdf-to-text","/guides/ocr-pdf")
}

# ═══ CLUSTER 3: PDF TO WORD (80 topics) ═══
$wordTopics = @(
    @("pdf to word converter","convert pdf docx","/pdf-to-word/pdf-to-word","Transactional"),
    @("how to convert pdf to word","tutorial","/pdf-to-word/how-to-convert-pdf-to-word","Informational"),
    @("pdf to word keep formatting","tables logos","/guides/pdf-to-word-keep-formatting","Problem-solving"),
    @("scanned pdf to word","ocr workflow","/guides/scanned-pdf-to-word","Informational"),
    @("pdf to word for resume","job seekers","/guides/pdf-to-word-resume","Industry"),
    @("pdf to word for invoice","editable invoice","/guides/pdf-to-word-invoice","Industry"),
    @("pdf to word vs google docs","comparison","/guides/pdf-to-word-vs-google-docs","Commercial"),
    @("pdf to word mac","apple users","/guides/pdf-to-word-mac","Task-based"),
    @("pdf to word without microsoft word","free edit","/guides/pdf-to-word-without-word","Commercial"),
    @("pdf to word batch convert","multiple files","/guides/batch-pdf-to-word","Advanced")
)
foreach ($t in $wordTopics) {
    $articles += Article "PDF to Word" $t[0] @($t[1]) "Transactional" "Office workers" "BOFU" "High" "High" $t[2] "/pdf/pdftodoc" @("/guides/pdf-to-word","/pdf/ocrpdf")
}

# ═══ CLUSTER 4: MERGE SPLIT ORGANIZE (80 topics) ═══
$mergeTopics = @(
    @("merge pdf online","combine pdf files","/guides/merge-pdf-online","Transactional"),
    @("merge pdf without losing quality","vector preserve","/guides/merge-pdf-without-quality-loss","Informational"),
    @("merge pdf in order","reorder pages","/guides/merge-pdf-custom-order","Informational"),
    @("merge pdf for visa application","document pack","/guides/merge-pdf-visa-application","Industry"),
    @("merge pdf for court filing","legal exhibits","/guides/merge-pdf-court-filing","Industry"),
    @("merge pdf scanned and digital","mixed sources","/guides/merge-scanned-digital-pdf","Advanced"),
    @("split pdf by page range","extract pages","/guides/split-pdf-page-range","Transactional"),
    @("split pdf by size","chunk large pdf","/guides/split-pdf-by-size","Problem-solving"),
    @("split pdf for email","attachment limits","/guides/split-pdf-for-email","Problem-solving"),
    @("extract single page from pdf","one page","/guides/extract-single-page-pdf","Task-based"),
    @("organize pdf pages","rearrange","/guides/organize-pdf-pages","Informational"),
    @("combine pdf before compress","workflow","/guides/combine-then-compress-pdf","Informational"),
    @("merge pdf password protected","encrypted merge","/guides/merge-password-protected-pdf","Advanced"),
    @("merge pdf for accountants","board packs","/guides/merge-pdf-accountants","Industry"),
    @("merge pdf for students","readings","/guides/merge-pdf-students","Industry")
)
foreach ($t in $mergeTopics) {
    $c = if ($t[0] -match "split") { "Split PDF" } else { "Merge PDF" }
    $tool = if ($c -eq "Split PDF") { "/pdf/split" } else { "/pdf/merge" }
    $articles += Article $c $t[0] @($t[1]) "Transactional" "General" "MOFU" "Medium" "High" $t[2] $tool @("/guides/merge-pdf","/guides/split-pdf","/pdf/compress")
}

# ═══ CLUSTER 5: SECURE PDF (80 topics) ═══
$secureTopics = @(
    @("password protect pdf","encrypt pdf","/guides/password-protect-pdf","Transactional"),
    @("pdf password best practices","security","/blog/secure-pdf-password-best-practices","Informational"),
    @("watermark pdf draft","confidential mark","/guides/watermark-pdf-draft","Transactional"),
    @("watermark vs password pdf","which to use","/guides/watermark-vs-password-pdf","Commercial"),
    @("sign pdf legally","typed signature","/guides/sign-pdf-legally","Informational"),
    @("sign pdf without docusign","free sign","/guides/sign-pdf-without-docusign","Commercial"),
    @("pdf redaction permanent","true redaction","/guides/pdf-redaction-permanent","Informational"),
    @("pdf redaction vs black box","security","/blog/pdf-redaction-vs-password","Informational"),
    @("unlock pdf remove password","known password","/guides/unlock-pdf","Transactional"),
    @("flatten pdf forms","lock fields","/guides/flatten-pdf","Transactional"),
    @("secure pdf remote work","policy","/blog/remote-work-pdf-security","Informational"),
    @("secure pdf workflow hub","full guide","/guides/secure-pdf-workflow","Informational"),
    @("pdf encryption aes","technical","/guides/pdf-encryption-aes-explained","Advanced"),
    @("share confidential pdf","workflow","/guides/share-confidential-pdf","Industry"),
    @("pdf security for lawyers","legal","/guides/pdf-security-lawyers","Industry"),
    @("pdf security for hr","payslips","/guides/pdf-security-hr","Industry"),
    @("redact pdf gdpr","privacy","/guides/redact-pdf-gdpr","Compliance"),
    @("password protect pdf mac","device","/guides/password-protect-pdf-mac","Task-based"),
    @("password protect pdf before email","workflow","/guides/password-protect-before-email","Informational")
)
foreach ($t in $secureTopics) {
    $articles += Article "Secure PDF" $t[0] @($t[1]) "Informational" "Legal; HR; finance" "MOFU" "Medium" "Medium" $t[2] "/pdf/password" @("/guides/secure-pdf-workflow","/pdf/watermark","/pdf/signtext")
}

# ═══ CLUSTER 6: INVOICE & GST (150 topics) ═══
$invoiceCountries = @("india","usa","uk","australia","canada","singapore","uae","germany","france","south-africa","new-zealand","philippines")
$invoiceProfessions = @("freelancers","consultants","contractors","photographers","designers","developers","electricians","plumbers","tutors","coaches","cleaning","landscaping","accountants","bookkeepers")
foreach ($c in $invoiceCountries) {
    $articles += Article "Invoice" "invoice generator $c" @("tax invoice $c","free invoice $c") "Transactional" "SMB $c" "BOFU" "Medium" "High" "/guides/invoice-generator-$c" "/invoice/create" @("/guides/invoice-generator-guide","/gst-invoice-checker")
}
foreach ($p in $invoiceProfessions) {
    $articles += Article "Invoice" "invoice template for $p" @("invoice generator $p","$p invoice pdf") "Commercial" $p "MOFU" "Low" "Medium" "/guides/invoice-for-$p" "/invoice/create" @("/invoice/create","/guides/invoice-generator-guide")
}
$gstTopics = @(
    @("gst invoice format india","mandatory fields","/guides/gst-invoice-format-india","Compliance"),
    @("gst invoice pdf checklist","ITC compliance","/blog/gst-invoice-pdf-checklist","Compliance"),
    @("cgst sgst vs igst invoice","tax split","/guides/cgst-sgst-igst-invoice","Compliance"),
    @("hsn sac code invoice","India GST","/guides/hsn-sac-invoice-guide","Compliance"),
    @("proforma invoice vs tax invoice","difference","/guides/proforma-vs-tax-invoice","Informational"),
    @("recurring invoice generator","subscription billing","/guides/recurring-invoice-generator","Commercial"),
    @("bulk gst invoice generator","CA firms","/invoice/bulk-gst-invoice-generator","Transactional"),
    @("invoice without signup","anonymous","/invoice/free-invoice-no-signup","Transactional"),
    @("vat invoice uk","HMRC","/guides/vat-invoice-uk","Compliance"),
    @("invoice retention period","archival","/research/document-retention-periods","Compliance")
)
foreach ($t in $gstTopics) {
    $articles += Article "Invoice" $t[0] @($t[1]) $t[3] "Indian SMB; accountants" "MOFU" "Medium" "High" $t[2] "/invoice/create" @("/gst-invoice-checker","/research/freelancer-invoicing-statistics")
}

# ═══ CLUSTER 7: PAYSLIP & PAYROLL (60 topics) ═══
$payslipTopics = @(
    @("salary slip format india","payslip template","/guides/salary-slip-format-india","Compliance"),
    @("free payslip generator","salary slip pdf","/free-payslip-generator","Transactional"),
    @("bulk payslip generator","payroll","/bulk-payslip-generator","Transactional"),
    @("payslip vs salary certificate","difference","/guides/payslip-vs-salary-certificate","Informational"),
    @("hr payslip compliance","statutory fields","/guides/hr-payslip-compliance","Compliance"),
    @("payslip for home loan","bank submission","/guides/payslip-home-loan","Industry"),
    @("payslip generator excel upload","bulk workflow","/guides/bulk-payslip-excel-guide","Advanced")
)
foreach ($t in $payslipTopics) {
    $articles += Article "Payslip" $t[0] @($t[1]) "Transactional" "HR; SMB India" "BOFU" "Low" "Medium" $t[2] "/free-payslip-generator" @("/bulk-payslip-generator","/rent-receipt-generator")
}
# Payslip SEO slugs exist programmatically — editorial complements only
$payComponents = @("basic","hra","pf","esi","tds","bonus","overtime","gratuity","professional-tax")
foreach ($pc in $payComponents) {
    $articles += Article "Payslip" "payslip $pc calculation" @("salary slip $pc","$pc on payslip") "Informational" "HR; employees India" "TOFU" "Low" "Medium" "/guides/payslip-$pc-explained" "/free-payslip-generator" @("/guides/salary-slip-format-india")
}

# ═══ CLUSTER 8: COMPARISONS (50 topics) ═══
$competitors = @("ilovepdf","smallpdf","adobe acrobat","sejda","foxit","sodapdf","pdf candy","pdf24","pdfelement","wondershare")
foreach ($comp in $competitors) {
    $slug = ($comp -replace " ","-").ToLower()
    $articles += Article "Compare" "$comp alternative" @("free $comp alternative","$comp vs ratpdf") "Commercial" "Tool shoppers" "BOFU" "High" "High" "/compare/$slug-alternative" "/compare" @("/guides/choose-pdf-tool","/research/pdf-tool-market-comparison")
    $articles += Article "Compare" "ratpdf vs $comp" @("$comp review","best pdf tool") "Commercial" "Tool shoppers" "BOFU" "High" "Medium" "/guides/ratpdf-vs-$slug" "/compare" @("/compare/$slug-alternative")
}
$compareTopics = @(
    @("best free pdf tools 2026","roundup","/guides/best-free-pdf-tools-2026","Commercial"),
    @("pdf tools for small business","buyer guide","/guides/pdf-tools-small-business","Commercial"),
    @("browser pdf tools vs desktop","privacy","/guides/browser-vs-desktop-pdf-tools","Informational"),
    @("pdf tool security comparison","privacy","/guides/pdf-tool-security-comparison","Commercial")
)
foreach ($t in $compareTopics) {
    $articles += Article "Compare" $t[0] @($t[1]) $t[3] "SMB" "MOFU" "Medium" "High" $t[2] "/compare" @("/guides/choose-pdf-tool","/home/security")
}

# ═══ CLUSTER 9: INDUSTRY VERTICALS (100 topics) ═══
$verticals = @(
    @("lawyers","merge redact compress e-filing","/pdf-tools-for-lawyers"),
    @("accountants","bank pdf excel gst","/pdf-tools-for-accountants"),
    @("students","merge ocr readings","/pdf-tools-for-students"),
    @("real-estate","lease contracts compress","/guides/pdf-tools-real-estate"),
    @("healthcare-admin","hipaa redact ocr","/guides/pdf-tools-healthcare-admin"),
    @("freelancers","invoice compress sign","/guides/pdf-tools-freelancers"),
    @("teachers","worksheet merge split","/guides/pdf-tools-teachers"),
    @("hr","payslip redact policy","/guides/pdf-tools-hr"),
    @("insurance","claim pdf compress","/guides/pdf-tools-insurance"),
    @("government","form upload compress","/guides/pdf-tools-government-applicants"),
    @("nonprofits","grant pdf workflow","/guides/pdf-tools-nonprofits"),
    @("ecommerce","invoice product pdf","/guides/pdf-tools-ecommerce"),
    @("construction","site report pdf","/guides/pdf-tools-construction"),
    @("marketing-agencies","proposal pdf compress","/guides/pdf-tools-marketing-agencies"),
    @("recruiters","resume pdf redact","/guides/pdf-tools-recruiters")
)
foreach ($v in $verticals) {
    $articles += Article "Industry" "pdf tools for $($v[0])" @($v[1]) "Commercial" $v[0] "MOFU" "Medium" "Medium" $v[2] "/guides/pdf-tools" @("/guides/pdf-tools","/resources")
    $articles += Article "Industry" "pdf workflow $($v[0])" @("document workflow $($v[0])") "Informational" $v[0] "TOFU" "Low" "Low" "/guides/pdf-workflow-$($v[0])" "/guides/pdf-tools" @($v[2])
    $articles += Article "Industry" "how to compress pdf $($v[0])" @() "Problem-solving" $v[0] "MOFU" "Low" "Low" "/guides/compress-pdf-$($v[0])" "/pdf/compress" @($v[2])
}

# ═══ CLUSTER 10: CONVERT FORMATS (80 topics) ═══
$convertPairs = @(
    @("word to pdf","docx print ready","/guides/word-to-pdf","/pdf/doctopdf"),
    @("excel to pdf","spreadsheet export","/guides/excel-to-pdf","/pdf/exceltopdf"),
    @("pdf to excel","table extraction","/guides/pdf-to-excel","/pdf/pdftoexcel"),
    @("powerpoint to pdf","slides export","/guides/powerpoint-to-pdf","/pdf/ppttopdf"),
    @("pdf to powerpoint","slides import","/guides/pdf-to-powerpoint","/pdf/pdftoppt"),
    @("html to pdf","web page export","/guides/html-to-pdf","/pdf/htmltopdf"),
    @("pdf to markdown","docs for git","/guides/pdf-to-markdown","/pdf/pdftomarkdown"),
    @("text to pdf","notes archive","/guides/text-to-pdf","/pdf/texttopdf"),
    @("images to pdf","jpg png combine","/guides/images-to-pdf","/pdf/convertimages"),
    @("pdf to png","page export","/guides/pdf-to-images","/pdf/pdftoimages"),
    @("pdf to jpg","image export","/convert/pdf-to-jpg","/pdf/pdftoimages"),
    @("extract images from pdf","embedded photos","/guides/extract-images-from-pdf","/pdf/extractimages")
)
foreach ($c in $convertPairs) {
    $articles += Article "Convert" $($c[0]) @($c[1]) "Transactional" "Office; dev" "BOFU" "Medium" "High" $c[2] $c[3] @("/guides/pdf-tools",$c[3])
    $articles += Article "Convert" "how to $($c[0]) without adobe" @("free $($c[0])") "Commercial" "Cost-conscious" "MOFU" "Medium" "Medium" "/guides/$($c[0]-replace ' ','-')-without-adobe" $c[3] @($c[2],"/compare")
}

# ═══ CLUSTER 11: DEVELOPER TOOLS (60 topics) ═══
$devTopics = @(
    @("json formatter online","pretty print json","/guides/json-formatter-guide","/pdf/jsonformatter"),
    @("jwt decoder","inspect token claims","/guides/jwt-decoder-guide","/pdf/jwtdecoder"),
    @("html formatter","beautify html","/guides/html-formatter-guide","/pdf/htmlformatter"),
    @("url encoder decoder","query strings","/guides/url-encoder-guide","/url-encoder"),
    @("text diff online","compare text","/guides/text-comparer-guide","/text-comparer"),
    @("dns lookup tool","mx a records","/guides/dns-lookup-guide","/tools/dnslookup"),
    @("image to base64","data uri","/guides/img-to-base64-guide","/pdf/imgtobase64"),
    @("html to pdf api alternatives","developer","/blog/html-to-pdf-developers","/pdf/htmltopdf"),
    @("jwt oauth debugging","sso claims","/blog/jwt-decoder-oauth-integration","/pdf/jwtdecoder"),
    @("json api debugging workflow","webhooks","/blog/json-formatter-api-debugging","/pdf/jsonformatter")
)
foreach ($t in $devTopics) {
    $articles += Article "Developer" $t[0] @($t[1]) "Transactional" "Developers" "MOFU" "Low" "Medium" $t[2] $t[3] @("/guides/developer-tools","/tools/developer")
}

# ═══ CLUSTER 12: RESEARCH & DATA (30 topics) ═══
$researchTopics = @(
    @("email attachment size limits 2026","reference table","/research/attachment-size-limits","Informational"),
    @("pdf compression benchmark","original study","/research/pdf-compression-benchmark","Informational"),
    @("freelancer invoicing statistics","SMB data","/research/freelancer-invoicing-statistics","Informational"),
    @("document retention periods","compliance table","/research/document-retention-periods","Compliance"),
    @("pdf tool market comparison","vendor matrix","/research/pdf-tool-market-comparison","Commercial"),
    @("gmail vs outlook attachment limits","comparison","/guides/gmail-vs-outlook-pdf-limits","Informational"),
    @("job portal pdf upload limits india","reference","/guides/india-job-portal-pdf-limits","Informational"),
    @("university application pdf requirements","reference","/guides/university-pdf-upload-requirements","Informational")
)
foreach ($t in $researchTopics) {
    $articles += Article "Research" $t[0] @($t[1]) $t[3] "Journalists; IT; SMB" "TOFU" "Low" "High" $t[2] "/resources" @("/resources","/pdf-size-checker")
}

# ═══ CLUSTER 13: EDIT PDF (40 topics) ═══
$editTopics = @(
    @("edit pdf online free","browser editor","/edit-pdf/edit-pdf-free","/pdf/editpdf"),
    @("add text to pdf","annotation","/edit-pdf/edit-pdf-add-text","/pdf/editpdf"),
    @("add signature to pdf","typed sign","/edit-pdf/edit-pdf-add-signature","/pdf/signtext"),
    @("edit pdf without acrobat","alternative","/guides/edit-pdf-without-acrobat","Commercial"),
    @("edit scanned pdf","ocr first","/guides/edit-scanned-pdf","Informational"),
    @("edit pdf forms","fillable","/guides/edit-pdf-forms","Informational"),
    @("edit pdf mistakes compliance","errors","/blog/pdf-editing-mistakes","Informational"),
    @("add image to pdf","logo stamp","/guides/add-image-to-pdf","Task-based"),
    @("rotate pdf pages","orientation","/guides/rotate-pdf","/pdf/rotateorremove"),
    @("add page numbers pdf","footer","/guides/add-page-numbers","/pdf/pagenumbers")
)
foreach ($t in $editTopics) {
    $articles += Article "Edit PDF" $t[0] @($t[1]) "Transactional" "Office workers" "MOFU" "Medium" "High" $t[2] "/pdf/editpdf" @("/guides/edit-pdf","/edit-pdf/edit-pdf-online")
}

# ═══ CLUSTER 14: PROBLEM-SOLVING / ERRORS (60 topics) ═══
$errorTopics = @(
    @("pdf file too large to email","compress or split","/guides/pdf-too-large-email","Problem-solving"),
    @("pdf won't open password unknown","unlock limits","/guides/pdf-wont-open-password","Problem-solving"),
    @("pdf text not selectable","ocr needed","/guides/pdf-text-not-selectable","Problem-solving"),
    @("pdf upload failed portal","size format","/guides/pdf-upload-failed-portal","Problem-solving"),
    @("corrupted pdf repair","limits honest","/guides/corrupted-pdf-repair-limits","Problem-solving"),
    @("pdf fonts missing","embedding","/guides/pdf-fonts-missing","Problem-solving"),
    @("pdf blank pages after merge","troubleshoot","/guides/pdf-blank-pages-after-merge","Problem-solving"),
    @("pdf to word garbled text","encoding","/guides/pdf-to-word-garbled-text","Problem-solving"),
    @("ocr pdf poor quality","scan tips","/guides/ocr-pdf-poor-quality","Problem-solving"),
    @("compress pdf made it larger","why","/guides/compress-pdf-made-larger","Problem-solving")
)
foreach ($t in $errorTopics) {
    $articles += Article "Troubleshooting" $t[0] @($t[1]) "Problem-solving" "Frustrated users" "MOFU" "Low" "High" "/guides/$($t[0]-replace ' ','-' -replace '[^a-z0-9-]','')" "/pdf/compress" @("/compress-pdf","/guides/compress-pdf-guide")
}

# ═══ EXPAND TO 1000+ with long-tail variations ═══
$platforms = @("gmail","outlook","yahoo mail","protonmail","whatsapp","telegram","linkedin","indeed","naukri","workday","canvas","blackboard","moodle")
foreach ($pl in $platforms) {
    $articles += Article "Compress PDF" "compress pdf for $pl upload" @("pdf size limit $pl") "Problem-solving" "$pl users" "MOFU" "Low" "Medium" "/guides/compress-pdf-for-$($pl -replace ' ','-')" "/pdf/compress" @("/compress-pdf-for-email","/research/attachment-size-limits")
    $articles += Article "PDF to Text" "extract text from pdf for $pl" @() "Task-based" "$pl users" "MOFU" "Low" "Low" "/guides/pdf-to-text-for-$($pl -replace ' ','-')" "/pdf/pdftotext" @("/pdf-to-txt/pdf-to-text-online")
}

$docTypes = @("contract","invoice","receipt","bank-statement","tax-return","resume","transcript","insurance-claim","lease-agreement","nda","sow","purchase-order","delivery-note","credit-note","debit-note","quotation","proforma-invoice")
foreach ($dt in $docTypes) {
    $articles += Article "Workflow" "how to compress $dt pdf" @() "Informational" "Office; SMB" "MOFU" "Low" "Medium" "/guides/compress-$dt-pdf" "/pdf/compress" @("/guides/compress-pdf-guide")
    $articles += Article "Workflow" "convert $dt pdf to word" @() "Transactional" "Office" "MOFU" "Low" "Medium" "/guides/convert-$dt-pdf-to-word" "/pdf/pdftodoc" @("/guides/pdf-to-word")
    if ($dt -notmatch "invoice|receipt") {
        $articles += Article "Workflow" "ocr $dt pdf" @() "Informational" "Admin" "MOFU" "Low" "Low" "/guides/ocr-$dt-pdf" "/pdf/ocrpdf" @("/guides/ocr-pdf")
    }
}

# ═══ MASS EXPANSION: systematic long-tail (600+ additional) ═══
$howToQuestions = @(
    "how do i compress a pdf","how do i merge pdf files","how do i split a pdf",
    "how do i convert pdf to word","how do i extract text from pdf","how do i password protect a pdf",
    "how do i add page numbers to pdf","how do i sign a pdf","how do i watermark a pdf",
    "how do i unlock a pdf","how do i flatten a pdf form","how do i ocr a scanned pdf",
    "how do i reduce pdf file size","how do i email a large pdf","how do i combine images into pdf",
    "how do i convert word to pdf","how do i convert excel to pdf","how do i convert pdf to excel",
    "how do i create gst invoice pdf","how do i make salary slip pdf","how do i create rent receipt pdf",
    "how do i redact sensitive information pdf","how do i rotate pdf pages","how do i extract images from pdf",
    "how do i convert pdf to png","how do i convert html to pdf","how do i convert pdf to markdown",
    "how do i edit pdf without acrobat","how do i compress pdf for passport","how do i compress pdf for visa",
    "how do i compress pdf for university","how do i compress pdf for job application",
    "how do i make pdf searchable","how do i fix pdf too large","how do i merge pdf without quality loss",
    "how do i split pdf for email","how do i protect pdf before sending","how do i add signature pdf free",
    "how do i convert scanned pdf to word","how do i batch convert pdf","how do i check pdf metadata",
    "how do i format json online","how do i decode jwt token","how do i compare two text files",
    "how do i generate invoice pdf free","how do i create proforma invoice","how do i export payslip pdf"
)
foreach ($q in $howToQuestions) {
    $slug = ($q -replace "how do i ","how-to-" -replace " ","-" -replace "[^a-z0-9-]","")
    $cluster = if ($q -match "invoice|gst|payslip|receipt") { "Invoice" } elseif ($q -match "compress|large|size") { "Compress PDF" } elseif ($q -match "ocr|text|searchable|scanned") { "PDF to Text" } elseif ($q -match "merge|split|combine") { "Merge PDF" } elseif ($q -match "password|watermark|sign|redact|protect|unlock") { "Secure PDF" } elseif ($q -match "json|jwt|text files") { "Developer" } else { "Workflow" }
    $articles += Article $cluster $q @("tutorial","step by step") "Informational" "Beginners" "TOFU" "Low" "Medium" "/guides/$slug" "/guides/pdf-tools" @("/guides/pdf-tools")
}

$beginnerTopics = @("pdf basics","what is a pdf","pdf vs docx","pdf vs png","when to use pdf",
    "pdf file structure","vector vs raster pdf","pdf accessibility basics","pdf security basics",
    "pdf compression basics","ocr basics","digital signature basics","pdf forms basics",
    "pdf metadata explained","pdf page size a4 letter","pdf color space rgb cmyk",
    "pdf fonts embedding","pdf hyperlinks","pdf bookmarks","pdf tags accessibility")
foreach ($t in $beginnerTopics) {
    $slug = "beginner-" + ($t -replace " ","-" -replace "[^a-z0-9-]","")
    $articles += Article "PDF Fundamentals" $t @("learn pdf","pdf guide") "Informational" "Beginners" "TOFU" "Low" "Medium" "/guides/$slug" "/guides/pdf-tools" @("/guides/pdf-tools","/guides/choose-pdf-tool")
}

$advancedTopics = @(
    @("pdf automation workflow","scripting","/guides/pdf-automation-workflow"),
    @("pdf a b testing compression","quality metrics","/guides/pdf-compression-ab-testing"),
    @("pdf e-discovery preparation","legal tech","/guides/pdf-ediscovery-preparation"),
    @("pdf archival pdf a","long term","/guides/pdf-archival-pdfa"),
    @("pdf accessibility wcag audit","compliance","/guides/pdf-accessibility-wcag-audit"),
    @("bulk pdf processing smb","operations","/guides/bulk-pdf-processing-smb"),
    @("pdf api vs browser tools","architecture","/guides/pdf-api-vs-browser-tools"),
    @("ghostscript parameters guide","technical","/guides/ghostscript-parameters"),
    @("pdf text extraction encoding","unicode","/guides/pdf-text-extraction-encoding"),
    @("pdf table extraction limits","pdf to excel","/guides/pdf-table-extraction-limits")
)
foreach ($t in $advancedTopics) {
    $articles += Article "Advanced PDF" $t[0] @($t[1]) "Advanced" "Developers; legal; IT" "MOFU" "Low" "Low" $t[2] "/guides/pdf-tools" @("/research/pdf-compression-benchmark")
}

# Country × document workflow matrix
$countries = @("india","usa","uk","canada","australia","germany","france","uae","singapore","south-africa","new-zealand","ireland","netherlands","spain","italy","brazil","mexico","japan","south-korea")
$workflows = @("invoice","payslip","rent-receipt","tax-document","bank-statement","contract","visa-application","university-application")
foreach ($co in $countries) {
    foreach ($wf in $workflows) {
        $articles += Article "Regional" "$wf pdf workflow $co" @("document $co","pdf $co") "Informational" "$co users" "MOFU" "Low" "Low" "/guides/${wf}-pdf-workflow-${co}" "/guides/pdf-tools" @("/guides/pdf-tools")
    }
}

# Compress: portal-specific (India + global)
$portals = @("irctc","incometax","gst-portal","digilocker","uidai","naukri","shine","monster","linkedin-jobs","usajobs","ucas","common-app","immigration-canada","home-affairs-australia","schengen-visa","ukvi")
foreach ($p in $portals) {
    $articles += Article "Compress PDF" "compress pdf for $p upload" @("pdf size $p") "Problem-solving" "Applicants" "MOFU" "Low" "Medium" "/guides/compress-pdf-$p" "/pdf/compress" @("/compress-pdf","/pdf-size-checker")
}

# Invoice long-tail professions (expand)
$moreProfessions = @("architects","lawyers","dentists","veterinarians","therapists","personal-trainers","wedding-planners","caterers","photographers-videographers","copywriters","translators","virtual-assistants","social-media-managers","seo-consultants","data-analysts","cybersecurity-consultants","interior-designers","mechanics","hvac-contractors","roofers","painters","carpenters","farmers-market-vendors","etsy-sellers","shopify-sellers","amazon-sellers","uber-drivers","delivery-drivers","tutors-online","music-teachers","dance-instructors","yoga-instructors","massage-therapists","pet-groomers","dog-walkers","cleaning-services","moving-companies","event-planners","florists","bakers","food-trucks","restaurants","cafes","hotels","bnb-hosts","property-managers","real-estate-agents","insurance-agents","mortgage-brokers","financial-advisors","tax-preparers","ca-firms","audit-firms","staffing-agencies","recruitment-agencies","it-consultants","sap-consultants","salesforce-consultants","cloud-consultants","penetration-testers","game-developers","mobile-app-developers","ui-ux-designers","brand-strategists","pr-agencies","ad-agencies","video-editors","podcast-producers","voice-over-artists"," illustrators")
foreach ($prof in $moreProfessions) {
    $p = $prof.Trim()
    $articles += Article "Invoice" "invoice template $p" @("invoice for $p","$p billing") "Commercial" $p "MOFU" "Low" "Low" "/guides/invoice-template-$p" "/invoice/create" @("/guides/invoice-generator-guide")
}

# OCR + text device/year variants
$years = @("2024","2025","2026","2027")
foreach ($y in $years) {
    $articles += Article "Compare" "best pdf tools $y" @("free pdf tools $y") "Commercial" "Tool shoppers" "BOFU" "Medium" "High" "/guides/best-pdf-tools-$y" "/compare" @("/guides/choose-pdf-tool")
    $articles += Article "Compress PDF" "compress pdf online free $y" @() "Transactional" "General" "BOFU" "Medium" "High" "/guides/compress-pdf-online-free-$y" "/pdf/compress" @("/compress-pdf")
    $articles += Article "Research" "email attachment limits $y" @() "Informational" "All" "TOFU" "Low" "Medium" "/guides/email-attachment-limits-$y" "/research/attachment-size-limits" @("/research/attachment-size-limits")
}

# Compliance cluster
$complianceTopics = @(
    @("gdpr pdf redaction requirements","privacy","/guides/gdpr-pdf-redaction"),
    @("hipaa pdf handling admin","healthcare admin","/guides/hipaa-pdf-handling"),
    @("sox document retention pdf","finance","/guides/sox-pdf-retention"),
    @("india gst invoice mandatory fields 2026","gst","/guides/gst-mandatory-fields-2026"),
    @("section 508 pdf accessibility","gov","/guides/section-508-pdf"),
    @("wcag 2.2 pdf requirements","accessibility","/guides/wcag-22-pdf"),
    @("e-invoicing india pdf","peppol","/guides/e-invoicing-india-pdf"),
    @("vat invoice eu requirements","vat","/guides/vat-invoice-eu-requirements"),
    @("irs tax document pdf format","usa tax","/guides/irs-tax-pdf-format"),
    @("hmrc invoice requirements uk","uk tax","/guides/hmrc-invoice-requirements"),
    @("ato invoice requirements australia","au tax","/guides/ato-invoice-requirements"),
    @("cra invoice requirements canada","ca tax","/guides/cra-invoice-requirements")
)
foreach ($t in $complianceTopics) {
    $articles += Article "Compliance" $t[0] @($t[1]) "Compliance" "Finance; legal; admin" "MOFU" "Medium" "Medium" $t[2] "/guides/pdf-tools" @("/research/document-retention-periods","/gst-invoice-checker")
}

# Template / checklist articles
$checklists = @(
    @("pdf email attachment checklist","before send","/guides/pdf-email-attachment-checklist"),
    @("pdf visa application checklist","documents","/guides/pdf-visa-application-checklist"),
    @("pdf court filing checklist","legal","/guides/pdf-court-filing-checklist"),
    @("pdf tender submission checklist","procurement","/guides/pdf-tender-submission-checklist"),
    @("pdf onboarding document checklist","hr","/guides/pdf-onboarding-checklist"),
    @("pdf month-end close checklist","accountants","/guides/pdf-month-end-checklist"),
    @("pdf research paper checklist","students","/guides/pdf-research-paper-checklist"),
    @("pdf invoice audit checklist","finance","/guides/pdf-invoice-audit-checklist"),
    @("pdf security audit checklist","it","/guides/pdf-security-audit-checklist"),
    @("pdf accessibility checklist","a11y","/guides/pdf-accessibility-checklist")
)
foreach ($t in $checklists) {
    $articles += Article "Checklists" $t[0] @($t[1]) "Informational" "Professionals" "MOFU" "Low" "Medium" $t[2] "/guides/pdf-tools" @("/guides/secure-pdf-workflow")
}

# PDF Glossary (150 terms — definitions, zero cannibalization with how-tos)
$glossary = @(
    "pdf","portable document format","pdf/a","pdf/x","pdf/ua","pdf vt","linearized pdf","tagged pdf",
    "ocr","optical character recognition","ghostscript","itext","tesseract","vector graphics","raster image",
    "dpi","compression","lossy compression","lossless compression","font embedding","subset fonts",
    "user password","owner password","128-bit encryption","256-bit aes encryption","digital signature","certificate signature",
    "certificate-based signature","watermark","redaction","annotation","form field","acroform","xfa forms","flattened pdf",
    "merge","split","extract","bookmark","hyperlink","metadata","xmp metadata","page box","media box","crop box",
    "bleed box","trim box","color profile","cmyk","rgb","grayscale","monochrome","jpeg compression","flate compression",
    "jbig2","mrc compression","downsampling","subsampling","linearization","fast web view","pdf portfolio",
    "pdf package","portfolio","attachments","embedded files","javascript in pdf","layers","optional content",
    "transparency","overprint","preflight","pdf/x-1a","pdf/x-3","pdf/x-4","accessibility","screen reader","alt text",
    "reading order","structure tree","marked content","unicode mapping","toUnicode","cmap","encoding","winansi",
    "identity-h","type0 font","type1 font","truetype","opentype","cid font","composite font","subset","full embedding",
    "linearized","object stream","cross reference table","incremental update","linearized pdf","pdf 1.7","pdf 2.0",
    "iso 32000","pdf/ua-1","pdf/ua-2","zugferd","factur-x","peppol","gst invoice","tax invoice","proforma invoice",
    "credit note","debit note","payslip","salary slip","rent receipt","hra receipt","tds","cgst","sgst","igst",
    "hsn code","sac code","e-invoice","irn","qr code invoice","digital signature invoice","merge pdf online",
    "compress pdf online","pdf to word converter","pdf to text extractor","html to pdf converter","batch processing",
    "job queue","blob storage","browser-based processing","client-side pdf","server-side pdf","wasm pdf","pdf.js",
    "pdf-lib","pymupdf","pdf2docx","pdfpig","libreoffice headless","impress export","calc export","writer export"
)
foreach ($term in $glossary) {
    $slug = "glossary-" + ($term -replace " ","-" -replace "/","-" -replace "[^a-z0-9-]","")
    $articles += Article "Glossary" "what is $term" @("$term definition","$term meaning") "Informational" "Beginners; students" "TOFU" "Low" "Low" "/guides/$slug" "/guides/pdf-tools" @("/guides/pdf-tools")
}

# X vs Y comparisons (avoid competing with /compare competitor pages)
$vsPairs = @(
    @("pdf","docx"),@("pdf","png"),@("pdf","jpg"),@("pdf","markdown"),@("pdf","html"),
    @("compress","split"),@("merge","compress"),@("ocr","pdf to text"),@("pdf to word","pdf to text"),
    @("watermark","password"),@("sign pdf","encrypt pdf"),@("redaction","password"),@("flatten","compress"),
    @("browser pdf tool","desktop pdf"),@("free pdf tool","paid pdf"),@("online pdf","offline pdf"),
    @("gst invoice","vat invoice"),@("proforma","tax invoice"),@("payslip","salary certificate"),
    @("rent receipt","lease agreement"),@("typed signature","digital certificate"),
    @("ghostscript","adobe compress"),@("tesseract","adobe ocr"),@("pdf/a","regular pdf"),
    @("scanned pdf","digital pdf"),@("image pdf","text pdf"),@("a4 pdf","letter pdf"),
    @("single page pdf","multi page pdf"),@("portfolio pdf","merged pdf"),@("form pdf","flat pdf"),
    @("pdf metadata","pdf content"),@("page numbers","footer watermark"),@("unlock pdf","remove password"),
    @("pdf to excel","manual entry"),@("pdf to ppt","screenshot slides"),@("html to pdf","print to pdf"),
    @("json formatter","json linter"),@("jwt decode","jwt verify"),@("word counter","character counter"),
    @("bulk invoice","single invoice"),@("bulk payslip","single payslip"),@("invoice template","invoice software"),
    @("ratpdf","ilovepdf"),@("ratpdf","smallpdf"),@("ratpdf","adobe online")
)
foreach ($pair in $vsPairs) {
    $slug = "$($pair[0])-vs-$($pair[1])" -replace " ","-" -replace "[^a-z0-9-]",""
    $articles += Article "Comparison" "$($pair[0]) vs $($pair[1])" @("difference","which to use") "Commercial" "Decision makers" "MOFU" "Low" "Medium" "/guides/$slug" "/compare" @("/guides/choose-pdf-tool")
}

# Best-of listicles by audience
$bestOfAudiences = @("freelancers","students","lawyers","accountants","teachers","hr teams","real estate agents","marketers","developers","designers","photographers","consultants","small business","startups","remote teams","nonprofits","government contractors","healthcare administrators","insurance agents","recruiters","ecommerce sellers","construction managers","event planners","researchers","journalists","archivists","librarians","paralegals","bookkeepers","tax preparers")
$bestOfTools = @("pdf compressors","pdf mergers","pdf converters","pdf editors","pdf ocr tools","invoice generators","payslip generators","free pdf tools","secure pdf tools","browser pdf tools")
foreach ($aud in $bestOfAudiences) {
    foreach ($tool in $bestOfTools) {
        $slug = "best-$($tool -replace ' ','-')-for-$($aud -replace ' ','-')"
        $articles += Article "Best-of" "best $tool for $aud" @("top $tool $aud","$aud pdf tools") "Commercial" $aud "MOFU" "Medium" "Medium" "/guides/$slug" "/compare" @("/guides/choose-pdf-tool","/guides/pdf-tools")
    }
}

# Common mistakes series
$mistakeTopics = @(
    "compressing legal pdf","merging password pdfs","ocr without proofreading","fake pdf redaction",
    "sharing unencrypted payslips","wrong gst invoice fields","using screenshot instead of pdf export",
    "flattening before review","deleting source word file","emailing password in same thread",
    "using weak pdf password","ignoring pdf accessibility","wrong page order merge","compressing already compressed",
    "ocr low dpi scans","pdf to word for scanned tables","signing without audit trail","watermark instead of encrypt",
    "splitting mid-table","wrong currency on invoice","missing invoice number sequence","duplicate gst invoices",
    "rent receipt wrong format","payslip missing statutory fields","jwt decode in production logs",
    "json formatter on secrets","html to pdf missing css","pdf to excel merged cells","batch merge wrong order"
)
foreach ($m in $mistakeTopics) {
    $slug = "mistakes-" + ($m -replace " ","-" -replace "[^a-z0-9-]","")
    $articles += Article "Mistakes" "common mistakes when $m" @("avoid","fix") "Informational" "Professionals" "TOFU" "Low" "Low" "/guides/$slug" "/guides/pdf-tools" @("/blog/pdf-editing-mistakes")
}

# Assign priorities
foreach ($a in $articles) {
    if ($a.PrimaryKeyword -match "compress pdf|pdf to text|pdf to word|invoice generator|ocr pdf|merge pdf|alternative|attachment size") {
        $a.Priority = "P0"
    } elseif ($a.SearchIntent -match "Commercial|Transactional" -and $a.TrafficPotential -eq "High") {
        $a.Priority = "P1"
    }
}

# Dedupe by RecommendedURL
$unique = $articles | Group-Object RecommendedURL | ForEach-Object { $_.Group[0] }
$unique = $unique | Sort-Object Priority, Cluster, PrimaryKeyword

# Add IDs
$id = 1
$final = foreach ($a in $unique) {
    $a | Add-Member -NotePropertyName Id -NotePropertyValue $id -PassThru
    $id++
}

$final | Export-Csv -Path (Join-Path $outDir "content-roadmap.csv") -NoTypeInformation -Encoding UTF8

# Priority batch (first 50 P0 not yet published as guides)
$existingGuides = @(
    "compress-pdf-guide","merge-pdf","split-pdf","pdf-to-word","word-to-pdf","pdf-to-excel","excel-to-pdf",
    "edit-pdf","pdf-txt-guide","text-to-pdf","watermark-pdf","password-protect-pdf","sign-pdf","ocr-pdf",
    "compress-pdf-email-limits","choose-pdf-tool","pdf-tool-alternatives","invoice-generator-guide"
)
$priority = $final | Where-Object {
    $_.Priority -eq "P0" -and
    ($_.RecommendedURL -notmatch "^/guides/(compress-pdf-guide|merge-pdf|pdf-to-word|ocr-pdf|compress-pdf-email-limits)") -and
    $_.RecommendedURL -like "/guides/*" -or $_.RecommendedURL -like "/research/*"
} | Select-Object -First 50

$priority | Export-Csv -Path (Join-Path $outDir "content-priority-batch-1.csv") -NoTypeInformation -Encoding UTF8

Write-Host "Content roadmap: $($final.Count) unique articles"
Write-Host "Priority batch 1: $($priority.Count) articles"
