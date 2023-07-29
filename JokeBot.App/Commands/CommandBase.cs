using Discord.Commands;
using RestSharp;

namespace JokeBot.Commands;

public abstract class CommandBase : ModuleBase<SocketCommandContext>
{
    protected RestClient RestClient { get; set; }
    protected RestRequest Request { get; set; }

    protected string Mention => Context.Message.Author.Mention;
}