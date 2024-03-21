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
            var thumbnail = "https://images.vexels.com/media/users/3/234764/isolated/lists/0783c83507b7251cfdee269b866f6d77-insect-pun-funny-badge.png";
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Pun",
                DiscordColor.Yellow, thumbnail));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.NoJokesEmbedBuilder());
        }
    }
}