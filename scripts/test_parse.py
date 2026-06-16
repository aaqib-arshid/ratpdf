from pathlib import Path
import re
text = Path(r"D:\Repos\ratpdf\Content\ContentLibrary.cs").read_text(encoding="utf-8").split("BuildBlogs")[0]
SLUG_LINE_RE = re.compile(r'^\s+\("([a-z0-9-]+)",', re.M)
TITLE_DESC_RE = re.compile(r'^\s+\("([a-z0-9-]+)",\s*"((?:[^"\\]|\\.)*)"\s*,\s*"((?:[^"\\]|\\.)*)"', re.M)
print("slug lines", len(SLUG_LINE_RE.findall(text)))
print("title desc", len(TITLE_DESC_RE.findall(text)))
print("sample slugs", SLUG_LINE_RE.findall(text)[:5])
