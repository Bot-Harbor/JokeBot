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
        var thumbnail = "https://img.favpng.com/24/2/15/ping-pong-screenshot-amazing-free-game-app-store-png-favpng-gEzBU9vdN8i74yF2q53enebeE.jpg";

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
                Url = thumbnail,
                Width = 420,
                Height = 420
            }
        };

        return embed;
    }
}