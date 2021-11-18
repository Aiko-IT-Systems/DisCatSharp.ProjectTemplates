namespace DisCatSharpHostedBot;
public interface IDisCatSharpHostedBot : IDiscordHostedService
{
    Task<string> DoSomething(string sample);
}
