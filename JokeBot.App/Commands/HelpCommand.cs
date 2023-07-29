using Discord.Commands;

namespace JokeBot.Commands;

public class HelpCommand : CommandBase
{
    [Command("help")]
    public async Task Ping()
    {
        await ReplyAsync($"**The following commands can be used for Joke Bot:**{Environment.NewLine}" +
                         $"  • **ping** - Pings the Discord channel{Environment.NewLine}" +
                         $"  • **joke** - Displays either a single or two-part joke{Environment.NewLine}");
    }
}