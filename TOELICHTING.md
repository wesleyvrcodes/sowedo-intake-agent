# Toelichting — SOWEDO Intake Agent

## Wat heb ik gebouwd?

Een chatbot die intake gesprekken voert met potentiële klanten van SOWEDO. De bot stelt vragen over het bedrijf, de problemen en wat ze willen bereiken met AI. Aan het einde krijg je automatisch een samenvatting met scores — zo weet je meteen welke leads het meest interessant zijn.

Er zit ook een dashboard bij (`/dashboard`) waar alle afgeronde gesprekken terechtkomen, gesorteerd op hoe kansrijk de lead is.

<img width="1242" height="1036" alt="Screenshot 2026-03-10 at 08 02 26" src="https://github.com/user-attachments/assets/c7fb1333-43fe-4525-a3ac-b6039eddc09a" />

## Welke tools heb ik gebruikt?

- **Claude** — voor het bouwen van de code
- **.NET Blazor** — het framework waar de app in draait
- **OpenRouter + GPT-4o-mini** — het AI-model dat de gesprekken voert

## Welke keuzes heb ik gemaakt?

- **Eén project, één taal** — alles in C#, geen losse frontend. Simpel te onderhouden.
- **Streaming antwoorden** — de bot typt woord voor woord, zoals je gewend bent van ChatGPT. Voelt veel natuurlijker dan wachten op een heel blok tekst.
- **Geen database** — gesprekken worden in het geheugen bewaard. Voor een demo is dat prima, voor productie zou je dat aanpassen.
- **GPT-4o-mini** — snel en goedkoop genoeg voor intake gesprekken. Via OpenRouter kan je makkelijk een ander model kiezen zonder iets aan te passen.

## Hoe zit het met veiligheid?

- API keys staan **niet** in de code — ze worden apart geladen en staan niet op GitHub
- Gebruikers kunnen max **2000 tekens** per bericht sturen (ook als je de frontend omzeilt)
- Max **15 berichten** per gesprek + een pauze van 3 seconden tussen berichten
- De bot negeert pogingen om hem te manipuleren (prompt injection)
- HTTPS wordt afgedwongen in productie

<img width="1918" height="957" alt="Screenshot 2026-03-10 at 08 01 46" src="https://github.com/user-attachments/assets/4ba30625-0ad3-4b3c-a80b-9762dea0b933" />

## Wat zou ik verbeteren met meer tijd?

- Een database zodat gesprekken bewaard blijven na een herstart
- Inloggen op het dashboard zodat niet iedereen erbij kan
- Gesprekken kunnen exporteren als PDF
- Een kleine chatbot zoals Sowi hoort niet op een grote pagina net zoals dit te werken, chatbots worden meestal rechtsonderin een kleine modal getoont.

## Demo

Hieronder vind u een korte demo video die Sowi (de chatbot van SOWEDO) uitlegd! 

https://files.fm/u/95d8x3dkpb#/view/ymcs5cf8p2
