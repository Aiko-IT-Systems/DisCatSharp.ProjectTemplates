# DisCatSharp.ProjectTemplates

Template pack for building DisCatSharp-based .NET applications.

## Included templates

| Template | Short name | What it creates |
| --- | --- | --- |
| DisCatSharp Bot Template | `DCSBot` | A bot class library intended to be hosted by another app |
| DisCatSharp Solution Template | `DCSSolution` | An ASP.NET Core host plus a bot project in one `.slnx` solution |
| DisCatSharp Web App Template | `DCSWebApp` | An ASP.NET Core host |

## Install

```powershell
dotnet new install DisCatSharp.ProjectTemplates
```

## Usage

Create the bot class library:

```powershell
dotnet new DCSBot -n MyBot --DiscordToken "DISCORD_TOKEN"
```

Create the hosted solution:

```powershell
dotnet new DCSSolution -n MyBot --DiscordToken "DISCORD_TOKEN"
```

Create the web app host:

```powershell
dotnet new DCSWebApp -n MyWebHost
```

To see the full parameter list for either template:

```powershell
dotnet new DCSBot --help
dotnet new DCSSolution --help
dotnet new DCSWebApp --help
```

## Available options

The bot and solution templates support these DisCatSharp module switches:

- `--UseApplicationCommands`
- `--AddTranslations` (requires `--UseApplicationCommands`)
- `--UseCommandsNext`
- `--UseCommon`
- `--UseInteractivity`
- `--UseLavalink`
- `--UseVoice`
- `--UseVoiceNatives`

The standalone `DCSWebApp` template is just the ASP.NET Core host shell, so it intentionally has no custom template options.

## Generated configuration

The bot settings file uses the current nested `DiscordConfiguration` model. The generated `DisCatSharpProjectBot.settings.json` includes:

- `Token`
- `Intents`
- `Gateway`
- `Cache`
- `Logging`

This matches the modern DisCatSharp configuration structure and keeps gateway/cache/logging settings clearly separated.

## Notes

- The solution template generates an `.slnx` solution file.
- Rider still has limited support for custom template parameters, so command-line usage is the safest path when you need template options.
