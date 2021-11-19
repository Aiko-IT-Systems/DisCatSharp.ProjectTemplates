﻿using DisCatSharp.Hosting.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DisCatSharpHostedBot;
public static class DisCatSharpHostedBotServiceCollectionExtensions
{
    /// <summary>
    /// Include DisCatSharpHostedBot's configuration file
    /// </summary>
    /// <param name="config"></param>
    /// <returns>Reference to <paramref name="config"/> for chaining purposes</returns>
    public static IConfigurationBuilder AddDisCatSharpHostedBotConfiguration(this IConfigurationBuilder config)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DisCatSharpHostedBot.settings.json");        
        config.AddJsonFile(path);
        return config;
    }

    /// <summary>
    /// Add DisCatSharpHostedBot into the Dependency Injection Pipeline
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDisCatSharpHostedBotServices(this IServiceCollection services)
    {
        services.AddDiscordHostedService<IDisCatSharpHostedBot, DisCatSharpHostedBot>();
        return services;
    }

    /// <summary>
    /// Register all commands from this project automatically
    /// </summary>
    /// <param name="commands"></param>
    /// <param name="guildId">Optional GuildID to provide</param>
    /// <returns>Lits of command classes that were registered</returns>
    public static List<string> RegisterApplicationCommandsFromAssembly(this ApplicationCommandsExtension commands, ulong? guildId = null)
    {
        var results = Assembly.GetExecutingAssembly()
                        .DefinedTypes
                        .Where(x => !x.IsAbstract && !x.IsInterface && x.IsAssignableTo(typeof(ApplicationCommandsModule)))
                        .ToList();

        foreach (var type in results)
            if (guildId.HasValue)
                commands.RegisterCommands(type, guildId);
            else
                commands.RegisterCommands(type);

        return results.Select(x => x.Name).ToList();
    }
}
