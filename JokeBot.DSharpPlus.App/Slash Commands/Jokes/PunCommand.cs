using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class PunCommand : ApplicationCommandModule
{
    [SlashCommand("pun", "Gives you a pun.")]
    public async Task PunCommandAsync(InteractionContext context)
    {
        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Pun"));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.NoJokesEmbedBuilder());
        }
    }
}