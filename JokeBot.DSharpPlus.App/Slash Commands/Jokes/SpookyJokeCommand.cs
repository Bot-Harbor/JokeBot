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
            var thumbnail = "https://cdn-icons-png.flaticon.com/128/12554/12554074.png";
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Spooky",
                DiscordColor.Orange, thumbnail));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message));
        }
    }
}