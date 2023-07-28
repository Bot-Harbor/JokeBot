using Discord.Commands;
 
namespace JokeBot.Commands;

public class PingCommand : CommandBase
{
    [Command("ping")]
    public async Task Ping()
    {
        await ReplyAsync("Pinging to server...");
    }
}