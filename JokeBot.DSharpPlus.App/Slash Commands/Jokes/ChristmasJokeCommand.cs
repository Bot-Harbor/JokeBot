using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class ChristmasJokeCommand : ApplicationCommandModule
{
    [SlashCommand("christmas", "Gives you a christmas joke.")]
    public async Task ChristmasJokeCommandAsync(InteractionContext context)
    {
        try
        {
            var jokeEmbed = new JokeEmbed();
            var thumbnail = "https://styles.redditmedia.com/t5_2vlkk/styles/communityIcon_l05g9fzm81m01.png";
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Christmas",
                DiscordColor.Green, thumbnail));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.NoJokesEmbedBuilder());
        }
    }
}