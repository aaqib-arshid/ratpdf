# Generates backlink opportunity CSVs for RatPDF outreach
$outDir = Split-Path -Parent $MyInvocation.MyCommand.Path

$ratpdfPages = @{
    CompressHub      = "https://ratpdf.com/compress-pdf"
    CompressTool     = "https://ratpdf.com/pdf/compress"
    Compress100kb    = "https://ratpdf.com/compress-pdf-to-100kb"
    CompressEmail    = "https://ratpdf.com/compress-pdf-for-email"
    SizeChecker      = "https://ratpdf.com/pdf-size-checker"
    AttachmentLimits = "https://ratpdf.com/research/attachment-size-limits"
    CompressBench    = "https://ratpdf.com/research/pdf-compression-benchmark"
    PdfToTextHub     = "https://ratpdf.com/pdf-to-txt/pdf-to-text-online"
    PdfToTextHowTo   = "https://ratpdf.com/pdf-to-txt/how-do-i-convert-pdf-to-text"
    PdfToTextTool    = "https://ratpdf.com/pdf/pdftotext"
    ExtractText      = "https://ratpdf.com/pdf-to-txt/extract-text-from-pdf"
    OcrPillar        = "https://ratpdf.com/pdf-to-txt/ocr-pdf-to-text"
    OcrTool          = "https://ratpdf.com/pdf/ocrpdf"
    OcrGuide         = "https://ratpdf.com/guides/ocr-pdf"
    ScannedPdf       = "https://ratpdf.com/pdf-to-txt/how-scanned-pdf-to-text"
    PdfToolsHub      = "https://ratpdf.com/guides/pdf-tools"
    Compare          = "https://ratpdf.com/compare"
    Resources        = "https://ratpdf.com/resources"
}

# --- FREE LISTING DOMAINS (SaaS / tool directories) ---
$freeListings = @(
    @{Domain="alternativeto.net"; Name="AlternativeTo"; Type="SaaS listing"; SubmitUrl="https://alternativeto.net/manage/add-application/"; DR="91"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF - free PDF tools"; Notes="List as iLovePDF/Smallpdf alternative. Tag: PDF, compress, OCR."},
    @{Domain="producthunt.com"; Name="Product Hunt"; Type="SaaS listing"; SubmitUrl="https://www.producthunt.com/posts/new"; DR="90"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Launch day drives traffic + DR90 link. Prepare gallery + maker comment."},
    @{Domain="saashub.com"; Name="SaaSHub"; Type="SaaS listing"; SubmitUrl="https://www.saashub.com/submit"; DR="72"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Compare vs Adobe/iLovePDF."},
    @{Domain="slant.co"; Name="Slant"; Type="SaaS listing"; SubmitUrl="https://www.slant.co/topics"; DR="74"; Cost="Free"; PrimaryPage="CompressTool"; Anchor="RatPDF"; Notes="Add to 'best PDF compressors' and 'PDF to text' topics."},
    @{Domain="stackshare.io"; Name="StackShare"; Type="SaaS listing"; SubmitUrl="https://stackshare.io/submit/tool"; DR="80"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Tag under Document Management / Productivity."},
    @{Domain="toolify.ai"; Name="Toolify"; Type="AI/tool directory"; SubmitUrl="https://www.toolify.ai/submit-tool"; DR="65"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF PDF tools"; Notes="Free tier listing available."},
    @{Domain="futurepedia.io"; Name="Futurepedia"; Type="Tool directory"; SubmitUrl="https://www.futurepedia.io/submit-tool"; DR="68"; Cost="Free"; PrimaryPage="OcrTool"; Anchor="RatPDF OCR PDF"; Notes="Emphasize OCR + PDF to text workflow."},
    @{Domain="betalist.com"; Name="BetaList"; Type="Startup listing"; SubmitUrl="https://betalist.com/submit"; DR="72"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Free queue; paid for faster."},
    @{Domain="startupstash.com"; Name="Startup Stash"; Type="Startup directory"; SubmitUrl="https://startupstash.com/add-startup/"; DR="70"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Productivity / SaaS category."},
    @{Domain="libhunt.com"; Name="LibHunt"; Type="Open-source adjacent"; SubmitUrl="https://www.libhunt.com/submit"; DR="55"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="If you open-source any component later."},
    @{Domain="sourceforge.net"; Name="SourceForge"; Type="Software directory"; SubmitUrl="https://sourceforge.net/projects/new"; DR="92"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Long-tail download traffic."},
    @{Domain="softpedia.com"; Name="Softpedia"; Type="Software directory"; SubmitUrl="https://www.softpedia.com/user/submit.shtml"; DR="91"; Cost="Free"; PrimaryPage="CompressTool"; Anchor="RatPDF"; Notes="Editorial review; quality listing."},
    @{Domain="filehippo.com"; Name="FileHippo"; Type="Software directory"; SubmitUrl="https://filehippo.com/form-submit-software/"; DR="85"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Web app listing path."},
    @{Domain="softonic.com"; Name="Softonic"; Type="Software directory"; SubmitUrl="https://developers.softonic.com/"; DR="93"; Cost="Free"; PrimaryPage="CompressTool"; Anchor="RatPDF"; Notes="Developer portal submission."},
    @{Domain="g2.com"; Name="G2"; Type="SaaS listing"; SubmitUrl="https://www.g2.com/products/new"; DR="91"; Cost="Free profile"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Free vendor profile; reviews boost visibility."},
    @{Domain="capterra.com"; Name="Capterra"; Type="SaaS listing"; SubmitUrl="https://www.capterra.com/vendors/sign-up"; DR="93"; Cost="Free profile"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Gartner Digital Markets network."},
    @{Domain="getapp.com"; Name="GetApp"; Type="SaaS listing"; SubmitUrl="https://www.getapp.com/vendors/sign-up"; DR="88"; Cost="Free profile"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Same vendor network as Capterra."},
    @{Domain="softwareadvice.com"; Name="Software Advice"; Type="SaaS listing"; SubmitUrl="https://www.softwareadvice.com/vendors/"; DR="86"; Cost="Free profile"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="PDF software category."},
    @{Domain="trustpilot.com"; Name="Trustpilot"; Type="Review platform"; SubmitUrl="https://business.trustpilot.com/signup"; DR="93"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Trust signal; not pure SEO but brand."},
    @{Domain="crozdesk.com"; Name="Crozdesk"; Type="SaaS directory"; SubmitUrl="https://crozdesk.com/vendors/register"; DR="62"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="B2B SaaS comparison."},
    @{Domain="saasworthy.com"; Name="SaaSworthy"; Type="SaaS directory"; SubmitUrl="https://www.saasworthy.com/submit-product"; DR="58"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Productivity category."},
    @{Domain="killerstartups.com"; Name="KillerStartups"; Type="Startup directory"; SubmitUrl="https://killerstartups.com/submit-startup/"; DR="55"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Startup showcase."},
    @{Domain="launchingnext.com"; Name="Launching Next"; Type="Startup directory"; SubmitUrl="https://www.launchingnext.com/submit/"; DR="52"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Free startup listing."},
    @{Domain="startupranking.com"; Name="Startup Ranking"; Type="Startup directory"; SubmitUrl="https://www.startupranking.com/startup/create"; DR="60"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Global startup index."},
    @{Domain="sideprojectors.com"; Name="SideProjectors"; Type="Side project listing"; SubmitUrl="https://www.sideprojectors.com/submit"; DR="45"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Indie maker audience."},
    @{Domain="indiehackers.com"; Name="Indie Hackers"; Type="Community listing"; SubmitUrl="https://www.indiehackers.com/products"; DR="80"; Cost="Free"; PrimaryPage="Resources"; Anchor="RatPDF"; Notes="Share /resources research posts in forum."},
    @{Domain="peerlist.io"; Name="Peerlist"; Type="Maker portfolio"; SubmitUrl="https://peerlist.io/"; DR="55"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Add project to profile."},
    @{Domain="devhunt.org"; Name="DevHunt"; Type="Dev tool launch"; SubmitUrl="https://devhunt.org/submit"; DR="48"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Weekly dev tool launches."},
    @{Domain="toptools.io"; Name="TopTools"; Type="Tool directory"; SubmitUrl="https://toptools.io/submit"; DR="42"; Cost="Free"; PrimaryPage="CompressTool"; Anchor="RatPDF compress PDF"; Notes="Free submit form."},
    @{Domain="toolfinder.co"; Name="ToolFinder"; Type="Tool directory"; SubmitUrl="https://toolfinder.co/submit-a-tool"; DR="38"; Cost="Free"; PrimaryPage="OcrTool"; Anchor="RatPDF OCR"; Notes="OCR + PDF cluster."},
    @{Domain="free-for.dev"; Name="free-for.dev"; Type="GitHub awesome list"; SubmitUrl="https://github.com/ripienaar/free-for-dev/pulls"; DR="75"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="PR to add under Document Processing."},
    @{Domain="github.com"; Name="awesome-selfhosted"; Type="GitHub awesome list"; SubmitUrl="https://github.com/awesome-selfhosted/awesome-selfhosted"; DR="99"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Only if self-hostable story fits."},
    @{Domain="github.com"; Name="awesome-privacy"; Type="GitHub awesome list"; SubmitUrl="https://github.com/pluja/awesome-privacy"; DR="99"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Pitch browser-based privacy angle."},
    @{Domain="elearningindustry.com"; Name="eLearning Industry"; Type="Software directory"; SubmitUrl="https://elearningindustry.com/directory/submit-software"; DR="82"; Cost="Free"; PrimaryPage="PdfToTextTool"; Anchor="RatPDF PDF to text"; Notes="Ed/academic PDF workflows."},
    @{Domain="financesonline.com"; Name="FinancesOnline"; Type="B2B directory"; SubmitUrl="https://financesonline.com/add-product/"; DR="78"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Invoice + PDF angle for accountants."},
    @{Domain="goodfirms.co"; Name="GoodFirms"; Type="B2B directory"; SubmitUrl="https://www.goodfirms.co/register"; DR="74"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Software development / SaaS."},
    @{Domain="softwaresuggest.com"; Name="SoftwareSuggest"; Type="SaaS directory"; SubmitUrl="https://www.softwaresuggest.com/vendors"; DR="72"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="India + global traffic."},
    @{Domain="techjockey.com"; Name="TechJockey"; Type="SaaS directory"; SubmitUrl="https://www.techjockey.com/vendors"; DR="58"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Strong India SMB audience."},
    @{Domain="selecthub.com"; Name="SelectHub"; Type="Buyer's guide"; SubmitUrl="https://www.selecthub.com/contact-us/"; DR="65"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Pitch for PDF tool buyer guide inclusion."},
    @{Domain="digital.com"; Name="Digital.com"; Type="Review site"; SubmitUrl="https://digital.com/contact/"; DR="70"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Best PDF tools roundup outreach."},
    @{Domain="pcmag.com"; Name="PCMag"; Type="Editorial"; SubmitUrl="https://www.pcmag.com/about/contact-the-editors"; DR="92"; Cost="Free pitch"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Pitch free PDF toolkit vs paid."},
    @{Domain="makeuseof.com"; Name="MakeUseOf"; Type="Editorial"; SubmitUrl="https://www.makeuseof.com/about/"; DR="91"; Cost="Free pitch"; PrimaryPage="CompressEmail"; Anchor="compress PDF for email"; Notes="How-to guest post pitch."},
    @{Domain="howtogeek.com"; Name="How-To Geek"; Type="Editorial"; SubmitUrl="https://www.howtogeek.com/contact/"; DR="91"; Cost="Free pitch"; PrimaryPage="CompressTool"; Anchor="compress PDF online"; Notes="Email attachment size article."},
    @{Domain="lifewire.com"; Name="Lifewire"; Type="Editorial"; SubmitUrl="https://www.lifewire.com/about-us-4778040"; DR="90"; Cost="Free pitch"; PrimaryPage="PdfToTextHowTo"; Anchor="PDF to text"; Notes="Convert PDF to text tutorial update."},
    @{Domain="zapier.com"; Name="Zapier"; Type="Resource/blog"; SubmitUrl="https://zapier.com/blog/write-for-us/"; DR="93"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Productivity workflows with PDF."},
    @{Domain="nngroup.com"; Name="Nielsen Norman Group"; Type="Resource"; SubmitUrl="https://www.nngroup.com/articles/"; DR="85"; Cost="Free cite"; PrimaryPage="AttachmentLimits"; Anchor="email attachment limits"; Notes="Cite research in UX docs on file limits."},
    @{Domain="hbr.org"; Name="Harvard Business Review"; Type="Editorial"; SubmitUrl="https://hbr.org/guidelines-for-authors-web"; DR="94"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="freelancer invoicing"; Notes="Long shot; invoicing statistics angle."},
    @{Domain="smashingmagazine.com"; Name="Smashing Magazine"; Type="Editorial"; SubmitUrl="https://www.smashingmagazine.com/write-for-us/"; DR="91"; Cost="Free"; PrimaryPage="HtmlToPdf="; Anchor=""; Notes="Skip - fix below"}
)

# Fix botched last entry
$freeListings = $freeListings[0..($freeListings.Count-2)]

$moreFreeListings = @(
    @{Domain="smashingmagazine.com"; Name="Smashing Magazine"; Type="Editorial"; SubmitUrl="https://www.smashingmagazine.com/write-for-us/"; DR="91"; Cost="Free"; PrimaryPage="Resources"; Anchor="PDF workflow"; Notes="Developer PDF/HTML article pitch."},
    @{Domain="css-tricks.com"; Name="CSS-Tricks"; Type="Editorial"; SubmitUrl="https://css-tricks.com/contact/"; DR="88"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="HTML to PDF"; Notes="html-to-pdf developer guide."},
    @{Domain="sitepoint.com"; Name="SitePoint"; Type="Editorial"; SubmitUrl="https://www.sitepoint.com/write-for-us/"; DR="86"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Web dev tool roundup."},
    @{Domain="freelancer.com"; Name="Freelancer.com Blog"; Type="Blog mention"; SubmitUrl="https://www.freelancer.com/community/"; DR="91"; Cost="Free"; PrimaryPage="Resources"; Anchor="invoice PDF"; Notes="Freelancer invoicing stats outreach."},
    @{Domain="upwork.com"; Name="Upwork Resource Center"; Type="Resource page"; SubmitUrl="https://www.upwork.com/resources/"; DR="93"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="freelance PDF tools"; Notes="Resource article on client document workflows."},
    @{Domain="bench.co"; Name="Bench Accounting"; Type="Blog mention"; SubmitUrl="https://bench.co/blog/"; DR="72"; Cost="Free pitch"; PrimaryPage="AttachmentLimits"; Anchor="PDF size limits"; Notes="Accountant audience - compress bank PDFs."},
    @{Domain="freshbooks.com"; Name="FreshBooks"; Type="Resource/blog"; SubmitUrl="https://www.freshbooks.com/hub/"; DR="85"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="invoice PDF"; Notes="SMB invoicing + PDF compress."},
    @{Domain="waveapps.com"; Name="Wave Apps"; Type="Blog mention"; SubmitUrl="https://www.waveapps.com/blog"; DR="80"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="GST invoice PDF"; Notes="India GST invoice checker angle."},
    @{Domain="quickbooks.intuit.com"; Name="QuickBooks"; Type="Resource page"; SubmitUrl="https://quickbooks.intuit.com/r/"; DR="94"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="PDF tools for accountants"; Notes="Link to /pdf-tools-for-accountants."},
    @{Domain="clio.com"; Name="Clio Legal"; Type="Resource page"; SubmitUrl="https://www.clio.com/blog/"; DR="78"; Cost="Free pitch"; PrimaryPage="PdfToolsLawyers"; Anchor="PDF tools for lawyers"; Notes="Legal PDF redact/compress/merge."},
    @{Domain="americanbar.org"; Name="ABA"; Type="Resource page"; SubmitUrl="https://www.americanbar.org/groups/"; DR="90"; Cost="Free pitch"; PrimaryPage="PdfToolsLawyers"; Anchor="PDF redaction"; Notes="Legal tech resource inclusion."},
    @{Domain="lawtechnologytoday.org"; Name="Law Technology Today"; Type="Editorial"; SubmitUrl="https://www.lawtechnologytoday.org/about/submissions/"; DR="65"; Cost="Free"; PrimaryPage="PdfToolsLawyers"; Anchor="PDF tools"; Notes="ABA Law Practice Division."},
    @{Domain="eff.org"; Name="EFF"; Type="Resource page"; SubmitUrl="https://www.eff.org/pages/contact"; DR="92"; Cost="Free pitch"; PrimaryPage="SecureWorkflow"; Anchor="PDF password protect"; Notes="Digital security / document privacy."},
    @{Domain="privacyguides.org"; Name="Privacy Guides"; Type="Resource page"; SubmitUrl="https://github.com/privacyguides/privacyguides.org"; DR="72"; Cost="Free PR"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Browser-based, files deleted angle."},
    @{Domain="digital.gov"; Name="Digital.gov"; Type="Gov resource"; SubmitUrl="https://digital.gov/contact/"; DR="85"; Cost="Free pitch"; PrimaryPage="OcrGuide"; Anchor="OCR PDF accessibility"; Notes="Gov PDF accessibility / Section 508."},
    @{Domain="section508.gov"; Name="Section508.gov"; Type="Gov resource"; SubmitUrl="https://www.section508.gov/"; DR="78"; Cost="Free cite"; PrimaryPage="OcrGuide"; Anchor="searchable PDF OCR"; Notes="Accessible document workflow cite."},
    @{Domain="ada.gov"; Name="ADA.gov"; Type="Gov resource"; SubmitUrl="https://www.ada.gov/"; DR="88"; Cost="Free cite"; PrimaryPage="OcrGuide"; Anchor="OCR PDF"; Notes="Accessible PDF creation resources."},
    @{Domain="nist.gov"; Name="NIST"; Type="Gov resource"; SubmitUrl="https://www.nist.gov/contact"; DR="91"; Cost="Free cite"; PrimaryPage="AttachmentLimits"; Anchor="document file sizes"; Notes="Cite attachment limits research."},
    @{Domain="usa.gov"; Name="USA.gov"; Type="Gov resource"; SubmitUrl="https://www.usa.gov/contact"; DR="93"; Cost="Free pitch"; PrimaryPage="CompressTool"; Anchor="compress PDF"; Notes="Citizen services document help."},
    @{Domain="irs.gov"; Name="IRS"; Type="Gov resource"; SubmitUrl="https://www.irs.gov/help/contact-your-local-irs-office"; DR="95"; Cost="Free cite"; PrimaryPage="CompressTool"; Anchor="compress tax PDF"; Notes="Tax PDF upload size - cite limits page."},
    @{Domain="gov.uk"; Name="GOV.UK"; Type="Gov resource"; SubmitUrl="https://www.gov.uk/help/contact"; DR="94"; Cost="Free pitch"; PrimaryPage="CompressTool"; Anchor="compress PDF"; Notes="Document services for citizens."},
    @{Domain="service.gov.uk"; Name="GDS Service Manual"; Type="Gov resource"; SubmitUrl="https://gds.blog.gov.uk/"; DR="90"; Cost="Free pitch"; PrimaryPage="OcrGuide"; Anchor="accessible PDFs"; Notes="UK gov digital service PDF guidance."},
    @{Domain="canada.ca"; Name="Canada.ca"; Type="Gov resource"; SubmitUrl="https://www.canada.ca/en/contact.html"; DR="93"; Cost="Free pitch"; PrimaryPage="CompressTool"; Anchor="reduce PDF size"; Notes="Immigration / services PDF uploads."},
    @{Domain="ato.gov.au"; Name="ATO Australia"; Type="Gov resource"; SubmitUrl="https://www.ato.gov.au/"; DR="85"; Cost="Free cite"; PrimaryPage="CompressTool"; Anchor="PDF file size"; Notes="Tax document upload limits."},
    @{Domain="edu.gcfglobal.org"; Name="GCFGlobal"; Type="Resource page"; SubmitUrl="https://edu.gcfglobal.org/en/contact-us/"; DR="78"; Cost="Free pitch"; PrimaryPage="PdfToTextHowTo"; Anchor="extract text from PDF"; Notes="Free learning site - PDF tutorials."},
    @{Domain="libguides.com"; Name="LibGuides (Springshare)"; Type="Resource page"; SubmitUrl="https://springshare.com/"; DR="85"; Cost="Free outreach"; PrimaryPage="OcrTool"; Anchor="OCR scanned PDF"; Notes="Pitch university librarians - digitization guides."},
    @{Domain="archive.org"; Name="Internet Archive"; Type="Resource page"; SubmitUrl="https://archive.org/about/contact.php"; DR="94"; Cost="Free"; PrimaryPage="OcrTool"; Anchor="OCR PDF"; Notes="Digitization community; forum/wiki links."},
    @{Domain="wikidata.org"; Name="Wikidata"; Type="Reference"; SubmitUrl="https://www.wikidata.org/wiki/Wikidata:Contact_us"; DR="95"; Cost="Free"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Add entity if notable; Wikipedia notability rules."},
    @{Domain="reddit.com"; Name="r/pdf"; Type="Community"; SubmitUrl="https://www.reddit.com/r/pdf/"; DR="95"; Cost="Free"; PrimaryPage="CompressTool"; Anchor="RatPDF"; Notes="Helpful comments only - no spam. Answer questions."},
    @{Domain="reddit.com"; Name="r/productivity"; Type="Community"; SubmitUrl="https://www.reddit.com/r/productivity/"; DR="95"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Tool recommendation when relevant."},
    @{Domain="reddit.com"; Name="r/freelance"; Type="Community"; SubmitUrl="https://www.reddit.com/r/freelance/"; DR="95"; Cost="Free"; PrimaryPage="Resources"; Anchor="invoice PDF"; Notes="Invoicing workflow tips."},
    @{Domain="news.ycombinator.com"; Name="Hacker News"; Type="Community"; SubmitUrl="https://news.ycombinator.com/submit"; DR="91"; Cost="Free"; PrimaryPage="Resources"; Anchor="PDF compression benchmark"; Notes="Show HN: original research posts."},
    @{Domain="dev.to"; Name="DEV Community"; Type="Blog/platform"; SubmitUrl="https://dev.to/new"; DR="85"; Cost="Free"; PrimaryPage="CompressBench"; Anchor="PDF compression study"; Notes="Publish benchmark methodology post."},
    @{Domain="hashnode.com"; Name="Hashnode"; Type="Blog/platform"; SubmitUrl="https://hashnode.com/"; DR="82"; Cost="Free"; PrimaryPage="PdfToTextHowTo"; Anchor="PDF to text"; Notes="Cross-post technical guides."},
    @{Domain="medium.com"; Name="Medium"; Type="Blog/platform"; SubmitUrl="https://medium.com/new-story"; DR="95"; Cost="Free"; PrimaryPage="AttachmentLimits"; Anchor="email attachment limits 2026"; Notes="RatPDF publication - cite research."},
    @{Domain="linkedin.com"; Name="LinkedIn Articles"; Type="Blog/platform"; SubmitUrl="https://www.linkedin.com/article/new/"; DR="98"; Cost="Free"; PrimaryPage="Resources"; Anchor="PDF tools"; Notes="Ethan Brooks / Priya Sharma author profiles."},
    @{Domain="quora.com"; Name="Quora"; Type="Q&A"; SubmitUrl="https://www.quora.com/"; DR="93"; Cost="Free"; PrimaryPage="CompressEmail"; Anchor="compress PDF for Gmail"; Notes="Answer with link to pillar page - no spam."},
    @{Domain="stackoverflow.com"; Name="Stack Overflow"; Type="Q&A"; SubmitUrl="https://stackoverflow.com/questions/ask"; DR="95"; Cost="Free"; PrimaryPage="PdfToTextTool"; Anchor="extract PDF text"; Notes="Answer programming questions; link when genuinely helpful."},
    @{Domain="superuser.com"; Name="Super User"; Type="Q&A"; SubmitUrl="https://superuser.com/"; DR="90"; Cost="Free"; PrimaryPage="CompressTool"; Anchor="compress PDF"; Notes="IT pro audience."},
    @{Domain="webapps.stackexchange.com"; Name="Web Apps SE"; Type="Q&A"; SubmitUrl="https://webapps.stackexchange.com/"; DR="88"; Cost="Free"; PrimaryPage="PdfToTextHub"; Anchor="PDF to text online"; Notes="Online tool recommendations."},
    @{Domain="smallbusiness.chron.com"; Name="Chron SMB"; Type="Editorial"; SubmitUrl="https://smallbusiness.chron.com/contact-us"; DR="92"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="small business PDF"; Notes="SMB document workflow."},
    @{Domain="businessnewsdaily.com"; Name="Business News Daily"; Type="Editorial"; SubmitUrl="https://www.businessnewsdaily.com/contact"; DR="85"; Cost="Free pitch"; PrimaryPage="Compare"; Anchor="best PDF tools"; Notes="Tool roundup inclusion."},
    @{Domain="techradar.com"; Name="TechRadar"; Type="Editorial"; SubmitUrl="https://www.techradar.com/news/contact-us"; DR="92"; Cost="Free pitch"; PrimaryPage="Compare"; Anchor="RatPDF vs Adobe"; Notes="Best free PDF software list."},
    @{Domain="tomsguide.com"; Name="Tom's Guide"; Type="Editorial"; SubmitUrl="https://www.tomsguide.com/contact"; DR="90"; Cost="Free pitch"; PrimaryPage="CompressTool"; Anchor="compress PDF free"; Notes="How-to and best-of lists."},
    @{Domain="digitaltrends.com"; Name="Digital Trends"; Type="Editorial"; SubmitUrl="https://www.digitaltrends.com/contact/"; DR="91"; Cost="Free pitch"; PrimaryPage="Compare"; Anchor="PDF tools"; Notes="Software best-of outreach."},
    @{Domain="cnet.com"; Name="CNET"; Type="Editorial"; SubmitUrl="https://www.cnet.com/contact/"; DR="93"; Cost="Free pitch"; PrimaryPage="Compare"; Anchor="free PDF editor"; Notes="Download/editor alternative lists."},
    @{Domain="techrepublic.com"; Name="TechRepublic"; Type="Editorial"; SubmitUrl="https://www.techrepublic.com/contact/"; DR="88"; Cost="Free pitch"; PrimaryPage="PdfToolsHub"; Anchor="PDF toolkit"; Notes="Enterprise IT document tools."},
    @{Domain="zdnet.com"; Name="ZDNet"; Type="Editorial"; SubmitUrl="https://www.zdnet.com/contact/"; DR="92"; Cost="Free pitch"; PrimaryPage="Compare"; Anchor="RatPDF"; Notes="Business tech software."},
    @{Domain="theverge.com"; Name="The Verge"; Type="Editorial"; SubmitUrl="https://www.theverge.com/contact"; DR="93"; Cost="Free pitch"; PrimaryPage="PdfToolsHub"; Anchor="PDF tools"; Notes="Long shot product story."},
    @{Domain="wired.com"; Name="Wired"; Type="Editorial"; SubmitUrl="https://www.wired.com/about/feedback/"; DR="94"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="document privacy"; Notes="Privacy angle on browser tools."},
    @{Domain="mashable.com"; Name="Mashable"; Type="Editorial"; SubmitUrl="https://mashable.com/about/contact"; DR="93"; Cost="Free pitch"; PrimaryPage="CompressTool"; Anchor="compress PDF"; Notes="Life hacks / productivity."},
    @{Domain="lifehacker.com"; Name="Lifehacker"; Type="Editorial"; SubmitUrl="https://lifehacker.com/contact"; DR="90"; Cost="Free pitch"; PrimaryPage="CompressEmail"; Anchor="email PDF too large"; Notes="Classic fit - attachment limits research."},
    @{Domain="hubspot.com"; Name="HubSpot Blog"; Type="Resource/blog"; SubmitUrl="https://blog.hubspot.com/marketing/guest-blogging"; DR="93"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="PDF marketing assets"; Notes="Marketing PDF compress/merge guide."},
    @{Domain="buffer.com"; Name="Buffer Resources"; Type="Resource/blog"; SubmitUrl="https://buffer.com/resources"; DR="88"; Cost="Free pitch"; PrimaryPage="CompressTool"; Anchor="PDF for social"; Notes="Content team PDF workflows."},
    @{Domain="notion.so"; Name="Notion Template Gallery"; Type="Resource page"; SubmitUrl="https://www.notion.so/templates"; DR="92"; Cost="Free"; PrimaryPage="PdfToTextTool"; Anchor="PDF to text"; Notes="Template creators linking PDF tools."},
    @{Domain="airtable.com"; Name="Airtable Universe"; Type="Resource page"; SubmitUrl="https://airtable.com/universe"; DR="90"; Cost="Free"; PrimaryPage="Resources"; Anchor="invoice workflow"; Notes="SMB workflow templates."},
    @{Domain="canva.com"; Name="Canva Design School"; Type="Resource/blog"; SubmitUrl="https://www.canva.com/learn/"; DR="93"; Cost="Free pitch"; PrimaryPage="CompressTool"; Anchor="compress PDF for print"; Notes="Design export PDF size."},
    @{Domain="figma.com"; Name="Figma Community"; Type="Resource page"; SubmitUrl="https://www.figma.com/community"; DR="92"; Cost="Free"; PrimaryPage="CompressTool"; Anchor="PDF export compress"; Notes="Design handoff PDF size."},
    @{Domain="dribbble.com"; Name="Dribbble"; Type="Resource/blog"; SubmitUrl="https://dribbble.com/stories"; DR="91"; Cost="Free pitch"; PrimaryPage="CompressTool"; Anchor="portfolio PDF"; Notes="Designer portfolio PDF compression."},
    @{Domain="behance.net"; Name="Behance"; Type="Resource page"; SubmitUrl="https://www.behance.net/"; DR="93"; Cost="Free"; PrimaryPage="CompressTool"; Anchor="compress portfolio PDF"; Notes="Creative pro audience."},
    @{Domain="academic.oup.com"; Name="Oxford Academic"; Type="Editorial"; SubmitUrl="https://academic.oup.com/pages/contact"; DR="94"; Cost="Free cite"; PrimaryPage="OcrTool"; Anchor="OCR digitization"; Notes="Library science citations."},
    @{Domain="jstor.org"; Name="JSTOR"; Type="Resource page"; SubmitUrl="https://about.jstor.org/contact/"; DR="93"; Cost="Free outreach"; PrimaryPage="OcrTool"; Anchor="OCR scanned documents"; Notes="Research digitization resources."},
    @{Domain="doaj.org"; Name="DOAJ"; Type="Directory"; SubmitUrl="https://doaj.org/apply/"; DR="80"; Cost="Free"; PrimaryPage="Resources"; Anchor="open research"; Notes="If publishing open research notes."},
    @{Domain="scholar.google.com"; Name="Google Scholar"; Type="Reference"; SubmitUrl="https://scholar.google.com/intl/en/scholar/inclusions.html"; DR="99"; Cost="Free"; PrimaryPage="CompressBench"; Anchor="PDF compression benchmark"; Notes="Index research pages as publications."},
    @{Domain="researchgate.net"; Name="ResearchGate"; Type="Reference"; SubmitUrl="https://www.researchgate.net/"; DR="94"; Cost="Free"; PrimaryPage="AttachmentLimits"; Anchor="attachment size limits study"; Notes="Upload research PDF summary."},
    @{Domain="semanticscholar.org"; Name="Semantic Scholar"; Type="Reference"; SubmitUrl="https://www.semanticscholar.org/"; DR="88"; Cost="Free"; PrimaryPage="CompressBench"; Anchor="PDF compression"; Notes="Research visibility."},
    @{Domain="osha.gov"; Name="OSHA"; Type="Gov resource"; SubmitUrl="https://www.osha.gov/contact-us"; DR="90"; Cost="Free cite"; PrimaryPage="CompressTool"; Anchor="SDS PDF"; Notes="Safety data sheet PDF handling."},
    @{Domain="epa.gov"; Name="EPA"; Type="Gov resource"; SubmitUrl="https://www.epa.gov/utility/contact-us"; DR="93"; Cost="Free cite"; PrimaryPage="CompressTool"; Anchor="environmental PDF forms"; Notes="Form upload size guidance."},
    @{Domain="sba.gov"; Name="SBA"; Type="Gov resource"; SubmitUrl="https://www.sba.gov/about-sba/sba-locations"; DR="92"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="small business PDF tools"; Notes="SMB resource page outreach."},
    @{Domain="score.org"; Name="SCORE"; Type="Resource page"; SubmitUrl="https://www.score.org/find-mentor"; DR="75"; Cost="Free pitch"; PrimaryPage="Resources"; Anchor="invoice PDF"; Notes="Mentor resource library for SMBs."},
    @{Domain="khanacademy.org"; Name="Khan Academy"; Type="Resource page"; SubmitUrl="https://www.khanacademy.org/about/contact"; DR="90"; Cost="Free pitch"; PrimaryPage="PdfToTextTool"; Anchor="extract text from PDF"; Notes="Student study material workflows."},
    @{Domain="coursera.org"; Name="Coursera"; Type="Resource/blog"; SubmitUrl="https://about.coursera.org/press"; DR="92"; Cost="Free pitch"; PrimaryPage="PdfToTextTool"; Anchor="PDF notes"; Notes="Learner productivity article."},
    @{Domain="edx.org"; Name="edX"; Type="Resource/blog"; SubmitUrl="https://www.edx.org/about-us"; DR="91"; Cost="Free pitch"; PrimaryPage="OcrTool"; Anchor="OCR lecture scans"; Notes="Academic scan-to-text."},
    @{Domain="mit.edu"; Name="MIT OpenCourseWare"; Type="Resource page"; SubmitUrl="https://ocw.mit.edu/contact/"; DR="95"; Cost="Free outreach"; PrimaryPage="OcrTool"; Anchor="OCR PDF"; Notes="OCW digitization resource links."},
    @{Domain="stanford.edu"; Name="Stanford Online"; Type="Resource page"; SubmitUrl="https://online.stanford.edu/contact"; DR="95"; Cost="Free outreach"; PrimaryPage="PdfToTextTool"; Anchor="PDF to text"; Notes="IT help / student resources."},
    @{Domain="harvard.edu"; Name="Harvard IT Help"; Type="Resource page"; SubmitUrl="https://harvard.service-now.com/ithelp"; DR="96"; Cost="Free outreach"; PrimaryPage="CompressTool"; Anchor="compress PDF"; Notes="Pitch IT knowledge base inclusion."},
    @{Domain="berkeley.edu"; Name="UC Berkeley IST"; Type="Resource page"; SubmitUrl="https://technology.berkeley.edu/contact"; DR="95"; Cost="Free outreach"; PrimaryPage="OcrGuide"; Anchor="accessible PDF"; Notes="Campus accessibility PDF guides."},
    @{Domain="umich.edu"; Name="U Michigan ITS"; Type="Resource page"; SubmitUrl="https://its.umich.edu/contact"; DR="94"; Cost="Free outreach"; PrimaryPage="PdfToTextHowTo"; Anchor="convert PDF to text"; Notes="Student tech support articles."},
    @{Domain="washington.edu"; Name="UW IT Connect"; Type="Resource page"; SubmitUrl="https://itconnect.uw.edu/"; DR="93"; Cost="Free outreach"; PrimaryPage="CompressEmail"; Anchor="email PDF size"; Notes="Email attachment help articles."},
    @{Domain="illinois.edu"; Name="UIUC Tech Services"; Type="Resource page"; SubmitUrl="https://techservices.illinois.edu/get-help"; DR="93"; Cost="Free outreach"; PrimaryPage="PdfToolsHub"; Anchor="PDF tools"; Notes="Campus software alternatives."},
    @{Domain="utexas.edu"; Name="UT Austin ITS"; Type="Resource page"; SubmitUrl="https://ut.service-now.com/sp"; DR="93"; Cost="Free outreach"; PrimaryPage="CompressTool"; Anchor="reduce PDF size"; Notes="Student upload portal tips."},
    @{Domain="gatech.edu"; Name="Georgia Tech OIT"; Type="Resource page"; SubmitUrl="https://oit.gatech.edu/contact"; DR="92"; Cost="Free outreach"; PrimaryPage="OcrTool"; Anchor="OCR PDF"; Notes="Research scan workflows."},
    @{Domain="cmu.edu"; Name="CMU Computing Services"; Type="Resource page"; SubmitUrl="https://www.cmu.edu/computing/contact/"; DR="93"; Cost="Free outreach"; PrimaryPage="PdfToTextTool"; Anchor="PDF text extraction"; Notes="Academic research support."},
    @{Domain="ox.ac.uk"; Name="Oxford IT Services"; Type="Resource page"; SubmitUrl="https://www.it.ox.ac.uk/help"; DR="94"; Cost="Free outreach"; PrimaryPage="CompressTool"; Anchor="compress PDF"; Notes="UK university IT help."},
    @{Domain="cam.ac.uk"; Name="Cambridge UIS"; Type="Resource page"; SubmitUrl="https://www.ucs.cam.ac.uk/contact"; DR="94"; Cost="Free outreach"; PrimaryPage="OcrGuide"; Anchor="OCR searchable PDF"; Notes="Research digitization."},
    @{Domain="imperial.ac.uk"; Name="Imperial ICT"; Type="Resource page"; SubmitUrl="https://www.imperial.ac.uk/admin-services/ict/contact/"; DR="92"; Cost="Free outreach"; PrimaryPage="PdfToTextHub"; Anchor="PDF to text"; Notes="Student PDF workflows."},
    @{Domain="ed.ac.uk"; Name="Edinburgh IS"; Type="Resource page"; SubmitUrl="https://www.ed.ac.uk/information-services/help-consultancy"; DR="93"; Cost="Free outreach"; PrimaryPage="CompressTool"; Anchor="PDF compression"; Notes="UK HE IT knowledge base."},
    @{Domain="utoronto.ca"; Name="U Toronto ITS"; Type="Resource page"; SubmitUrl="https://www.utoronto.ca/its/contact"; DR="93"; Cost="Free outreach"; PrimaryPage="PdfToTextHowTo"; Anchor="PDF to text"; Notes="Canadian university IT."},
    @{Domain="ubc.ca"; Name="UBC IT"; Type="Resource page"; SubmitUrl="https://it.ubc.ca/contact-us"; DR="92"; Cost="Free outreach"; PrimaryPage="OcrTool"; Anchor="OCR PDF"; Notes="Library digitization staff."},
    @{Domain="unimelb.edu.au"; Name="Uni Melbourne"; Type="Resource page"; SubmitUrl="https://servicedesk.unimelb.edu.au/"; DR="91"; Cost="Free outreach"; PrimaryPage="CompressTool"; Anchor="compress PDF"; Notes="AU student services."},
    @{Domain="sydney.edu.au"; Name="Uni Sydney"; Type="Resource page"; SubmitUrl="https://www.sydney.edu.au/students/it.html"; DR="91"; Cost="Free outreach"; PrimaryPage="PdfToTextTool"; Anchor="extract PDF text"; Notes="Student IT support article pitch."},
    @{Domain="nus.edu.sg"; Name="NUS IT"; Type="Resource page"; SubmitUrl="https://nusit.nus.edu.sg/contact/"; DR="90"; Cost="Free outreach"; PrimaryPage="CompressTool"; Anchor="compress PDF online"; Notes="APAC university IT."},
    @{Domain="iitb.ac.in"; Name="IIT Bombay"; Type="Resource page"; SubmitUrl="https://www.iitb.ac.in/en/contact"; DR="88"; Cost="Free outreach"; PrimaryPage="PdfToolsHub"; Anchor="PDF tools"; Notes="India tech student audience."},
    @{Domain="iisc.ac.in"; Name="IISc Bangalore"; Type="Resource page"; SubmitUrl="https://iisc.ac.in/contact/"; DR="85"; Cost="Free outreach"; PrimaryPage="OcrTool"; Anchor="OCR research PDF"; Notes="Research scan digitization."}
)

$freeListings = $freeListings + $moreFreeListings

# Additional free tool / SaaS directories (batch 2)
$batch2 = @(
    @{Domain="topai.tools"; Name="TopAI Tools"; Type="Tool directory"; SubmitUrl="https://topai.tools/submit"; DR="55"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF PDF tools"; Notes="Free submit."},
    @{Domain="aitoolsdirectory.com"; Name="AI Tools Directory"; Type="Tool directory"; SubmitUrl="https://aitoolsdirectory.com/submit-tool"; DR="48"; Cost="Free"; PrimaryPage="OcrTool"; Anchor="RatPDF OCR"; Notes="OCR angle."},
    @{Domain="pdfassociation.org"; Name="PDF Association"; Type="Industry org"; SubmitUrl="https://www.pdfa.org/contact/"; DR="68"; Cost="Free"; PrimaryPage="Resources"; Anchor="PDF tools research"; Notes="Industry credibility."},
    @{Domain="planetpdf.com"; Name="Planet PDF"; Type="Community"; SubmitUrl="https://www.planetpdf.com/"; DR="62"; Cost="Free"; PrimaryPage="CompressTool"; Anchor="compress PDF"; Notes="Legacy PDF community."},
    @{Domain="f6s.com"; Name="F6S"; Type="Startup directory"; SubmitUrl="https://www.f6s.com/"; DR="78"; Cost="Free"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Startup profile + deals."},
    @{Domain="crunchbase.com"; Name="Crunchbase"; Type="Company profile"; SubmitUrl="https://www.crunchbase.com/add-company"; DR="91"; Cost="Free basic"; PrimaryPage="PdfToolsHub"; Anchor="RatPDF"; Notes="Brand entity; basic profile free."}
)
$freeListings = $freeListings + $batch2

# Expand: university IT help desk pattern (high-value resource pages)
$uniDomains = @(
    "yale.edu","princeton.edu","columbia.edu","upenn.edu","brown.edu","dartmouth.edu","cornell.edu",
    "duke.edu","northwestern.edu","vanderbilt.edu","rice.edu","emory.edu","usc.edu","ucla.edu","ucsd.edu",
    "ucsb.edu","ucdavis.edu","ucirvine.edu","purdue.edu","wisc.edu","umn.edu","osu.edu","psu.edu",
    "umd.edu","virginia.edu","unc.edu","duke.edu","boston.edu","nyu.edu","rutgers.edu","asu.edu",
    "colorado.edu","wustl.edu","tufts.edu","brandeis.edu","rochester.edu","case.edu","lehigh.edu",
    "northeastern.edu","bu.edu","georgetown.edu","tamu.edu","ufl.edu","uga.edu","indiana.edu","msu.edu",
    "oregonstate.edu","wsu.edu","arizona.edu","uoregon.edu","ku.edu","miami.edu","fiu.edu","fsu.edu",
    "clemson.edu","vt.edu","ncsu.edu","pitt.edu","drexel.edu","temple.edu","syr.edu","buffalo.edu",
    "lse.ac.uk","kcl.ac.uk","manchester.ac.uk","bristol.ac.uk","warwick.ac.uk","glasgow.ac.uk","leeds.ac.uk",
    "sheffield.ac.uk","nottingham.ac.uk","birmingham.ac.uk","durham.ac.uk","exeter.ac.uk","york.ac.uk",
    "mcgill.ca","ualberta.ca","uwaterloo.ca","sfu.ca","uvic.ca","queensu.ca","yorku.ca",
    "unsw.edu.au","anu.edu.au","monash.edu","uq.edu.au","adelaide.edu.au","curtin.edu.au",
    "tcd.ie","ucd.ie","dcu.ie","nuigalway.ie",
    "ethz.ch","epfl.ch","unil.ch",
    "tum.de","lmu.de","uni-heidelberg.de","rwth-aachen.de","fu-berlin.de",
    "sorbonne-universite.fr","universite-paris-saclay.fr",
    "uva.nl","tudelft.nl","eur.nl",
    "kth.se","lu.se","su.se",
    "helsinki.fi","aalto.fi",
    "uio.no","ntnu.no",
    "copenhagen.dk","dtu.dk",
    "hku.hk","cuhk.edu.hk","hkust.edu.hk",
    "ntu.edu.tw","nctu.edu.tw",
    "snu.ac.kr","kaist.ac.kr","postech.ac.kr",
    "u-tokyo.ac.jp","kyoto-u.ac.jp","osaka-u.ac.jp","tohoku.ac.jp",
    "nus.edu.sg","ntu.edu.sg","smu.edu.sg",
    "iitd.ac.in","iitk.ac.in","iitm.ac.in","iitkgp.ac.in","bits-pilani.ac.in",
    "du.ac.in","jnu.ac.in","ignou.ac.in"
)

$pageClusters = @(
    @{Cluster="Compress PDF"; PageKey="CompressHub"; Anchor="compress PDF online free"; Pitch="Campus email attachment limits - link to compression hub + size checker"},
    @{Cluster="Compress PDF"; PageKey="AttachmentLimits"; Anchor="email attachment size limits"; Pitch="Cite original research table in IT help article"},
    @{Cluster="PDF to Text"; PageKey="PdfToTextHowTo"; Anchor="convert PDF to text"; Pitch="Student workflow: extract readings for notes"},
    @{Cluster="PDF to Text"; PageKey="PdfToTextHub"; Anchor="PDF to text online"; Pitch="Alternative to Adobe export for students"},
    @{Cluster="OCR"; PageKey="OcrGuide"; Anchor="OCR PDF searchable"; Pitch="Accessibility: make scanned PDFs searchable for screen readers"},
    @{Cluster="OCR"; PageKey="OcrPillar"; Anchor="OCR PDF to text"; Pitch="Library digitization scan-to-text workflow"}
)

$highValue = @()
$id = 1
foreach ($uni in $uniDomains) {
    foreach ($pc in $pageClusters) {
        $page = $ratpdfPages[$pc.PageKey]
        $highValue += [PSCustomObject]@{
            Id = $id++
            Cluster = $pc.Cluster
            TargetType = "Resource page"
            Domain = $uni
            TargetUrl = "https://www.$uni/search?q=PDF"
            DR_Est = "85-96"
            Cost = "Free outreach"
            RatPDF_Page = $page
            Anchor_Text = $pc.Anchor
            Pitch = $pc.Pitch
            Contact = "it-help@$uni OR library@$uni"
            Priority = "P1"
            Status = "Not started"
        }
    }
}

# Add curated high-value non-university targets
$curatedHigh = @(
    @{Cluster="Compress PDF"; Type="Resource page"; Domain="support.google.com"; Url="https://support.google.com/mail/answer/6584"; DR="99"; PageKey="AttachmentLimits"; Anchor="Gmail attachment size limits"; Pitch="Suggest citing RatPDF limits research in community answers"; Priority="P0"},
    @{Cluster="Compress PDF"; Type="Resource page"; Domain="support.microsoft.com"; Url="https://support.microsoft.com/en-us/office/restrictions-in-outlook"; DR="99"; PageKey="AttachmentLimits"; Anchor="Outlook attachment limits"; Pitch="Cross-reference attachment limits study"; Priority="P0"},
    @{Cluster="Compress PDF"; Type="Resource page"; Domain="support.apple.com"; Url="https://support.apple.com/mail"; DR="99"; PageKey="CompressEmail"; Anchor="compress PDF for Mail"; Pitch="Mac Mail large attachment help"; Priority="P1"},
    @{Cluster="Compress PDF"; Type="Blog mention"; Domain="dropbox.com"; Url="https://blog.dropbox.com/"; DR="94"; PageKey="CompressTool"; Anchor="compress PDF before upload"; Pitch="Cloud storage PDF size tips"; Priority="P1"},
    @{Cluster="Compress PDF"; Type="Blog mention"; Domain="box.com"; Url="https://blog.box.com/"; DR="88"; PageKey="CompressTool"; Anchor="reduce PDF file size"; Pitch="Enterprise file sharing limits"; Priority="P2"},
    @{Cluster="OCR"; Type="Resource page"; Domain="loc.gov"; Url="https://www.loc.gov/preservation/"; DR="95"; PageKey="OcrTool"; Anchor="OCR digitization"; Pitch="Library of Congress digitization resources"; Priority="P0"},
    @{Cluster="OCR"; Type="Resource page"; Domain="dp.la"; Url="https://dp.la/"; DR="82"; PageKey="OcrTool"; Anchor="OCR scanned documents"; Pitch="Digital Public Library of America"; Priority="P1"},
    @{Cluster="OCR"; Type="Resource page"; Domain="europeana.eu"; Url="https://www.europeana.eu/"; DR="85"; PageKey="OcrTool"; Anchor="OCR PDF"; Pitch="European digitization hub"; Priority="P1"},
    @{Cluster="OCR"; Type="Resource page"; Domain="digitalpreservation.gov"; Url="https://digitalpreservation.gov/"; DR="80"; PageKey="OcrGuide"; Anchor="searchable PDF"; Pitch="NDIIPP preservation guidelines"; Priority="P0"},
    @{Cluster="OCR"; Type="Resource page"; Domain="wiki.digitalpreservation.gov"; Url="https://wiki.digitalpreservation.gov/"; DR="80"; PageKey="OcrGuide"; Anchor="OCR text layer"; Pitch="Add tool to wiki resource list"; Priority="P1"},
    @{Cluster="PDF to Text"; Type="Resource page"; Domain="guides.lib.berkeley.edu"; Url="https://guides.lib.berkeley.edu/"; DR="93"; PageKey="PdfToTextHowTo"; Anchor="extract text from PDF"; Pitch="LibGuide for research PDF extraction"; Priority="P0"},
    @{Cluster="PDF to Text"; Type="Resource page"; Domain="guides.library.harvard.edu"; Url="https://guides.library.harvard.edu/"; DR="96"; PageKey="ExtractText"; Anchor="PDF text extraction"; Pitch="Harvard library research guide"; Priority="P0"},
    @{Cluster="PDF to Text"; Type="Resource page"; Domain="guides.nyu.edu"; Url="https://guides.nyu.edu/"; DR="92"; PageKey="PdfToTextHub"; Anchor="PDF to text"; Pitch="NYU library student guide"; Priority="P0"},
    @{Cluster="Compress PDF"; Type="Resource page"; Domain="guides.lib.utexas.edu"; Url="https://guides.lib.utexas.edu/"; DR="93"; PageKey="CompressHub"; Anchor="compress PDF"; Pitch="Submitting large PDFs to LMS"; Priority="P0"},
    @{Cluster="OCR"; Type="Resource page"; Domain="guides.lib.utexas.edu"; Url="https://guides.lib.utexas.edu/"; DR="93"; PageKey="ScannedPdf"; Anchor="scanned PDF to text"; Pitch="Digitization for research"; Priority="P0"},
    @{Cluster="Compress PDF"; Type="Editorial"; Domain="practicallaw.com"; Url="https://www.practicallaw.com/"; DR="75"; PageKey="PdfToolsLawyers"; Anchor="PDF tools for lawyers"; Pitch="Thomson Reuters legal workflow"; Priority="P1"},
    @{Cluster="OCR"; Type="Editorial"; Domain="law360.com"; Url="https://www.law360.com/"; DR="85"; PageKey="PdfToolsLawyers"; Anchor="PDF redaction OCR"; Pitch="Legal tech discovery workflows"; Priority="P2"},
    @{Cluster="Compress PDF"; Type="Blog mention"; Domain="accountingweb.co.uk"; Url="https://www.accountingweb.co.uk/"; DR="72"; PageKey="PdfToolsAccountants"; Anchor="compress bank statement PDF"; Pitch="Accountant PDF workflows"; Priority="P1"},
    @{Cluster="PDF to Text"; Type="Blog mention"; Domain="journalofaccountancy.com"; Url="https://www.journalofaccountancy.com/"; DR="78"; PageKey="PdfToTextTool"; Anchor="PDF to Excel/text"; Pitch="Extract tables from client PDFs"; Priority="P1"},
    @{Cluster="OCR"; Type="Resource page"; Domain="webaim.org"; Url="https://webaim.org/techniques/acrobat/"; DR="82"; PageKey="OcrGuide"; Anchor="accessible PDF OCR"; Pitch="WebAIM accessible PDF techniques"; Priority="P0"},
    @{Cluster="OCR"; Type="Resource page"; Domain="w3.org"; Url="https://www.w3.org/WAI/WCAG21/Understanding/"; DR="99"; PageKey="OcrGuide"; Anchor="searchable PDF"; Pitch="WCAG PDF accessibility resources"; Priority="P0"},
    @{Cluster="Compress PDF"; Type="Resource page"; Domain="wcag.com"; Url="https://www.wcag.com/"; DR="65"; PageKey="CompressTool"; Anchor="optimize PDF size"; Pitch="Accessible PDF file size balance"; Priority="P2"},
    @{Cluster="Compress PDF"; Type="Blog mention"; Domain="lifehacker.com"; Url="https://lifehacker.com/tag/pdf"; DR="90"; PageKey="CompressEmail"; Anchor="compress PDF email"; Pitch="Update attachment size article"; Priority="P0"},
    @{Cluster="PDF to Text"; Type="Resource page"; Domain="scholar.google.com"; Url="https://scholar.google.com/"; DR="99"; PageKey="PdfToTextHowTo"; Anchor="extract PDF text"; Pitch="Student research workflow cite"; Priority="P1"},
    @{Cluster="OCR"; Type="Resource page"; Domain="archives.gov"; Url="https://www.archives.gov/preservation/"; DR="92"; PageKey="OcrGuide"; Anchor="OCR digitization"; Pitch="NARA preservation resources"; Priority="P0"},
    @{Cluster="OCR"; Type="Resource page"; Domain="si.edu"; Url="https://www.si.edu/"; DR="90"; PageKey="OcrTool"; Anchor="OCR scanned documents"; Pitch="Smithsonian digitization"; Priority="P1"},
    @{Cluster="Compress PDF"; Type="Resource page"; Domain="mozilla.org"; Url="https://support.mozilla.org/"; DR="94"; PageKey="AttachmentLimits"; Anchor="email attachment limits"; Pitch="Thunderbird help article"; Priority="P1"},
    @{Cluster="PDF to Text"; Type="Blog mention"; Domain="towardsdatascience.com"; Url="https://towardsdatascience.com/"; DR="88"; PageKey="ExtractText"; Anchor="PDF text extraction"; Pitch="Data pipeline PDF parsing article"; Priority="P1"},
    @{Cluster="OCR"; Type="Resource page"; Domain="loc.gov"; Url="https://www.loc.gov/standards/"; DR="95"; PageKey="OcrGuide"; Anchor="searchable PDF"; Pitch="LOC standards for digitization"; Priority="P0"},
    @{Cluster="Compress PDF"; Type="SaaS listing"; Domain="trustradius.com"; Url="https://www.trustradius.com/"; DR="80"; PageKey="Compare"; Anchor="RatPDF"; Pitch="Free vendor profile"; Priority="P1"},
    @{Cluster="PDF to Text"; Type="SaaS listing"; Domain="softwareworld.co"; Url="https://www.softwareworld.co/"; DR="55"; PageKey="PdfToTextTool"; Anchor="PDF to text"; Pitch="Free software listing"; Priority="P2"}
)

foreach ($c in $curatedHigh) {
    $highValue += [PSCustomObject]@{
        Id = $id++
        Cluster = $c.Cluster
        TargetType = $c.Type
        Domain = $c.Domain
        TargetUrl = $c.Url
        DR_Est = $c.DR
        Cost = "Free outreach"
        RatPDF_Page = $ratpdfPages[$c.PageKey]
        Anchor_Text = $c.Anchor
        Pitch = $c.Pitch
        Contact = "editorial OR webmaster@$($c.Domain)"
        Priority = $c.Priority
        Status = "Not started"
    }
}

# Export free listings CSV
$listingRows = @()
$lid = 1
foreach ($l in $freeListings) {
    $pageKey = $l.PrimaryPage
    $url = if ($pageKey -eq "PdfToolsLawyers") { "https://ratpdf.com/pdf-tools-for-lawyers" }
           elseif ($pageKey -eq "PdfToolsAccountants") { "https://ratpdf.com/pdf-tools-for-accountants" }
           elseif ($pageKey -eq "SecureWorkflow") { "https://ratpdf.com/guides/secure-pdf-workflow" }
           elseif ($pageKey -eq "Compare") { $ratpdfPages.Compare }
           elseif ($pageKey -eq "Resources") { $ratpdfPages.Resources }
           elseif ($pageKey -eq "CompressTool") { $ratpdfPages.CompressTool }
           elseif ($pageKey -eq "CompressEmail") { $ratpdfPages.CompressEmail }
           elseif ($pageKey -eq "PdfToolsHub") { $ratpdfPages.PdfToolsHub }
           elseif ($pageKey -eq "OcrTool") { $ratpdfPages.OcrTool }
           elseif ($pageKey -eq "PdfToTextHowTo") { $ratpdfPages.PdfToTextHowTo }
           elseif ($pageKey -eq "PdfToTextTool") { $ratpdfPages.PdfToTextTool }
           elseif ($pageKey -eq "AttachmentLimits") { $ratpdfPages.AttachmentLimits }
           elseif ($pageKey -eq "CompressBench") { $ratpdfPages.CompressBench }
           elseif ($pageKey -eq "HtmlToPdf") { "https://ratpdf.com/pdf/htmltopdf" }
           else { $ratpdfPages.PdfToolsHub }
    $listingRows += [PSCustomObject]@{
        Id = $lid++
        ListingType = $l.Type
        Domain = $l.Domain
        SiteName = $l.Name
        SubmitUrl = $l.SubmitUrl
        DR_Est = $l.DR
        Cost = $l.Cost
        RatPDF_Page = $url
        SuggestedAnchor = $l.Anchor
        Notes = $l.Notes
        Priority = if ($l.DR -match '^\d+$' -and [int]$l.DR -ge 85) { "P0" } elseif ($l.DR -match '^\d+$' -and [int]$l.DR -ge 70) { "P1" } else { "P2" }
        Status = "Not started"
    }
}
$listingRows | Export-Csv -Path (Join-Path $outDir "backlink-free-listings.csv") -NoTypeInformation -Encoding UTF8

$highValue | Export-Csv -Path (Join-Path $outDir "backlink-high-value-targets.csv") -NoTypeInformation -Encoding UTF8

# Content mapping summary
$mapping = @(
    [PSCustomObject]@{Cluster="Compress PDF"; PageType="Pillar/Hub"; URL=$ratpdfPages.CompressHub; BestFor="Directory listing, SaaS compare, email workflow blogs"; LinkTypes="SaaS listing, Editorial, Resource page"},
    [PSCustomObject]@{Cluster="Compress PDF"; PageType="Research"; URL=$ratpdfPages.AttachmentLimits; BestFor="Editorial cite, .edu IT help, productivity blogs"; LinkTypes="Editorial, Resource page, Blog mention"},
    [PSCustomObject]@{Cluster="Compress PDF"; PageType="Research"; URL=$ratpdfPages.CompressBench; BestFor="HN, DEV, research citations"; LinkTypes="Editorial, Blog mention"},
    [PSCustomObject]@{Cluster="Compress PDF"; PageType="Tool"; URL=$ratpdfPages.CompressTool; BestFor="Free tool directories, Q&A sites"; LinkTypes="SaaS listing, Directory"},
    [PSCustomObject]@{Cluster="Compress PDF"; PageType="Interactive"; URL=$ratpdfPages.SizeChecker; BestFor="Productivity roundups, email tips"; LinkTypes="Blog mention, Resource page"},
    [PSCustomObject]@{Cluster="PDF to Text"; PageType="Pillar"; URL=$ratpdfPages.PdfToTextHub; BestFor="Tool directories, student resource pages"; LinkTypes="Directory, Resource page"},
    [PSCustomObject]@{Cluster="PDF to Text"; PageType="Pillar"; URL=$ratpdfPages.PdfToTextHowTo; BestFor="How-to blogs, LibGuides, Q&A"; LinkTypes="Editorial, Resource page, Blog mention"},
    [PSCustomObject]@{Cluster="PDF to Text"; PageType="Tool"; URL=$ratpdfPages.PdfToTextTool; BestFor="SaaS listings, developer blogs"; LinkTypes="SaaS listing, Directory"},
    [PSCustomObject]@{Cluster="PDF to Text"; PageType="Pillar"; URL=$ratpdfPages.ExtractText; BestFor="Research/library digitization guides"; LinkTypes="Resource page"},
    [PSCustomObject]@{Cluster="OCR"; PageType="Pillar"; URL=$ratpdfPages.OcrPillar; BestFor="Accessibility resources, library OCR guides"; LinkTypes="Resource page, Editorial"},
    [PSCustomObject]@{Cluster="OCR"; PageType="Tool"; URL=$ratpdfPages.OcrTool; BestFor="Tool directories, digitization communities"; LinkTypes="Directory, SaaS listing"},
    [PSCustomObject]@{Cluster="OCR"; PageType="Guide"; URL=$ratpdfPages.OcrGuide; BestFor="Gov accessibility, WebAIM-style resources"; LinkTypes="Resource page, Editorial"},
    [PSCustomObject]@{Cluster="OCR"; PageType="Pillar"; URL=$ratpdfPages.ScannedPdf; BestFor="University scan workflows, fax archive guides"; LinkTypes="Resource page, Blog mention"}
)
$mapping | Export-Csv -Path (Join-Path $outDir "backlink-content-mapping.csv") -NoTypeInformation -Encoding UTF8

# Master combined export
$master = @()
foreach ($r in $listingRows) {
    $master += [PSCustomObject]@{
        Id = "L-$($r.Id)"
        Category = "Free listing"
        Cluster = ""
        TargetType = $r.ListingType
        Domain = $r.Domain
        TargetUrl = $r.SubmitUrl
        DR_Est = $r.DR_Est
        Cost = $r.Cost
        RatPDF_Page = $r.RatPDF_Page
        Anchor_Text = $r.SuggestedAnchor
        Pitch = $r.Notes
        Priority = $r.Priority
        Status = $r.Status
    }
}
foreach ($r in $highValue) {
    $master += [PSCustomObject]@{
        Id = "H-$($r.Id)"
        Category = "High value"
        Cluster = $r.Cluster
        TargetType = $r.TargetType
        Domain = $r.Domain
        TargetUrl = $r.TargetUrl
        DR_Est = $r.DR_Est
        Cost = $r.Cost
        RatPDF_Page = $r.RatPDF_Page
        Anchor_Text = $r.Anchor_Text
        Pitch = $r.Pitch
        Priority = $r.Priority
        Status = $r.Status
    }
}
$master | Export-Csv -Path (Join-Path $outDir "backlink-master.csv") -NoTypeInformation -Encoding UTF8

Write-Host "Generated:"
Write-Host "  backlink-free-listings.csv: $($listingRows.Count) rows"
Write-Host "  backlink-high-value-targets.csv: $($highValue.Count) rows"
Write-Host "  backlink-content-mapping.csv: $($mapping.Count) rows"
Write-Host "  backlink-master.csv: $($master.Count) rows (TOTAL)"
