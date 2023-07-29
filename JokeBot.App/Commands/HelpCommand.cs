﻿using Discord.Commands;
using JokeBot.Interfaces;

namespace JokeBot.Commands;

public class HelpCommand : CommandBase, ICommandHandler
{
    [Command("help")]
    public async Task HandleCommandAsync()
    {
        await ReplyAsync($"**The following commands can be used for Joke Bot:**{Environment.NewLine}" +
                         $"  • **ping** - Pings the Discord channel{Environment.NewLine}" +
                         $"  • **programming** - Displays a programming joke{Environment.NewLine}" +
                         $"  • **misc** - Displays a miscellaneous joke{Environment.NewLine}");
    }
}