import re
from pathlib import Path

text = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave45.cs"
blocks = re.findall(r'private const string \w+ = """(.*?)""";', text.read_text(encoding="utf-8"), re.S)
counts = [len(re.sub(r"<[^>]+>", " ", b).split()) for b in blocks]
print(f"guides={len(blocks)} min={min(counts)} max={max(counts)} avg={sum(counts)//len(counts)}")
