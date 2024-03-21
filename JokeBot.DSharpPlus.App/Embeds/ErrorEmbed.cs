using DSharpPlus.Entities;

namespace JokeBot.DSharpPlus.App.Embeds;

public class ErrorEmbed
{
    public DiscordEmbedBuilder CommandFailedEmbedBuilder(string error)
    {
        var embed = new DiscordEmbedBuilder()
        {
            Description = $"⚠️ • Command failed to execute due to ``{error}`` !",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
    
    public DiscordEmbedBuilder CommandFailedEmbedBuilder(Exception error)
    {
        var embed = new DiscordEmbedBuilder()
        {
            Description = $"⚠️ • Command failed to execute due to ``{error}`` !",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
    
    public DiscordEmbedBuilder NoFiltersEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Description = "😔  -  There are no filters to view at this time. Please try again later.",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
    
    public DiscordEmbedBuilder NoJokesEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Description = "😔  -  No jokes could be found at this time. Please try again later.",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
}