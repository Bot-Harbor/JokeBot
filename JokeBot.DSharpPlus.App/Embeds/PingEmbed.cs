using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace JokeBot.DSharpPlus.App.Embeds;

public class PingEmbed
{
    public DiscordEmbedBuilder PingEmbedBuilder(InteractionContext context)
    {
        var userName = context.User.Username;
        var guildName = context.Guild.Name;
        var guildIcon = context.Guild.GetIconUrl(ImageFormat.Png);
        var botIcon = context.Client.CurrentUser.GetAvatarUrl(ImageFormat.Png);

        var embed = new DiscordEmbedBuilder()
        {
            Title = $"Pong 🏓  ``{userName}`` !",
            Color = DiscordColor.Yellow,
            Timestamp = DateTimeOffset.Now,
            Author = new DiscordEmbedBuilder.EmbedAuthor()
            {
                Name = guildName,
                IconUrl = guildIcon
            },
            Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
            {
                Url = botIcon
            }
        };

        return embed;
    }
}