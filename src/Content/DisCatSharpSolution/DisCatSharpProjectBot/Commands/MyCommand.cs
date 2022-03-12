namespace DisCatSharpProject.Bot.Commands;
public class MyCommand : ApplicationCommandsModule
{
    [SlashCommandGroup("my_command", "This is description of the command group")]
    public class MyCommandGroup : ApplicationCommandsModule
    {
        [SlashCommand("first", "This is description of the command")]
        public async Task MySlashCommand(InteractionContext context)
        {
            await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            {
                Content = "This is first subcommand."
            });
        }

        [SlashCommand("second", "This is description of the command")]
        public async Task MySecondCommand(InteractionContext context, [Option("value", "Some string value.")] string value)
        {
            await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            {
                Content = "This is second subcommand. The value was " + value
            });
        }
    }
}
