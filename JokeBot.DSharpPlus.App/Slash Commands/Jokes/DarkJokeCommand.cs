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
            var thumbnail = "https://styles.redditmedia.com/t5_2semr/styles/communityIcon_vl21nfr78fp81.png";
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Dark",
                DiscordColor.Black, thumbnail));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message), true);
        }
    }
}