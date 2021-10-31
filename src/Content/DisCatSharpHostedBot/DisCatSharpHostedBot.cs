#if (!UseNet6)
using DisCatSharp.ApplicationCommands;
using DisCatSharp.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
#endif

namespace DisCatSharpHostedBot
{
    internal class DisCatSharpHostedBot : DiscordHostedService, IDisCatSharpHostedBot
    {
        public DisCatSharpHostedBot(IConfiguration config,
            ILogger<DisCatSharpHostedBot> logger,
            IServiceProvider provider, IHostApplicationLifetime lifetime) : base(config, logger, provider, lifetime, "DisCatSharpHostedBot")
        {
            /*
             * IF YOU DO NOT WANT TO USE THE ICONFIGURATION APPROACH
             * You can still register your extensions here
             * 
             * Do note though, the IConfiguration is basically an aggregate... you can
             * have config-based data come from numerous sources...
             * 
             * Environment variables
             * multiple json files
             * xml
             */

#if (UseApplicationCommands)
            var commandsExtension = this.Client.UseApplicationCommands(new()
            {
                Services = provider
            });
            RegisterCommands(commandsExtension);
#endif
        }

#if (UseApplicationCommands)
        /// <summary>
        /// Attempts to register commands from our DisCatSharpHostedBot Project
        /// </summary>
        void RegisterCommands(ApplicationCommandsExtension commandsExtension)
        {
            var registeredTypes = commandsExtension.RegisterApplicationCommandsFromAssembly();

            if (registeredTypes.Count == 0)
                Logger.LogInformation($"Could not locate any commands to register...");
            else
                Logger.LogInformation($"Registered the following command classes: \n\t{string.Join("\n\t", registeredTypes)}");
        }
#endif

        /// <summary>
        /// Could invoke this outside of the bot project, consume it from a web app or whoever
        /// has access to the DI pipeline
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public Task<string> DoSomething(string sample)
        {
            return Task.FromResult($"I did something with {sample}");
        }
    }
}