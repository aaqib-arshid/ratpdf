"""Verify generated tool videos have video + audio streams."""
import json
import re
import subprocess
import sys
from pathlib import Path

try:
    import imageio_ffmpeg
    ffmpeg = imageio_ffmpeg.get_ffmpeg_exe()
except ImportError:
    import shutil
    ffmpeg = shutil.which("ffmpeg") or "ffmpeg"

WEB = Path(__file__).resolve().parent.parent / "wwwroot"
VIDEOS = WEB / "videos" / "how-to"
PORTRAIT = WEB / "images" / "how-to" / "presenter-portrait.jpg"
MANIFEST = Path(__file__).parent / "tools-manifest.json"


def probe(path: Path) -> dict:
    r = subprocess.run(
        [ffmpeg, "-i", str(path)],
        capture_output=True, text=True,
    )
    err = r.stderr
    has_video = "Video:" in err
    has_audio = "Audio:" in err
    dur = re.search(r"Duration:\s*(\d+:\d+:\d+\.\d+)", err)
    return {
        "video": has_video,
        "audio": has_audio,
        "duration": dur.group(1) if dur else "?",
        "size_kb": path.stat().st_size // 1024,
    }


def main() -> int:
    manifest = json.loads(MANIFEST.read_text(encoding="utf-8"))
    expected = {t["slug"] for t in manifest["tools"]}
    mp4s = list(VIDEOS.glob("*.mp4"))
    have = {p.stem for p in mp4s}

    print(f"Portrait image: {'OK' if PORTRAIT.is_file() else 'MISSING'} ({PORTRAIT})")
    print(f"Expected tools: {len(expected)} | MP4 files: {len(mp4s)}")
    missing = expected - have
    if missing:
        print("Missing MP4:", ", ".join(sorted(missing)))

    bad = []
    for p in sorted(mp4s):
        info = probe(p)
        if not info["video"] or not info["audio"] or info["size_kb"] < 200:
            bad.append((p.name, info))

    print(f"\nSample checks (first 3):")
    for p in sorted(mp4s)[:3]:
        info = probe(p)
        print(f"  {p.name}: video={info['video']} audio={info['audio']} dur={info['duration']} size={info['size_kb']}KB")

    if bad:
        print(f"\nProblem files ({len(bad)}):")
        for name, info in bad:
            print(f"  {name}: {info}")
        return 1

    print(f"\nAll {len(mp4s)} videos have video+audio streams.")
    jpgs = list(VIDEOS.glob("*.jpg"))
    print(f"Poster JPGs: {len(jpgs)}")
    return 0 if not missing else 1


if __name__ == "__main__":
    sys.exit(main())
