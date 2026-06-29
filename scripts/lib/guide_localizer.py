#!/usr/bin/env python3
"""Build unique localized guide HTML — intros, FAQs, tips, links, schema."""
from __future__ import annotations

import re
from datetime import datetime, timezone
from html import escape

from lib.slug_paragraphs import build_slug_paragraphs, build_checklist_html, pick_unique_expansions
from lib.category_infer import infer_category, slug_hash
from lib.content_bank import load_intros, pick_faqs, pick_intro, pick_tips, section_labels
from lib.related_guide_finder import find_related, localized_href
from lib.schema_injector import build_schema_graph, render_schema_script
from lib.uniqueness_checker import strip_html, word_count
from localization_locales import LOCALES, PHRASES, SLUG_KEYWORDS

SITE_URL = "https://ratpdf.com"
MIN_WORDS = 750


def infer_keyword(slug: str, locale_key: str) -> str:
    kw_map = SLUG_KEYWORDS[locale_key]
    slug_lower = slug.lower()
    for prefix in sorted(kw_map.keys(), key=len, reverse=True):
        if prefix == "default":
            continue
        if prefix in slug_lower:
            return kw_map[prefix]
    return kw_map["default"]


def apply_phrases(text: str, locale_key: str) -> str:
    for en, loc in PHRASES.get(locale_key, []):
        text = text.replace(en, loc)
    return text


def build_meta_title(keyword: str, benefit: str, locale_key: str) -> str:
    """Keyword-first title, max 60 chars."""
    kw = keyword[0].upper() + keyword[1:] if keyword else keyword
    candidates = [
        f"{kw} - {benefit} | RatPDF",
        f"{kw}: {benefit} | RatPDF",
    ]
    for c in candidates:
        if len(c) <= 60:
            return c
    short = f"{kw} | RatPDF"
    return short[:60]


def build_meta_description(keyword: str, locale_key: str, step_count: int = 3) -> str:
    templates = {
        "pt-BR": f"Aprenda como {keyword} em {step_count} passos simples. Guia gratuito no navegador com RatPDF — rápido e sem instalar.",
        "es": f"Aprende cómo {keyword} en {step_count} pasos simples. Guía gratis en el navegador con RatPDF — rápido y sin instalar.",
        "de": f"{keyword} in {step_count} einfachen Schritten. Kostenlose Browser-Anleitung mit RatPDF — schnell und ohne Installation.",
        "id": f"Pelajari cara {keyword} dalam {step_count} langkah mudah. Panduan gratis di browser dengan RatPDF — cepat tanpa instalasi.",
        "fr": f"Apprenez à {keyword} en {step_count} étapes simples. Guide gratuit dans le navigateur avec RatPDF — rapide sans installation.",
    }
    text = templates.get(locale_key, templates["es"])
    return text[:155]


def extract_or_build_steps(guide: dict, locale_key: str) -> list[str]:
    keyword = infer_keyword(guide["slug"], locale_key)
    category = infer_category(guide["slug"], guide.get("toolUrl"))
    variants = _step_variants(locale_key, category, keyword, guide.get("toolUrl"))
    if variants:
        idx = slug_hash(guide["slug"], "steps") % len(variants)
        return list(variants[idx])

    english = guide.get("howToSteps") or []
    if english:
        localized = _localize_english_steps(english, locale_key, keyword)
        if localized:
            return localized[:6]

    fallbacks = {
        "pt-BR": [
            f"Abra a ferramenta RatPDF para {keyword}.",
            "Envie o arquivo PDF e aguarde o processamento no navegador.",
            "Escolha o nível Recomendado e inicie a compressão ou conversão.",
            "Revise o resultado na pré-visualização antes de baixar.",
            "Baixe o arquivo final e confira tamanho ou conteúdo.",
            "Arquive o original e envie a cópia processada ao destinatário.",
        ],
        "es": [
            f"Abre la herramienta RatPDF para {keyword}.",
            "Sube el archivo PDF y espera el procesamiento en el navegador.",
            "Elige el nivel Recomendado e inicia la compresión o conversión.",
            "Revisa el resultado en la vista previa antes de descargar.",
            "Descarga el archivo final y verifica tamaño o contenido.",
            "Archiva el original y envía la copia procesada al destinatario.",
        ],
        "de": [
            f"Öffnen Sie das RatPDF-Tool für {keyword}.",
            "Laden Sie die PDF-Datei hoch und warten Sie auf die Verarbeitung.",
            "Wählen Sie die empfohlene Stufe und starten Sie die Verarbeitung.",
            "Prüfen Sie das Ergebnis in der Vorschau vor dem Download.",
            "Laden Sie die finale Datei herunter und kontrollieren Sie Größe oder Inhalt.",
            "Archivieren Sie das Original und senden Sie die bearbeitete Kopie.",
        ],
        "id": [
            f"Buka alat RatPDF untuk {keyword}.",
            "Unggah file PDF dan tunggu pemrosesan di browser.",
            "Pilih level yang disarankan dan mulai pemrosesan.",
            "Tinjau hasil di pratinjau sebelum mengunduh.",
            "Unduh file final dan periksa ukuran atau isi.",
            "Arsipkan asli dan kirim salinan yang sudah diproses.",
        ],
        "fr": [
            f"Ouvrez l'outil RatPDF pour {keyword}.",
            "Téléversez le PDF et attendez le traitement dans le navigateur.",
            "Choisissez le niveau recommandé et lancez le traitement.",
            "Vérifiez le résultat dans l'aperçu avant de télécharger.",
            "Téléchargez le fichier final et contrôlez taille ou contenu.",
            "Archivez l'original et envoyez la copie traitée au destinataire.",
        ],
    }
    return fallbacks.get(locale_key, fallbacks["es"])[:6]


def _localize_english_steps(steps: list[str], locale_key: str, keyword: str) -> list[str]:
    """Map common English step patterns to locale-native phrasing."""
    patterns: dict[str, list[tuple[str, str]]] = {
        "pt-BR": [
            ("upload", "Envie o documento na ferramenta RatPDF para {keyword}."),
            ("open", "Abra a ferramenta RatPDF para {keyword}."),
            ("choose", "Escolha o nível Recomendado (ou o adequado ao portal)."),
            ("select", "Selecione as páginas ou opções necessárias para {keyword}."),
            ("start", "Inicie o processamento e aguarde a barra de progresso."),
            ("process", "Aguarde o processamento no navegador — não feche a aba."),
            ("download", "Baixe o arquivo final e confira tamanho ou conteúdo."),
            ("verify", "Verifique o resultado na pré-visualização antes de enviar."),
            ("save", "Salve uma cópia com sufixo descritivo no nome do arquivo."),
            ("email", "Anexe o PDF processado ao e-mail ou portal de destino."),
        ],
        "es": [
            ("upload", "Sube el documento en la herramienta RatPDF para {keyword}."),
            ("open", "Abre la herramienta RatPDF para {keyword}."),
            ("choose", "Elige el nivel Recomendado (o el adecuado al portal)."),
            ("download", "Descarga el archivo final y verifica tamaño o contenido."),
        ],
        "de": [
            ("upload", "Laden Sie das Dokument in RatPDF für {keyword} hoch."),
            ("open", "Öffnen Sie das RatPDF-Tool für {keyword}."),
            ("download", "Laden Sie die finale Datei herunter und prüfen Sie die Größe."),
        ],
        "id": [
            ("upload", "Unggah dokumen di RatPDF untuk {keyword}."),
            ("open", "Buka alat RatPDF untuk {keyword}."),
            ("download", "Unduh file final dan periksa ukuran atau isi."),
        ],
        "fr": [
            ("upload", "Téléversez le document dans RatPDF pour {keyword}."),
            ("open", "Ouvrez l'outil RatPDF pour {keyword}."),
            ("download", "Téléchargez le fichier final et vérifiez la taille."),
        ],
    }
    mapping = patterns.get(locale_key, patterns["pt-BR"])
    out: list[str] = []
    for step in steps[:6]:
        lower = step.lower()
        matched = False
        for token, template in mapping:
            if token in lower:
                out.append(template.format(keyword=keyword))
                matched = True
                break
        if not matched:
            translated = apply_phrases(step, locale_key)
            if translated != step:
                out.append(translated)
    return out


def _step_variants(
    locale_key: str,
    category: str,
    keyword: str,
    tool_url: str | None,
) -> list[list[str]]:
    tool = tool_url or "/tools"
    variants_by_locale: dict[str, dict[str, list[list[str]]]] = {
        "pt-BR": {
            "compress": [
                [
                    f"Acesse {tool} e envie o PDF que precisa comprimir.",
                    "Escolha Menor, Recomendado ou Extremo conforme o portal de destino.",
                    "Inicie a compressão e aguarde o processamento no navegador.",
                    "Confira o tamanho final na pré-visualização.",
                    "Baixe o arquivo e teste abrir em outro dispositivo.",
                    "Envie ao destinatário e arquive o original sem compressão.",
                ],
                [
                    f"Abra a ferramenta de {keyword} no RatPDF.",
                    "Arraste o PDF ou selecione pelo explorador de arquivos.",
                    "Use Recomendado para e-mail; Extremo só se o portal ainda rejeitar.",
                    "Baixe a cópia comprimida com nome que inclua a data.",
                    "Valide se tabelas e carimbos continuam legíveis.",
                ],
            ],
            "merge": [
                [
                    f"Abra {tool} e envie os PDFs na ordem desejada.",
                    "Reordene páginas ou arquivos antes de mesclar.",
                    "Inicie a união e aguarde a geração do pacote único.",
                    "Baixe o PDF mesclado e confira a sequência de páginas.",
                    "Comprima somente se o portal exigir tamanho menor.",
                ],
            ],
            "convert": [
                [
                    f"Acesse {tool} para {keyword}.",
                    "Envie o PDF digital (não foto) sempre que possível.",
                    "Aguarde a conversão e revise tabelas no arquivo exportado.",
                    "Baixe DOCX/XLSX/PPTX e salve com versão no nome.",
                    "Exporte novamente para PDF se precisar entregar formato fixo.",
                ],
            ],
        },
    }
    locale_variants = variants_by_locale.get(locale_key, {})
    return locale_variants.get(category, locale_variants.get("compress", []))


def pick_expansions(locale_key: str, slug: str, category: str) -> list[str]:
    data = load_intros(locale_key)
    pool = data.get("category_expansions", {}).get(
        category, data.get("category_expansions", {}).get("convert", [])
    )
    return pick_unique_expansions(locale_key, slug, category, pool, count=3)


def benefit_phrase(locale_key: str, category: str) -> str:
    benefits = {
        "pt-BR": {"compress": "arquivos leves para e-mail", "merge": "um único PDF organizado", "split": "páginas separadas sem perder qualidade", "convert": "edição rápida no Word", "sign": "aprovação sem impressão", "protect": "documentos confidenciais seguros", "edit": "correções em minutos", "ocr": "texto pesquisável"},
        "es": {"compress": "archivos ligeros para correo", "merge": "un solo PDF ordenado", "split": "páginas separadas sin perder calidad", "convert": "edición rápida en Word", "sign": "aprobación sin imprimir", "protect": "documentos confidenciales seguros", "edit": "correcciones en minutos", "ocr": "texto buscable"},
        "de": {"compress": "leichte Dateien per E-Mail", "merge": "ein geordnetes PDF", "split": "getrennte Seiten ohne Qualitätsverlust", "convert": "schnelle Bearbeitung in Word", "sign": "Freigabe ohne Druck", "protect": "sichere vertrauliche Dokumente", "edit": "Korrekturen in Minuten", "ocr": "durchsuchbarer Text"},
        "id": {"compress": "file ringan untuk email", "merge": "satu PDF rapi", "split": "halaman terpisah tanpa rugi kualitas", "convert": "edit cepat di Word", "sign": "persetujuan tanpa cetak", "protect": "dokumen rahasia aman", "edit": "perbaikan dalam menit", "ocr": "teks dapat dicari"},
        "fr": {"compress": "fichiers légers par e-mail", "merge": "un PDF unique ordonné", "split": "pages séparées sans perte de qualité", "convert": "édition rapide dans Word", "sign": "validation sans impression", "protect": "documents confidentiels sécurisés", "edit": "corrections en minutes", "ocr": "texte recherchable"},
    }
    return benefits.get(locale_key, benefits["es"]).get(category, benefits[locale_key]["convert"])


def tool_cta_label(tool_url: str | None, locale_key: str) -> str:
    loc = LOCALES[locale_key]
    return loc["cta_browse_tools"] if not tool_url else loc["cta_free_tool"]


def build_body_html(
    *,
    locale_key: str,
    url_prefix: str,
    slug: str,
    keyword: str,
    category: str,
    h1: str,
    intro: str,
    steps: list[str],
    faqs: list[dict],
    tips: list[str],
    expansions: list[str],
    related: list[dict],
    tool_url: str | None,
    tool_label: str,
    schema_html: str,
) -> str:
    labels = section_labels(locale_key)
    parts: list[str] = [f"<h1>{escape(h1)}</h1>", f'<p class="rp-intro">{escape(intro)}</p>']

    slug_paras = build_slug_paragraphs(locale_key, slug, category, keyword, count=5 if locale_key in ("de", "id") else 3)
    if slug_paras:
        detail_label = labels.get("detail", labels.get("context", "Detalhes"))
        parts.append(f"<h2>{escape(detail_label)}</h2>")
        for para in slug_paras:
            parts.append(f"<p>{escape(para)}</p>")

    if expansions:
        parts.append(f"<h2>{escape(labels.get('context', 'Context'))}</h2>")
        for para in expansions:
            parts.append(f"<p>{escape(para)}</p>")

    parts.append(f"<h2>{escape(labels.get('steps', 'Steps'))}</h2><ol>")
    for step in steps:
        parts.append(f"<li>{escape(step)}</li>")
    parts.append("</ol>")

    if tool_url:
        parts.append(
            f'<p class="rp-mid-cta"><a href="{escape(tool_url, quote=True)}">{escape(tool_label)}</a></p>'
        )

    parts.append(f"<h2>{escape(labels.get('faq', 'FAQ'))}</h2>")
    for faq in faqs:
        parts.append(f"<h3>{escape(faq['question'])}</h3><p>{escape(faq['answer'])}</p>")

    parts.append(f"<h2>{escape(labels.get('tips', 'Pro Tips'))}</h2><ul>")
    for tip in tips:
        parts.append(f"<li>{escape(tip)}</li>")
    parts.append("</ul>")

    parts.append(f"<h2>{escape(labels.get('related', 'Related'))}</h2><ul>")
    for rel in related:
        href = localized_href(url_prefix, rel["slug"])
        rel_kw = infer_keyword(rel["slug"], locale_key)
        title = rel_kw[0].upper() + rel_kw[1:] if rel_kw else rel["slug"]
        parts.append(f'<li><a href="{href}">{escape(title)}</a></li>')
    parts.append("</ul>")

    if tool_url:
        parts.append(
            f'<p><a href="{escape(tool_url, quote=True)}">{escape(tool_label)}</a></p>'
        )
    parts.append(f'<p><a href="/{url_prefix}/">{escape(labels.get("home", "RatPDF"))}</a></p>')

    parts.append(schema_html)
    parts.append(build_checklist_html(locale_key, slug, category, keyword))
    return "\n".join(parts)


def pad_to_min_words(html: str, locale_key: str, category: str, slug: str, keyword: str) -> str:
    if word_count(html) >= MIN_WORDS:
        return html

    from lib.slug_paragraphs import PADDING_TEMPLATES, _extract_scenario, _extract_vertical, _vertical_label

    labels = section_labels(locale_key)
    extra_label = labels.get("extra", "Boas práticas")
    used_paras = {strip_html(p) for p in re.findall(r"<p>(.*?)</p>", html, flags=re.S)}
    templates = PADDING_TEMPLATES.get(locale_key, PADDING_TEMPLATES["pt-BR"])
    vertical = _vertical_label(locale_key, _extract_vertical(slug, locale_key))
    scenario = _extract_scenario(slug, locale_key)
    slug_label = slug.replace("-", " ")
    idx = 0
    section = 0
    while word_count(html) < MIN_WORDS and idx < len(templates) * 4:
        tpl = templates[(slug_hash(slug, f"pad{idx}") + idx) % len(templates)]
        para = tpl.format(
            keyword=keyword,
            vertical=vertical,
            slug_label=slug_label,
            scenario=scenario,
            category=category,
        )
        plain = strip_html(f"<p>{para}</p>")
        if plain not in used_paras:
            heading = extra_label if section == 0 else f"{extra_label} ({section + 1})"
            html += f"\n<h2>{escape(heading)}</h2>\n<p>{escape(para)}</p>"
            used_paras.add(plain)
            section += 1
        idx += 1

    tip_round = 0
    while word_count(html) < MIN_WORDS and tip_round < 12:
        extra_tips = pick_tips(locale_key, f"{slug}-pad{tip_round}", category, 2)
        for tip in extra_tips:
            plain = strip_html(f"<p>{tip}</p>")
            if plain in used_paras:
                continue
            html += f"\n<p>{escape(tip)}</p>"
            used_paras.add(plain)
            if word_count(html) >= MIN_WORDS:
                break
        tip_round += 1

    return html


def localize_guide(guide: dict, locale_key: str, all_guides: list[dict] | None = None) -> dict:
    loc = LOCALES[locale_key]
    prefix = loc["url_prefix"]
    slug = guide["slug"]
    category = infer_category(slug, guide.get("toolUrl"))
    keyword = infer_keyword(slug, locale_key)
    benefit = benefit_phrase(locale_key, category)

    h1 = keyword[0].upper() + keyword[1:] if keyword else keyword
    title = build_meta_title(keyword, benefit, locale_key)
    steps = extract_or_build_steps(guide, locale_key)
    description = build_meta_description(keyword, locale_key, min(3, len(steps)))

    intro = pick_intro(locale_key, slug, keyword, category)
    faq_count = 5 if locale_key in ("de", "id") else 3
    faqs = pick_faqs(locale_key, slug, category, faq_count)
    tips = pick_tips(locale_key, slug, category, 3)
    expansions = pick_expansions(locale_key, slug, category)
    related = find_related(guide, all_guides or [guide], 3)

    tool_url = guide.get("toolUrl")
    tool_label = tool_cta_label(tool_url, locale_key)
    canonical = f"{SITE_URL}/{prefix}/guides/{slug}"

    schema_graph = build_schema_graph(
        title=title,
        description=description,
        canonical_url=canonical,
        steps=steps,
        faqs=faqs,
        locale=loc["hreflang"],
    )
    schema_html = render_schema_script(schema_graph, canonical)

    body = build_body_html(
        locale_key=locale_key,
        url_prefix=prefix,
        slug=slug,
        keyword=keyword,
        category=category,
        h1=h1,
        intro=intro,
        steps=steps,
        faqs=faqs,
        tips=tips,
        expansions=expansions,
        related=related,
        tool_url=tool_url,
        tool_label=tool_label,
        schema_html=schema_html,
    )
    body = pad_to_min_words(body, locale_key, category, slug, keyword)

    return {
        "slug": slug,
        "sourceSlug": slug,
        "locale": loc["hreflang"],
        "urlPrefix": prefix,
        "title": title,
        "description": description,
        "primaryKeyword": keyword,
        "category": guide.get("category", "PDF"),
        "contentCategory": category,
        "toolUrl": tool_url,
        "toolCtaLabel": tool_label,
        "bodyHtml": body,
        "faqQuestions": [f["question"] for f in faqs],
        "faqAnswers": [f["answer"] for f in faqs],
        "howToSteps": steps,
        "schemaGraph": schema_graph,
        "searchScore": guide.get("searchScore", 1),
        "generatedAt": datetime.now(timezone.utc).isoformat(),
        "generator": "dictionary-v2",
        "wordCount": word_count(body),
    }
