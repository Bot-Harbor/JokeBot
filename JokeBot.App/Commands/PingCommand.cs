using Discord.Commands;
using JokeBot.Interfaces;

namespace JokeBot.Commands;

public class PingCommand : CommandBase, ICommandHandler
{
    [Command("ping")]
    public async Task HandleCommandAsync()
    {
        await ReplyAsync("Pinging to server...");
    }
}