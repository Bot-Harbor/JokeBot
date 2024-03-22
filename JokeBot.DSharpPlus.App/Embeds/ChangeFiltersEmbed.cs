using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace JokeBot.DSharpPlus.App.Embeds;

public class ChangeFiltersEmbed
{
    public DiscordEmbedBuilder ChangeFiltersEmbedBuilder(InteractionContext context)
    {
        var embed = new DiscordEmbedBuilder
        {
            Description = $"🙌  -  {context.Guild.Name}'s joke filters have been changed!",
            Color = DiscordColor.Yellow,
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
}