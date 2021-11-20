namespace DisCatSharpProject.Bot.Commands;
internal class ServerCommands : ApplicationCommandsModule
{
    [SlashCommand("ping", "Retrieve server ping")]
    public async Task Ping(InteractionContext context)
    {
        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
            new DiscordInteractionResponseBuilder()
                .AsEphemeral(true)
                .WithContent("Retrieving ping, please wait"));

        await context.Channel.SendMessageAsync($"Pong: `{context.Client.Ping}");
    }

    [SlashCommand("about", "DisCatSharpHostedBot info")]
    public async Task About(InteractionContext context)
    {
        await context.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

        var owner = context.Client.CurrentApplication.Owners.Count() > 1
            ? context.Client.CurrentApplication.TeamName
            : context.Client.CurrentApplication.Team.Owner.Username;

        var embed = new DiscordEmbedBuilder()
            .WithAuthor(context.Client.CurrentUser.UsernameWithDiscriminator, null, context.Client.CurrentUser.AvatarUrl)
            .WithTitle($"Information about {context.Client.CurrentUser.Username}")
            .WithTitle($"The Owner of the DisCatSharpHostedBot is {owner}")
            .AddField("Number of Guilds:", $"'{context.Client.Guilds.Count}'", true)
            .AddField("Number of Commands:", $"'{context.Client.GetApplicationCommands().RegisteredCommands.First().Value.Count}'", true)
            .AddField("The Dev(s):", string.Join(", ",
                context.Client.CurrentApplication.Team.Members.Select(x => $"{x.User.Mention}")))
            .AddField("Library:", "This DisCatSharpHostedBot was written in C# using the " +
                $"{Formatter.MaskedUrl(context.Client.BotLibrary, new Uri("https://github.com/Aiko-IT-Systems/DisCatSharp"))} " +
                $"Library. \n The Template for this DisCatSharpHostedBot can be found {Formatter.MaskedUrl("here", new Uri("https://github.com/Aiko-IT-Systems/DisCatSharp.ProjectTemplates"))}.")
            .WithTimestamp(DateTime.Now)
            .WithColor(DiscordColor.Azure);

        await context.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embed));
    }
}
