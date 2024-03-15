using DSharpPlus.Entities;

namespace JokeBot.DSharpPlus.App.Embeds;

public class ErrorEmbed
{
    public DiscordEmbedBuilder CommandFailedEmbedBuilder(string error)
    {
        var embed = new DiscordEmbedBuilder()
        {
            Description = $"⚠️ • Command failed to execute due to ``{error}`` !",
            Color = DiscordColor.Red
        };

        return embed;
    }
}