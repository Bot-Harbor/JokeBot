using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class SpookyJokeCommand : ApplicationCommandModule
{
    [SlashCommand("spooky", "Gives you a spooky joke.")]
    public async Task SpookyJokeCommandAsync(InteractionContext context)
    {
        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Spooky"));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.NoJokesEmbedBuilder());
        }
    }
}