using Discord.Commands;

namespace JokeBot.Commands;

public class PingCommand : CommandBase
{
    [Command("ping")]
    public async Task HandleCommandAsync()
    {
        await ReplyAsync("Pinging to server...");
    }
}