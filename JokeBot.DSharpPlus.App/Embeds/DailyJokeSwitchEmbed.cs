using DSharpPlus.Entities;

namespace JokeBot.DSharpPlus.App.Embeds;

public class DailyJokeSwitchEmbed
{
    public DiscordEmbedBuilder DailyJokeOnEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Title = "🔛  •  Daily joke has been turned on!",
            Color = DiscordColor.Green,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
    
    public DiscordEmbedBuilder DailyJokeOffEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Title = "📴  •  Daily joke has been turned off!",
            Color = DiscordColor.Black,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
}