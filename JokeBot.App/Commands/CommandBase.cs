using Discord.Commands;
using RestSharp;

namespace JokeBot.Commands;

public abstract class CommandBase : ModuleBase<SocketCommandContext>
{
    protected string Mention => Context.Message.Author.Mention;
}