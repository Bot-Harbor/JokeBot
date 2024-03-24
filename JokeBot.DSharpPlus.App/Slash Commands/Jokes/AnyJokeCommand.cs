using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class AnyJokeCommand : ApplicationCommandModule
{
    [SlashCommand("any", "Gives you any kind of joke.")]
    public async Task AnyJokeCommandAsync(InteractionContext context)
    {
        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Any"));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.NoJokesEmbedBuilder());
        }
    }
}