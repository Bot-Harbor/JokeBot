using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace JamJunction.App.Embed_Builders;

public class HelpEmbed
{
    public DiscordMessageBuilder HelpEmbedBuilder(InteractionContext context)
    {
        var guildName = context.Guild.Name;
        var guildIcon = context.Guild.GetIconUrl(ImageFormat.Png);
        var botIcon = context.Client.CurrentUser.GetAvatarUrl(ImageFormat.Png);
        var serverCount = context.Client.Guilds.Count;
        var shardCount = context.Client.ShardCount;
        var ping = context.Client.Ping;
        var botVersion = context.Client.VersionString.Substring(0, 5);

        var helpEmbed = new DiscordEmbedBuilder
        {
            Author = new DiscordEmbedBuilder.EmbedAuthor
            {
                Name = $"{guildName}",
                IconUrl = guildIcon
            },
            Title = "\ud83d\udcdd Getting Started",
            Color = DiscordColor.Yellow,
            Description =
                "Your SFW go-to resource for all kinds of jokes! Type one of the commands below to get started. " +
                $"Joke Bot is powered by [DSharpPlus {botVersion}]" +
                "(https://dsharpplus.github.io/DSharpPlus/index.html) " +
                "and [Docker](https://www.docker.com/).",

            Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
            {
                Url = botIcon
            },
            Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = "Bot Info  •  " +
                       $"Total Servers: {serverCount}  •  " +
                       $"Shard: {shardCount}  •  " +
                       $"Ping: {ping}  •  " +
                       $"Version: {botVersion}"
            },
            Timestamp = DateTimeOffset.Now
        };

        helpEmbed.AddField
        (
            "😂  **Joke Commands**",
            "💬  </any:1218292063657918565>\n" +
            "👾  </programming:1218298719817044028>\n" +
            "☠️  </dark:1218303474182258749>\n" +
            "💡  </misc:1218302063411200010>\n" +
            "🤪  </pun:1218304832813793420>\n" +
            "🎃  </spooky:1218305769066201168>\n" +
            "🎄  </christmas:1218306868951388240>\n" +
            "⚙️  </changefilters:1220494746108166234>\n" +
            "📄  </viewfilters:1220445492052361287>",
            true
        );

        helpEmbed.AddField
        (
            "🛠️  **Other Commands**",
            "\ud83c\udd98  </help:1218308992011468881>\n" +
            "\ud83c\udfd3  </ping:1218270865830187059>\n" +
            "\ud83d\uddbc\ufe0f  </embed:1218351341324206120>\n",
            true
        );

        var addBotBtn = new DiscordLinkButtonComponent
        (
            "https://discord.com/api/oauth2/authorize?client_id=1134585389714260050&permissions=8&scope=bot%20applications.commands",
            "Add To A Server"
        );

        var messageBuilder =
            new DiscordMessageBuilder(new DiscordMessageBuilder().AddEmbed(helpEmbed)
                .AddComponents(addBotBtn));

        return messageBuilder;
    }
}