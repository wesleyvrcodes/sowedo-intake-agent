# Toelichting — SOWEDO Intake Agent

## Wat ik gebouwd heb

Een AI-chatbot die intake gesprekken voert met potentiële klanten van SOWEDO. De agent stelt stap voor stap vragen over het bedrijf, de pijnpunten en wat ze willen bereiken met AI. Na het gesprek genereert hij automatisch een gestructureerde analyse met scores en aanbevelingen.

Daarnaast is er een Lead Dashboard (`/dashboard`) waar alle afgeronde intakes binnenkomen, gesorteerd op lead score. Zo zie je in één oogopslag welke leads het meest kansrijk zijn.

## Tech stack & tools

- **Blazor Server (.NET 8)** — real-time UI met SignalR, geen losse frontend nodig
- **OpenRouter API** (GPT-4o-mini) — snel, goedkoop, prima kwaliteit voor intake gesprekken
- **Streaming responses** — antwoorden komen woord voor woord binnen, voelt veel natuurlijker
- **AI tools gebruikt**: Claude voor het bouwen

## Bewuste keuzes

- **Blazor Server i.p.v. een SPA framework** — één codebase, C# end-to-end, sneller te bouwen. Voor een PoC is dit ideaal.
- **In-memory storage** — geen database opgezet. Voor een proof of concept is dit prima; bij productie zou ik een database toevoegen.
- **GPT-4o-mini via OpenRouter** — goede balans tussen kwaliteit en kosten. OpenRouter maakt het makkelijk om later van model te wisselen zonder code aan te passen.
- **Gestructureerde JSON output via prompt** — de agent sluit het gesprek af met een JSON samenvatting die automatisch geparsed wordt. Simpel en effectief.

## Veiligheid

- **API keys** staan in `appsettings.Development.json` (git-ignored) of als environment variable — nooit hardcoded in broncode
- **Server-side input validatie** — maximaal 2000 karakters per bericht, ook als je de client-side check omzeilt
- **Rate limiting** — max 15 berichten per sessie + 3 seconden cooldown tussen berichten
- **Prompt injection bescherming** — system prompt instrueert de agent om manipulatiepogingen te negeren
- **HTTPS redirect** in productie + HSTS headers

## Wat ik zou verbeteren met meer tijd

- **Persistente opslag** — SQLite of PostgreSQL zodat intakes een restart overleven
- **Authenticatie** op het dashboard — nu kan iedereen bij `/dashboard`
- **Export functionaliteit** — intakes als PDF of CSV downloaden
- **Robuustere prompt injection bescherming** — input filtering naast de prompt-instructies
- **Gespreksgeschiedenis** terugkijken vanuit het dashboard (de transcripts worden al opgeslagen, alleen de UI mist nog)
