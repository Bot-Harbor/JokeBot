using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace JokeBot.DSharpPlus.App.Embeds;

public class ViewFiltersEmbed
{
    public DiscordEmbedBuilder ViewFiltersEmbedBuilder(InteractionContext context, bool nsfw, bool religious,
        bool political, bool racist, bool sexist, bool dirty)
    {
        var guildName = context.Guild.Name;
        var guildIcon = context.Guild.GetIconUrl(ImageFormat.Png);
        var botThumbNail = context.Client.CurrentUser.GetAvatarUrl(ImageFormat.Png);
        var embed = new DiscordEmbedBuilder
        {
            Author = new DiscordEmbedBuilder.EmbedAuthor()
            {
                Name = guildName,
                IconUrl = guildIcon
            },
            Title = $"🚩  •  {guildName}'s Blacklist Filters",
            Description =
                $"**NSFW:** {nsfw.ToString()}\n" +
                $"**Religious:** {religious.ToString()}\n" +
                $"**Political:** {political.ToString()}\n" +
                $"**Racist:** {racist.ToString()}\n" +
                $"**Sexist:** {sexist.ToString()}\n" +
                $"**Explicit:** {dirty.ToString()}",
            Color = DiscordColor.Yellow,
            Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
            {
                Url = botThumbNail
            },
            Timestamp = DateTimeOffset.Now
        };

        return embed;
    }
}