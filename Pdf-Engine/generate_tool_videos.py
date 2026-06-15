#!/usr/bin/env python3
"""
Free per-tool tutorial videos — step slides with click markers + voiceover.
Uses edge-tts + ffmpeg + Pillow. Optional real screenshots from capture_tool_screenshots.py.
"""
from __future__ import annotations

import argparse
import asyncio
import json
import math
import shutil
import subprocess
import sys
import tempfile
from pathlib import Path

from tool_tutorial_steps import Step, get_steps

if hasattr(sys.stdout, "reconfigure"):
    try:
        sys.stdout.reconfigure(encoding="utf-8", errors="replace")
        sys.stderr.reconfigure(encoding="utf-8", errors="replace")
    except Exception:
        pass


def log(msg: str) -> None:
    try:
        print(msg, flush=True)
    except UnicodeEncodeError:
        print(msg.encode("ascii", errors="replace").decode("ascii"), flush=True)


try:
    import edge_tts
except ImportError:
    print("Install: pip install edge-tts", file=sys.stderr)
    sys.exit(1)

try:
    from PIL import Image, ImageDraw, ImageFont, ImageOps
except ImportError:
    print("Install: pip install Pillow", file=sys.stderr)
    sys.exit(1)

try:
    import imageio_ffmpeg
except ImportError:
    imageio_ffmpeg = None

VOICE = "en-US-JennyNeural"
VIDEO_W, VIDEO_H = 1280, 720
FPS = 25


def find_ffmpeg() -> str:
    for name in ("ffmpeg", "ffmpeg.exe"):
        p = shutil.which(name)
        if p:
            return p
    if imageio_ffmpeg:
        return imageio_ffmpeg.get_ffmpeg_exe()
    raise RuntimeError("ffmpeg not found")


def audio_duration_seconds(path: Path) -> float:
    try:
        proc = subprocess.run([find_ffmpeg(), "-i", str(path)], capture_output=True, text=True)
        import re
        m = re.search(r"Duration:\s*(\d+):(\d+):(\d+\.?\d*)", proc.stderr)
        if m:
            h, mn, s = int(m.group(1)), int(m.group(2)), float(m.group(3))
            return max(3.0, h * 3600 + mn * 60 + s)
    except Exception:
        pass
    return 6.0


async def synthesize(text: str, out_mp3: Path) -> None:
    await edge_tts.Communicate(text, VOICE, rate="-5%").save(str(out_mp3))


def _font(size: int):
    for name in ("arial.ttf", "Arial.ttf", "segoeui.ttf", "DejaVuSans.ttf"):
        try:
            return ImageFont.truetype(name, size)
        except OSError:
            continue
    return ImageFont.load_default()


def _load_base_image(screenshot: Path | None, tool_name: str) -> Image.Image:
    if screenshot and screenshot.is_file():
        img = Image.open(screenshot).convert("RGB")
        return ImageOps.fit(img, (VIDEO_W, VIDEO_H), Image.Resampling.LANCZOS)

    # Mock tool UI when no screenshot
    img = Image.new("RGB", (VIDEO_W, VIDEO_H), (244, 245, 247))
    draw = ImageDraw.Draw(img)
    # Browser bar
    draw.rectangle([0, 0, VIDEO_W, 48], fill=(30, 64, 120))
    draw.text((16, 14), f"ratpdf.com — {tool_name}", fill=(255, 255, 255), font=_font(20))
    # Card
    mx, my = 140, 80
    mw, mh = VIDEO_W - 280, VIDEO_H - 160
    draw.rounded_rectangle([mx, my, mx + mw, my + mh], radius=16, fill=(255, 255, 255), outline=(222, 226, 230))
    draw.text((mx + 24, my + 20), tool_name, fill=(17, 24, 39), font=_font(28))
    # Drop zone
    dz_y = my + 80
    draw.rounded_rectangle([mx + 40, dz_y, mx + mw - 40, dz_y + 140], radius=12, outline=(74, 144, 226), width=2)
    draw.text((mx + mw // 2 - 80, dz_y + 55), "Drop file here", fill=(100, 116, 139), font=_font(22))
    # Button
    btn_y = dz_y + 200
    draw.rounded_rectangle([mx + 80, btn_y, mx + mw - 80, btn_y + 52], radius=8, fill=(74, 144, 226))
    draw.text((mx + mw // 2 - 60, btn_y + 14), "Process / Convert", fill=(255, 255, 255), font=_font(22))
    return img


def _draw_click_marker(draw: ImageDraw.ImageDraw, x: float, y: float, label: str, step_num: int, total: int) -> None:
    px, py = int(x * VIDEO_W), int(y * VIDEO_H)
    r = 36
    # Pulsing ring
    draw.ellipse([px - r - 8, py - r - 8, px + r + 8, py + r + 8], outline=(239, 68, 68), width=4)
    draw.ellipse([px - r, py - r, px + r, py + r], fill=(239, 68, 68))
    draw.text((px - 10, py - 10), "!", fill=(255, 255, 255), font=_font(24))
    # Label box
    lb = _font(18)
    tw = draw.textlength(label, font=lb) if hasattr(draw, "textlength") else len(label) * 10
    lx, ly = max(12, px - int(tw) // 2), max(56, py - r - 44)
    draw.rounded_rectangle([lx - 8, ly - 4, lx + int(tw) + 8, ly + 26], radius=6, fill=(239, 68, 68))
    draw.text((lx, ly), label, fill=(255, 255, 255), font=lb)
    # Step badge
    badge = f"Step {step_num} of {total}"
    draw.rounded_rectangle([12, 12, 160, 44], radius=8, fill=(30, 64, 120))
    draw.text((20, 18), badge, fill=(255, 255, 255), font=_font(18))


def make_step_slide(
    base: Image.Image,
    step: Step,
    step_num: int,
    total: int,
    tool_name: str,
) -> Image.Image:
    img = base.copy()
    draw = ImageDraw.Draw(img)
    # Bottom caption bar
    draw.rectangle([0, VIDEO_H - 72, VIDEO_W, VIDEO_H], fill=(15, 23, 42))
    caption = step.text if len(step.text) < 90 else step.text[:87] + "…"
    draw.text((20, VIDEO_H - 52), caption, fill=(226, 232, 240), font=_font(22))
    draw.text((VIDEO_W - 200, VIDEO_H - 52), "RatPDF Tutorial", fill=(148, 163, 184), font=_font(16))

    if step.marker_x is not None and step.marker_y is not None and step.click_label:
        _draw_click_marker(draw, step.marker_x, step.marker_y, step.click_label, step_num, total)
    else:
        draw.rounded_rectangle([12, 12, 200, 44], radius=8, fill=(30, 64, 120))
        draw.text((20, 18), f"Step {step_num} of {total}", fill=(255, 255, 255), font=_font(18))

    return img


def render_segment(slide: Path, audio: Path, out_mp4: Path, duration: float) -> None:
    frames = max(1, int(math.ceil(duration * FPS)))
    vf = f"scale={VIDEO_W}:{VIDEO_H}:force_original_aspect_ratio=decrease,pad={VIDEO_W}:{VIDEO_H}:(ow-iw)/2:(oh-ih)/2,fps={FPS}"
    subprocess.run(
        [
            find_ffmpeg(), "-y",
            "-loop", "1", "-i", str(slide),
            "-i", str(audio),
            "-vf", vf,
            "-c:v", "libx264", "-preset", "medium", "-crf", "23",
            "-c:a", "aac", "-b:a", "128k",
            "-pix_fmt", "yuv420p",
            "-t", f"{duration:.3f}",
            "-movflags", "+faststart",
            str(out_mp4),
        ],
        check=True,
        capture_output=True,
    )


def concat_segments(segments: list[Path], out_mp4: Path, tmp: Path) -> None:
    lst = tmp / "concat.txt"
    lst.write_text("\n".join(f"file '{s.resolve().as_posix()}'" for s in segments), encoding="utf-8")
    subprocess.run(
        [find_ffmpeg(), "-y", "-f", "concat", "-safe", "0", "-i", str(lst), "-c", "copy", str(out_mp4)],
        check=True,
        capture_output=True,
    )


def extract_poster(video: Path, poster: Path) -> None:
    subprocess.run(
        [find_ffmpeg(), "-y", "-i", str(video), "-vframes", "1", "-q:v", "2", str(poster)],
        check=True,
        capture_output=True,
    )


async def generate_one(tool: dict, web_root: Path, force: bool) -> bool:
    slug = tool["slug"]
    name = tool["name"]
    filename = tool.get("file") or f"{slug}.mp4"
    out_mp4 = web_root / "videos" / "how-to" / filename
    out_jpg = out_mp4.with_suffix(".jpg")
    slides_dir = web_root / "images" / "tutorials" / slug

    if out_mp4.is_file() and not force:
        log(f"Skip (exists): {filename}")
        return True

    steps = get_steps(tool)
    screenshot = web_root / "images" / "tutorials" / slug / "page.png"
    log(f"Generating: {name} ({len(steps)} slides)…")

    base = _load_base_image(screenshot if screenshot.is_file() else None, name)
    slides_dir.mkdir(parents=True, exist_ok=True)

    with tempfile.TemporaryDirectory() as tmp:
        tmp_path = Path(tmp)
        segments: list[Path] = []

        for i, step in enumerate(steps, start=1):
            slide_img = make_step_slide(base, step, i, len(steps), name)
            slide_jpg = slides_dir / f"step-{i}.jpg"
            slide_png = tmp_path / f"slide-{i}.png"
            slide_img.save(slide_jpg, "JPEG", quality=90)
            slide_img.save(slide_png, "PNG")

            audio = tmp_path / f"step-{i}.mp3"
            await synthesize(step.text, audio)
            dur = min(14.0, max(4.0, audio_duration_seconds(audio)))

            seg = tmp_path / f"seg-{i}.mp4"
            render_segment(slide_png, audio, seg, dur)
            segments.append(seg)

        out_mp4.parent.mkdir(parents=True, exist_ok=True)
        concat_segments(segments, out_mp4, tmp_path)
        extract_poster(out_mp4, out_jpg)

    log(f"  Saved {out_mp4} ({len(steps)} steps)")
    return True


async def main_async(args: argparse.Namespace) -> int:
    web_root = Path(args.web_root).resolve()
    manifest = json.loads(Path(args.manifest).read_text(encoding="utf-8"))
    tools = manifest["tools"]
    if args.only:
        tools = [t for t in tools if t["slug"] in set(args.only.split(","))]
    if args.limit:
        tools = tools[: args.limit]

    ok = 0
    for tool in tools:
        try:
            if await generate_one(tool, web_root, args.force):
                ok += 1
        except Exception as ex:
            log(f"  Error {tool.get('name')}: {ex}")
    log(f"Done — {ok}/{len(tools)} slide videos")
    return 0 if ok == len(tools) else 1


def main() -> None:
    p = argparse.ArgumentParser()
    p.add_argument("--web-root", required=True)
    p.add_argument("--manifest", required=True)
    p.add_argument("--only")
    p.add_argument("--limit", type=int)
    p.add_argument("--force", action="store_true")
    raise SystemExit(asyncio.run(main_async(p.parse_args())))


if __name__ == "__main__":
    main()
