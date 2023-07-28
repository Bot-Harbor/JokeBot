using Discord.Commands;

namespace JokeBot.Commands;

public abstract class CommandBase : ModuleBase<SocketCommandContext>
{
    protected string Mention => Context.Message.Author.Mention;
}