using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class DarkJokeCommand : ApplicationCommandModule
{
    [SlashCommand("dark", "Gives you a dark joke.")]
    public async Task DarkJokeCommandAsync(InteractionContext context)
    {
        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Dark"));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.NoJokesEmbedBuilder());
        }
    }
}