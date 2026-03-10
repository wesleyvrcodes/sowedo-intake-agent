# SOWEDO Intake Agent

Blazor (.NET) intake agent voor SOWEDO. Gebruikt OpenRouter (GPT-4o-mini) voor AI-gesprekken.

## Setup

### 1. API Key configureren

De API key staat **niet** in `appsettings.json` (die is leeg/placeholder).

Maak of edit `appsettings.Development.json` in de `SowedoIntakeAgent/` map:

```json
{
  "OpenAi": {
    "ApiKey": "jouw-openrouter-api-key"
  }
}
```

Dit bestand staat in `.gitignore` en wordt **nooit** gecommit.

### 2. Alternatief: Environment variable

```bash
export OpenAi__ApiKey="jouw-openrouter-api-key"
dotnet run
```

### 3. Draaien

```bash
cd SowedoIntakeAgent
dotnet run
```

## Beveiliging

- `appsettings.Development.json` → git-ignored, bevat secrets
- `appsettings.json` → veilig om te committen, bevat geen secrets
- Gebruik **nooit** hardcoded keys in broncode
