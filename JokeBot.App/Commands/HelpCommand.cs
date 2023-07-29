using Discord.Commands;

namespace JokeBot.Commands;

public class HelpCommand : CommandBase
{
    [Command("help")]
    public async Task HandleCommandAsync()
    {
        await ReplyAsync($"**The following commands can be used for Joke Bot:**{Environment.NewLine}" +
                         $"  • **ping** - Pings the Discord channel{Environment.NewLine}" +
                         $"  • **any** - Displays any kind of joke{Environment.NewLine}" +
                         $"  • **programming** - Displays a programming joke{Environment.NewLine}" +
                         $"  • **dark** - Displays dark humor joke{Environment.NewLine}" +
                         $"  • **pun** - Displays a pun{Environment.NewLine}" +
                         $"  • **spooky** - Displays a spooky joke{Environment.NewLine}" +
                         $"  • **christmas** - Displays a christmas joke{Environment.NewLine}" +
                         $"  • **misc** - Displays a miscellaneous joke{Environment.NewLine}");
    }
}