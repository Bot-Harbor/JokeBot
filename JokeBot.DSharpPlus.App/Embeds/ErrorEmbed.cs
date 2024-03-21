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
    
    public DiscordEmbedBuilder CommandFailedEmbedBuilder(Exception error)
    {
        var embed = new DiscordEmbedBuilder()
        {
            Description = $"⚠️ • Command failed to execute due to ``{error}`` !",
            Color = DiscordColor.Red
        };

        return embed;
    }
    
    public DiscordEmbedBuilder NoFiltersEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Title = "There are no filters to view at the moment. Please try again later.",
            Color = DiscordColor.Red 
        };

        return embed;
    }
    
    public DiscordEmbedBuilder NoJokesEmbedBuilder()
    {
        var embed = new DiscordEmbedBuilder
        {
            Title = "😔  -  No jokes could be found at this time.",
            Color = DiscordColor.Red 
        };

        return embed;
    }
}