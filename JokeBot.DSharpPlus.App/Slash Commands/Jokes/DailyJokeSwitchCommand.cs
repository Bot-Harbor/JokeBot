using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JamJunction.App.Embed_Builders;
using JokeBot.DSharpPlus.App.Embeds;
using JokeBot.DSharpPlus.App.Events;
using JokeBot.DSharpPlus.App.Secrets;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class DailyJokeSwitchCommand : ApplicationCommandModule
{
    public static bool IsActive { get; set; } = false;

    [SlashCommand("dailyjoke", "Turns on and off the daily joke. For Joke Bot creators only.")]
    public async Task DailyJokeCommandAsync(InteractionContext context,
        [Option("password", "Please enter the password to access command.")]
        string password,
        [Option("control", "Turn on or off")] bool control)
    {
        var dailyJokeSwitchEmbed = new DailyJokeSwitchEmbed();
        var errorEmbed = new ErrorEmbed();
        try
        {
            if (password == Discord.DailyJokePassword)
            {
                if (control)
                {
                    IsActive = true;
                    DailyJoke.SendDailyJoke(context);
                    await context.CreateResponseAsync(dailyJokeSwitchEmbed.DailyJokeOnEmbedBuilder());
                }
                else
                {
                    IsActive = false;
                    await context.CreateResponseAsync(dailyJokeSwitchEmbed.DailyJokeOffEmbedBuilder());
                }
            }
            else
            {
                await context.CreateResponseAsync(errorEmbed.IncorrectPasswordEmbedBuilder());
            }
        }
        catch (Exception e)
        {
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message), true);
        }
    }
}