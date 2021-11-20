namespace DisCatSharpProject.Bot;
public interface IDisCatSharpProjectBot : IDiscordHostedService
{
    Task<string> DoSomething(string sample);
}
