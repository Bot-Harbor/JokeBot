using DSharpPlus.Entities;

namespace JokeBot.DSharpPlus.App.Embeds;

public class ErrorEmbed
{
    public DiscordEmbedBuilder CommandFailedEmbedBuilder(string error)
    {
        var embed = new DiscordEmbedBuilder()
        {
            Title = $"⚠️ • Command failed to execute due to ``{error}`` !",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
    
    public DiscordEmbedBuilder CommandFailedEmbedBuilder(Exception error)
    {
        var embed = new DiscordEmbedBuilder()
        {
            Title = $"⚠️ • Command failed to execute due to ``{error}`` !",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
    
    public DiscordEmbedBuilder NoFiltersEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Title = "😔  •  There are no filters to view at this time. Please try again later.",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
    
    public DiscordEmbedBuilder NoJokesEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Title = "😔  •  Could not access your blacklist filters to get a joke. Please try again later.",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
    
    public DiscordEmbedBuilder ChangingFiltersFailedEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Title = "😔  •  Failed to change filters. Please try again later.",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
    
    public DiscordEmbedBuilder IncorrectPasswordEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Title = "🚫  •  Incorrect password! Please try again.",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }

    public DiscordEmbedBuilder IncorrectTimeFormatEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Title = "🚫  •  Incorrect format! Please use the 24-hr format \"HH:mm\".",
            Color = DiscordColor.Red,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
}