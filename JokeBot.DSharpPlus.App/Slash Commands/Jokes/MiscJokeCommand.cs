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
            var thumbnail = "https://icons.iconarchive.com/icons/tribalmarkings/colorflow/256/miscellaneous-icon.png";
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Misc",
                DiscordColor.Gray, thumbnail));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message), true);
        }
    }
}