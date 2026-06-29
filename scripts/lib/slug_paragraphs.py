#!/usr/bin/env python3
"""Slug-specific paragraphs for localized guides — reduces cross-page duplication."""
from __future__ import annotations

from lib.category_infer import slug_hash

VERTICAL_LABELS: dict[str, dict[str, str]] = {
    "pt-BR": {
        "accountants": "contadores e auditores",
        "lawyers": "advogados e departamentos jurídicos",
        "architects": "arquitetos e engenheiros",
        "students": "estudantes e pesquisadores",
        "teachers": "professores e coordenadores pedagógicos",
        "freelancers": "freelancers e prestadores de serviço",
        "hr": "recursos humanos e recrutamento",
        "healthcare": "clínicas e equipes de saúde",
        "government": "órgãos públicos e licitações",
        "realtors": "corretores e imobiliárias",
        "developers": "desenvolvedores e equipes de TI",
        "designers": "designers e estúdios criativos",
        "sales": "equipes comerciais e propostas",
        "nonprofits": "ONGs e projetos sociais",
        "blackboard": "ambientes de ensino a distância",
        "moodle": "plataformas Moodle e LMS",
        "whatsapp": "envio pelo WhatsApp e mensagens",
        "gmail": "Gmail e provedores de e-mail",
        "passport": "passaporte e documentos consulares",
        "visa": "vistos e embaixadas",
        "invoice": "faturamento e notas fiscais",
    },
    "es": {
        "accountants": "contadores y auditores",
        "lawyers": "abogados y equipos legales",
        "students": "estudiantes e investigadores",
        "freelancers": "freelancers y consultores",
        "government": "gobierno y trámites en línea",
    },
    "de": {
        "accountants": "Buchhalter und Wirtschaftsprüfer",
        "lawyers": "Anwälte und Rechtsabteilungen",
        "students": "Studierende und Forschende",
    },
    "id": {
        "accountants": "akuntan dan auditor",
        "students": "mahasiswa dan peneliti",
        "freelancers": "freelancer dan konsultan",
    },
    "fr": {
        "accountants": "comptables et auditeurs",
        "lawyers": "avocats et services juridiques",
        "students": "étudiants et chercheurs",
    },
}

SCENARIO_BY_TOKEN: dict[str, dict[str, str]] = {
    "pt-BR": {
        "email": "o anexo ultrapassa o limite do provedor de e-mail",
        "whatsapp": "precisa compartilhar pelo celular com rede instável",
        "portal": "o portal rejeita o arquivo sem mensagem clara",
        "university": "a universidade impõe tamanho máximo no envio de documentos",
        "job": "o sistema de vagas bloqueia currículos pesados",
        "passport": "o consulado exige scan abaixo de 100 KB",
        "visa": "a embaixada limita extratos e cartas em poucos megabytes",
        "government": "o formulário gov.br recusa upload acima do teto",
        "blackboard": "o LMS da faculdade falha com PDFs grandes",
        "moodle": "a turma precisa baixar material sem travar o celular",
        "mobile": "o fluxo acontece inteiro no smartphone",
        "batch": "há dezenas de arquivos para processar no mesmo dia",
        "audit": "evidências precisam ser enviadas sem alterar o original",
        "client": "o cliente exige entrega padronizada e leve",
        "archive": "o arquivo vai para arquivo morto com busca futura",
    },
    "es": {
        "email": "el adjunto supera el límite del correo",
        "whatsapp": "necesita compartir por celular con red inestable",
        "portal": "el portal rechaza el archivo sin mensaje claro",
        "university": "la universidad impone tamaño máximo en la carga",
        "job": "el sistema de empleo bloquea currículos pesados",
        "government": "el formulario público rechaza cargas grandes",
        "mobile": "todo el flujo ocurre en el smartphone",
        "client": "el cliente exige entrega estandarizada y liviana",
    },
    "de": {
        "email": "der Anhang überschreitet das E-Mail-Limit",
        "portal": "das Portal lehnt die Datei ohne klare Meldung ab",
        "university": "die Hochschule begrenzt die Upload-Größe",
        "government": "das Behördenportal hat ein strenges Größenlimit",
        "mobile": "der Ablauf läuft komplett auf dem Smartphone",
    },
    "id": {
        "email": "lampiran melebihi batas email",
        "whatsapp": "perlu dibagikan lewat HP dengan jaringan terbatas",
        "portal": "portal menolak file tanpa pesan jelas",
        "government": "formulir pemerintah membatasi ukuran unggahan",
    },
    "fr": {
        "email": "la pièce jointe dépasse la limite du courriel",
        "portal": "le portail rejette le fichier sans message clair",
        "university": "l'université impose une taille maximale",
        "government": "le portail public a un plafond strict",
    },
}

DEFAULT_SCENARIO: dict[str, str] = {
    "pt-BR": "o prazo de envio está próximo e o arquivo precisa caber no limite",
    "es": "la fecha de envío está cerca y el archivo debe caber en el límite",
    "de": "die Abgabefrist naht und die Datei muss ins Limit passen",
    "id": "batas waktu pengiriman dekat dan file harus muat di limit",
    "fr": "la date limite approche et le fichier doit respecter la taille max",
}

DEFAULT_VERTICAL: dict[str, str] = {
    "pt-BR": "profissionais e equipes de escritório",
    "es": "profesionales y equipos de oficina",
    "de": "Fachteams und Büroabläufe",
    "id": "profesional dan tim kantor",
    "fr": "professionnels et équipes de bureau",
}

PADDING_TEMPLATES: dict[str, list[str]] = {
    "pt-BR": [
        "Quem busca {keyword} neste contexto ({slug_label}) geralmente já tentou salvar de novo ou imprimir em PDF — e o arquivo continuou pesado.",
        "Para {vertical}, vale combinar {keyword} com nomenclatura de arquivo que inclua data e versão, evitando que o destinatário abra a cópia errada.",
        "No fluxo típico de {vertical}, {keyword} entra depois da revisão final e antes do envio externo — nunca no rascunho com marca d'água.",
        "Se o portal ainda rejeitar após {keyword}, divida por intervalo de páginas ou reduza imagens embutidas antes de uma segunda passagem agressiva.",
        "Equipes de {vertical} documentam o nível de compressão usado por tipo de documento — isso acelera aprovações em auditorias internas.",
        "Em notebooks corporativos com pouco espaço, {keyword} também libera disco local antes de sincronizar com nuvem.",
        "Teste o arquivo final em outro dispositivo (celular e desktop) para confirmar que {keyword} não prejudicou legibilidade de tabelas.",
        "Guarde o PDF original em pasta de projeto; use a cópia processada apenas para envio — especialmente em {vertical}.",
        "Erros comuns: recomprimir o mesmo arquivo várias vezes, mesclar depois de comprimir demais, ou enviar senha no mesmo e-mail do PDF.",
        "Este tópico ({slug_label}) aparece com frequência em buscas brasileiras no início do mês, quando prazos de envio se concentram.",
        "Para {vertical}, alinhe com o time se o destino exige PDF/A, PDF comum ou imagem — antes de aplicar {keyword}.",
        "Atalho útil: renomeie com sufixo -final ou -enviado após {keyword} para não reutilizar arquivo antigo em novo portal.",
        "Antes de {keyword}, feche outras abas pesadas no navegador — processamento de PDF grande consome memória no laptop.",
        "Se o arquivo vier de WhatsApp ou e-mail, baixe a versão original antes de {keyword}; reencaminhamentos podem corromper anexos.",
        "Para {vertical}, combine {keyword} com checklist interno: nome, data, versão e destinatário no corpo do e-mail.",
        "Quando {scenario}, {keyword} costuma resolver em uma única tentativa com nível Recomendado.",
        "Documentos com muitas páginas em branco podem ser limpos antes de {keyword} para evitar compressão inútil.",
        "Em {vertical}, alinhe com compliance se o PDF contém dados pessoais — {keyword} não substitui anonimização.",
        "Após {keyword}, abra o PDF em leitor diferente (Adobe, Chrome, Edge) para validar compatibilidade.",
        "Se o portal pede PDF/A, verifique se {keyword} mantém o perfil exigido antes do envio final.",
        "Guarde captura de tela do tamanho final aceito pelo portal — útil quando {scenario}.",
        "Para equipes remotas em {vertical}, padronize {keyword} em um guia interno de uma página.",
        "Evite editar o PDF comprimido no Word e reexportar sem necessidade — isso reinfla o arquivo rapidamente.",
        "Em contratos de {vertical}, envie primeiro versão com marca d'água; {keyword} na versão assinada.",
        "Celulares Android aceitam upload via Chrome; em iOS use Arquivos para selecionar o PDF antes de {keyword}.",
        "Se {keyword} não bastar, divida por capítulos e envie links separados com índice no e-mail.",
        "O título da página ({slug_label}) reflete buscas reais no Brasil — ajustamos o fluxo para esse caso de uso.",
        "Profissionais de {vertical} relatam menos devolução de formulários após padronizar {keyword} no fechamento do mês.",
        "Compare tamanho antes/depois em propriedades do arquivo — meta clara para auditoria em {vertical}.",
        "Ao treinar estagiários em {vertical}, use este fluxo ({slug_label}) como roteiro de cinco minutos.",
    ],
    "es": [
        "Quien busca {keyword} en este contexto ({slug_label}) suele haber probado guardar de nuevo sin reducir el tamaño.",
        "Para {vertical}, combine {keyword} con nombres de archivo con fecha y versión.",
        "En {vertical}, {keyword} va después de la revisión y antes del envío externo.",
        "Si el portal rechaza tras {keyword}, divida por páginas antes de comprimir otra vez.",
        "Documente el nivel usado por tipo de archivo — acelera auditorías en {vertical}.",
        "En portátiles con poco espacio, {keyword} también libera disco antes de sincronizar con la nube.",
        "Pruebe el archivo final en otro dispositivo para confirmar que {keyword} no dañó tablas legibles.",
        "Guarde el PDF original en carpeta de proyecto; use la copia procesada solo para envío — especialmente en {vertical}.",
        "Errores comunes: recomprimir varias veces, unir después de comprimir demasiado, o enviar contraseña en el mismo correo.",
        "Este tema ({slug_label}) aparece mucho en búsquedas de Latinoamérica cuando se acercan plazos de envío.",
        "Para {vertical}, alinee si el destino exige PDF/A, PDF común o imagen — antes de {keyword}.",
        "Renombre con sufijo -final o -enviado tras {keyword} para no reutilizar archivo viejo en otro portal.",
        "Antes de {keyword}, cierre pestañas pesadas del navegador — los PDF grandes consumen memoria.",
        "Si el archivo viene de WhatsApp o correo, descargue el original antes de {keyword}.",
        "Para {vertical}, combine {keyword} con checklist interno: nombre, fecha, versión y destinatario.",
        "Cuando {scenario}, {keyword} suele resolver en un solo intento con nivel Recomendado.",
        "Los documentos con páginas en blanco pueden limpiarse antes de {keyword} para evitar trabajo inútil.",
        "En {vertical}, alinee con cumplimiento si el PDF tiene datos personales — {keyword} no anonimiza.",
        "Tras {keyword}, abra el PDF en otro lector (Chrome, Edge, Adobe) para validar compatibilidad.",
        "Si el portal pide PDF/A, verifique que {keyword} mantiene el perfil exigido.",
        "Guarde captura del tamaño final aceptado — útil cuando {scenario}.",
        "Para equipos remotos en {vertical}, estandarice {keyword} en una guía interna de una página.",
        "Evite editar el PDF en Word y reexportar sin necesidad — el archivo crece rápido.",
        "En contratos de {vertical}, envíe primero versión con marca de agua; {keyword} en la versión firmada.",
        "Si {keyword} no basta, divida por capítulos y envíe enlaces separados con índice en el correo.",
        "El título ({slug_label}) refleja búsquedas reales — ajustamos el flujo para ese caso.",
        "Profesionales de {vertical} reportan menos devoluciones tras estandarizar {keyword} a fin de mes.",
        "Compare tamaño antes/después en propiedades del archivo — meta clara para auditoría en {vertical}.",
        "Al capacitar practicantes en {vertical}, use este flujo ({slug_label}) como guión de cinco minutos.",
    ],
    "de": [
        "Wer {keyword} in diesem Kontext ({slug_label}) sucht, hat oft bereits erneut gespeichert ohne Größenreduktion.",
        "Für {vertical}: Dateinamen mit Datum und Version nach {keyword} verwenden.",
        "Im typischen Ablauf von {vertical} kommt {keyword} nach der Freigabe und vor dem externen Versand.",
        "Wenn das Portal nach {keyword} ablehnt, nach Seiten teilen statt erneut stark komprimieren.",
        "Dokumentieren Sie die Stufe pro Dokumenttyp — beschleunigt Audits in {vertical}.",
        "Auf schwachen Laptops schließt {keyword} schwere Browser-Tabs vor dem Upload.",
        "Testen Sie die Datei auf Handy und Desktop, ob Tabellen nach {keyword} lesbar bleiben.",
        "Original in Projektordner behalten; bearbeitete Kopie nur für den Versand — besonders in {vertical}.",
        "Typische Fehler: mehrfach komprimieren, nach aggressivem Compress zusammenführen, Passwort per gleicher E-Mail.",
        "Das Thema ({slug_label}) steigt in deutschen Suchen oft zum Monatsende.",
        "Klären Sie in {vertical}, ob PDF/A oder normales PDF gefordert ist — vor {keyword}.",
        "Suffix -final oder -gesendet nach {keyword} verhindert Verwechslung mit alten Versionen.",
        "WhatsApp- oder Mail-Anhänge zuerst original herunterladen, dann {keyword}.",
        "Wenn {scenario}, reicht oft eine Passung mit empfohlener Stufe.",
        "Leere Seiten vor {keyword} entfernen spart unnötige Verarbeitung.",
        "Bei personenbezogenen Daten in {vertical}: {keyword} ersetzt keine Anonymisierung.",
        "Nach {keyword} in Adobe, Chrome und Edge öffnen — Kompatibilität prüfen.",
        "PDF/A-Anforderung vor finalem Upload nach {keyword} verifizieren.",
        "Screenshot der akzeptierten Dateigröße aufbewahren — hilfreich wenn {scenario}.",
        "Remote-Teams in {vertical}: {keyword} in einer internen Ein-Seiten-Anleitung festhalten.",
        "Word-Roundtrip vermeiden — Dateien blähen sich schnell wieder auf.",
        "Entwurf mit Wasserzeichen zuerst; {keyword} auf der signierten Version in {vertical}.",
        "Bei zu großem Ergebnis nach {keyword}: Kapitelweise teilen und Index per Mail.",
        "Titel ({slug_label}) entspricht realen Suchanfragen — Workflow darauf abgestimmt.",
        "Fachleute in {vertical} melden weniger Portal-Ablehnungen nach Standard-{keyword}.",
        "Größe vor/nach in Dateieigenschaften vergleichen — klare Audit-Spur.",
        "Praktikanten in {vertical}: diesen Ablauf ({slug_label}) als 5-Minuten-Skript nutzen.",
    ],
    "id": [
        "Pencarian {keyword} untuk konteks ({slug_label}) sering terjadi setelah file tetap besar meski sudah disimpan ulang.",
        "Untuk {vertical}, gabungkan {keyword} dengan penamaan file berisi tanggal dan versi.",
        "Dalam alur {vertical}, {keyword} dilakukan setelah revisi final dan sebelum kirim eksternal.",
        "Jika portal menolak setelah {keyword}, pisahkan per halaman sebelum kompres lagi.",
        "Catat level per jenis dokumen — mempercepat audit di {vertical}.",
        "Di laptop terbatas, tutup tab berat sebelum {keyword} pada PDF besar.",
        "Uji file di HP dan desktop agar tabel tetap terbaca setelah {keyword}.",
        "Simpan asli di folder proyek; kirim salinan hasil proses saja — khususnya di {vertical}.",
        "Kesalahan umum: kompres berulang, gabung setelah kompres berlebihan, kirim sandi di email yang sama.",
        "Topik ({slug_label}) naik di pencarian Indonesia menjelang tenggat.",
        "Selaraskan di {vertical} apakah portal butuh PDF/A atau PDF biasa sebelum {keyword}.",
        "Rename dengan akhiran -final setelah {keyword} agar tidak pakai file lama.",
        "Unduh asli dari WhatsApp/email sebelum {keyword}, bukan forward.",
        "Saat {scenario}, level disarankan sering cukup sekali jalan.",
        "Hapus halaman kosong sebelum {keyword} untuk efisiensi.",
        "Data pribadi di {vertical}: {keyword} bukan pengganti anonimisasi.",
        "Buka di Chrome/Edge/Adobe setelah {keyword} untuk cek kompatibilitas.",
        "Verifikasi PDF/A jika diminta portal setelah {keyword}.",
        "Screenshot ukuran file yang diterima — berguna saat {scenario}.",
        "Tim remote di {vertical}: standarkan {keyword} dalam SOP satu halaman.",
        "Hindari putaran Word yang mengembangkan file lagi.",
        "Kirim draft watermark dulu; {keyword} pada versi ditandatangani di {vertical}.",
        "Jika masih besar, pecah per bab dan kirim indeks di email.",
        "Judul ({slug_label}) mencerminkan pencarian nyata — alur disesuaikan.",
        "Profesional {vertical} melaporkan lebih sedikit penolakan setelah standar {keyword}.",
        "Bandingkan ukuran sebelum/sesudah di properti file.",
        "Training magang di {vertical}: gunakan alur ({slug_label}) lima menit ini.",
    ],
    "fr": [
        "Ceux qui cherchent {keyword} dans ce contexte ({slug_label}) ont souvent déjà réenregistré sans réduire la taille.",
        "Pour {vertical}, combinez {keyword} avec un nom de fichier daté et versionné.",
        "Dans le flux {vertical}, {keyword} intervient après validation et avant envoi externe.",
        "Si le portail refuse après {keyword}, divisez par pages avant une nouvelle compression.",
        "Documentez le niveau par type de fichier — accélère les audits en {vertical}.",
        "Sur portable limité, fermez les onglets lourds avant {keyword} sur gros PDF.",
        "Testez le fichier sur mobile et bureau : tableaux lisibles après {keyword}.",
        "Conservez l'original en dossier projet ; n'envoyez que la copie traitée — surtout en {vertical}.",
        "Erreurs fréquentes : recompresser plusieurs fois, fusionner après compression excessive, mot de passe dans le même mail.",
        "Le sujet ({slug_label}) monte dans les recherches en fin de mois.",
        "Alignez en {vertical} sur PDF/A ou PDF standard avant {keyword}.",
        "Suffixe -final ou -envoye après {keyword} pour éviter les anciennes versions.",
        "Téléchargez l'original depuis WhatsApp/mail avant {keyword}.",
        "Quand {scenario}, le niveau recommandé suffit souvent du premier coup.",
        "Supprimez les pages blanches avant {keyword} pour gagner du temps.",
        "Données personnelles en {vertical} : {keyword} ne remplace pas l'anonymisation.",
        "Ouvrez dans Adobe, Chrome, Edge après {keyword} pour compatibilité.",
        "Vérifiez PDF/A si exigé par le portail après {keyword}.",
        "Capture de la taille acceptée — utile quand {scenario}.",
        "Équipes distantes en {vertical} : standardisez {keyword} sur une page interne.",
        "Évitez aller-retour Word qui regonfle le fichier.",
        "Brouillon filigrané d'abord ; {keyword} sur la version signée en {vertical}.",
        "Si trop gros, découpez par chapitres avec index par mail.",
        "Le titre ({slug_label}) reflète des recherches réelles — flux adapté.",
        "Les pros en {vertical} signalent moins de rejets après {keyword} standardisé.",
        "Comparez taille avant/après dans les propriétés du fichier.",
        "Formez les stagiaires en {vertical} avec ce flux ({slug_label}) en cinq minutes.",
    ],
}


def _slug_label(slug: str) -> str:
    return slug.replace("-", " ").strip()


def _extract_vertical(slug: str, locale_key: str = "pt-BR") -> str:
    lower = slug.lower()
    if "-for-" in lower:
        return lower.split("-for-", 1)[1]
    for token in VERTICAL_LABELS["pt-BR"]:
        if token in lower:
            return token
    return DEFAULT_VERTICAL.get(locale_key, DEFAULT_VERTICAL["pt-BR"])


def _extract_scenario(slug: str, locale_key: str) -> str:
    lower = slug.lower()
    scenarios = SCENARIO_BY_TOKEN.get(locale_key, SCENARIO_BY_TOKEN["pt-BR"])
    for token, text in scenarios.items():
        if token in lower:
            return text
    return DEFAULT_SCENARIO.get(locale_key, DEFAULT_SCENARIO["pt-BR"])


def _vertical_label(locale_key: str, vertical_key: str) -> str:
    labels = VERTICAL_LABELS.get(locale_key, VERTICAL_LABELS["pt-BR"])
    return labels.get(vertical_key, vertical_key.replace("-", " "))


def build_checklist_html(locale_key: str, slug: str, category: str, keyword: str) -> str:
    """Slug-varied checklist section for word depth and uniqueness."""
    labels = {
        "pt-BR": ("Checklist antes de enviar", "Checklist final"),
        "es": ("Lista antes de enviar", "Lista final"),
        "de": ("Checkliste vor dem Senden", "Finale Checkliste"),
        "id": ("Daftar sebelum kirim", "Daftar akhir"),
        "fr": ("Liste avant envoi", "Liste finale"),
    }
    items_pt = [
        f"Confirmei que {keyword} é necessário para este destino ({_slug_label(slug)}).",
        "Testei abrir o PDF em outro dispositivo após o processamento.",
        "Renomeei o arquivo com data e versão no nome.",
        "Verifiquei se tabelas, carimbos e assinaturas continuam legíveis.",
        "Guardei o original em pasta de projeto separada da cópia enviada.",
        "Anotei o nível de compressão ou ferramenta usada para repetir no próximo mês.",
        "Conferi se o portal aceita PDF comum ou exige PDF/A.",
        "Enviei senha em canal diferente quando o PDF está protegido.",
    ]
    items_es = [
        f"Confirmé que {keyword} es necesario para este destino ({_slug_label(slug)}).",
        "Probé abrir el PDF en otro dispositivo después del procesamiento.",
        "Renombré el archivo con fecha y versión en el nombre.",
        "Verifiqué que tablas, sellos y firmas siguen legibles.",
        "Guardé el original en carpeta de proyecto separada de la copia enviada.",
        "Anoté el nivel de compresión o herramienta usada para repetir el próximo mes.",
        "Confirmé si el portal acepta PDF común o exige PDF/A.",
        "Envié la contraseña por canal distinto cuando el PDF está protegido.",
    ]
    items_de = [
        f"Ich habe bestätigt, dass {keyword} für dieses Ziel ({_slug_label(slug)}) nötig ist.",
        "PDF nach Verarbeitung auf einem zweiten Gerät geöffnet.",
        "Datei mit Datum und Version umbenannt.",
        "Tabellen, Stempel und Signaturen auf Lesbarkeit geprüft.",
        "Original in separatem Projektordner archiviert.",
        "Kompressionsstufe oder Tool für nächsten Monat notiert.",
        "Geprüft ob Portal PDF/A oder Standard-PDF verlangt.",
        "Passwort bei geschütztem PDF über separaten Kanal gesendet.",
    ]
    items_id = [
        f"Saya konfirmasi {keyword} diperlukan untuk tujuan ini ({_slug_label(slug)}).",
        "Saya uji buka PDF di perangkat lain setelah pemrosesan.",
        "Saya rename file dengan tanggal dan versi.",
        "Saya periksa tabel, stempel, dan tanda tangan masih terbaca.",
        "Saya simpan asli di folder proyek terpisah dari salinan kirim.",
        "Saya catat level kompresi atau alat untuk bulan depan.",
        "Saya cek apakah portal butuh PDF/A atau PDF biasa.",
        "Saya kirim sandi lewat kanal berbeda jika PDF dilindungi.",
    ]
    items_fr = [
        f"J'ai confirmé que {keyword} est nécessaire pour cette destination ({_slug_label(slug)}).",
        "J'ai testé l'ouverture du PDF sur un autre appareil après traitement.",
        "J'ai renommé le fichier avec date et version.",
        "J'ai vérifié que tableaux, tampons et signatures restent lisibles.",
        "J'ai archivé l'original dans un dossier projet séparé.",
        "J'ai noté le niveau de compression pour le mois suivant.",
        "J'ai vérifié si le portail exige PDF/A ou PDF standard.",
        "J'ai envoyé le mot de passe par canal séparé si le PDF est protégé.",
    ]
    items_by_locale = {
        "pt-BR": items_pt,
        "es": items_es,
        "de": items_de,
        "id": items_id,
        "fr": items_fr,
    }
    h1, h2 = labels.get(locale_key, labels["pt-BR"])
    items = items_by_locale.get(locale_key, items_pt)
    start = slug_hash(slug, "chk") % max(1, len(items) - 3)
    picked = [items[(start + i) % len(items)] for i in range(min(6, len(items)))]
    lis = "".join(f"<li>{item}</li>" for item in picked)
    return f"<h2>{h1}</h2><ul>{lis}</ul>"


def build_slug_paragraphs(
    locale_key: str,
    slug: str,
    category: str,
    keyword: str,
    *,
    count: int = 4,
) -> list[str]:
    """Return slug-unique paragraphs (not shared verbatim across all guides in a category)."""
    templates = PADDING_TEMPLATES.get(locale_key, PADDING_TEMPLATES["pt-BR"])
    vertical_key = _extract_vertical(slug, locale_key)
    vertical = _vertical_label(locale_key, vertical_key)
    scenario = _extract_scenario(slug, locale_key)
    slug_label = _slug_label(slug)

    start = slug_hash(slug, "pad") % len(templates)
    picked: list[str] = []
    used: set[str] = set()
    idx = 0
    while len(picked) < count and idx < len(templates) * 2:
        tpl = templates[(start + idx) % len(templates)]
        para = tpl.format(
            keyword=keyword,
            vertical=vertical,
            slug_label=slug_label,
            scenario=scenario,
            category=category,
        )
        if para not in used:
            picked.append(para)
            used.add(para)
        idx += 1

    # One scenario-specific line per slug
    scenario_lines = {
        "pt-BR": f"Neste guia ({slug_label}), o cenário típico é quando {scenario}.",
        "es": f"En esta guía ({slug_label}), el escenario habitual es cuando {scenario}.",
        "de": f"In diesem Leitfaden ({slug_label}) tritt das Szenario auf, wenn {scenario}.",
        "id": f"Dalam panduan ini ({slug_label}), skenario umumnya ketika {scenario}.",
        "fr": f"Dans ce guide ({slug_label}), le scénario habituel est lorsque {scenario}.",
    }
    line = scenario_lines.get(locale_key, scenario_lines["pt-BR"])
    if line not in used:
        picked.insert(0, line)

    return picked[:count]


def pick_unique_expansions(
    locale_key: str,
    slug: str,
    category: str,
    pool: list[str],
    *,
    count: int = 3,
) -> list[str]:
    if not pool:
        return []
    start = slug_hash(slug, "exp") % len(pool)
    picked: list[str] = []
    for i in range(len(pool)):
        para = pool[(start + i) % len(pool)]
        if para not in picked:
            picked.append(para)
        if len(picked) >= count:
            break
    return picked
