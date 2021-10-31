#if (!UseNet5)
using DisCatSharp;
using DisCatSharp.ApplicationCommands;
using DisCatSharp.Entities;
#endif
using Microsoft.Extensions.Logging;

namespace DisCatSharpHostedBot.Commands
{
    internal class DependencyInjectionCommands : ApplicationCommandsModule
    {
        #region Dependency Injection

        /*
         * So the library appears to populate public properties in an ApplicationCommandsModule
         * with things registered in our ServiceProvider. 
         * 
         * Our dependency injection services are registered in DisCatSharp.Examples.Program
         * However, that class calls the extension method in BotServiceCollectionExtensions in our project here
         * to register our bot for whatever external purposes you might have, and to run it as a background service
         */

        /// <summary>
        /// I am a logger provided by DI (because I am a public prop)
        /// </summary>
        public ILogger<DependencyInjectionCommands> Logger { get; set; }

        #endregion


        [SlashCommand("test-log", "Tests the DI Logger")]
        public async Task LoggerTest(InteractionContext context)
        {
            await context.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            // This logger is available because our method signature DOES NOT have the static modifier
            Logger.LogInformation("Hey! test-log command was ran!");
            await context.EditResponseAsync(new DiscordWebhookBuilder()
                .WithContent("Check your log output!"));

        }
    }
}