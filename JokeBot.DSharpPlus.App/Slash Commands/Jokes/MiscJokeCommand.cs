using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class MiscJokeCommand : ApplicationCommandModule
{
    [SlashCommand("misc", "Gives you a miscellaneous joke.")]
    public async Task MiscJokeCommandAsync(InteractionContext context)
    {
        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Misc"));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.NoJokesEmbedBuilder());
        }
    }
}