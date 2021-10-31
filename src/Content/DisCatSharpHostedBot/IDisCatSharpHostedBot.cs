#if (!UseNet6)
using DisCatSharp.Hosting;
#endif

namespace DisCatSharpHostedBot
{
    public interface IDisCatSharpHostedBot : IDiscordHostedService
    {
        Task<string> DoSomething(string sample);
    }
}