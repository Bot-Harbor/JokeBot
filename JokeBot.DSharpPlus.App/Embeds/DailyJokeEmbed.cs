using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Services;

namespace JokeBot.DSharpPlus.App.Embeds;

public class DailyJokeEmbed
{
    public async Task<DiscordEmbedBuilder> DailyJokeEmbedBuilder(string category,
        string guildId, string guildName, string guildIcon)
    {
        var embed = new DiscordEmbedBuilder()
        {
            Author = new DiscordEmbedBuilder.EmbedAuthor()
            {
                Name = guildName,
                IconUrl = guildIcon
            },
            Timestamp = DateTimeOffset.Now
        };
        
        var client = new HttpClient();
        var guildService = new GuildService(client);

        var guildModel = await guildService.Get(guildId);
        if (guildModel == null) throw new Exception();

        var jokeService = new JokeService(client);
        var joke = await jokeService.Get(category, guildModel.Flag.Nsfw, guildModel.Flag.Religious,
            guildModel.Flag.Political,
            guildModel.Flag.Racist, guildModel.Flag.Sexist, guildModel.Flag.Explicit);

        switch (joke.Category.ToLower())
        {
            case "programming":
                embed.Color = DiscordColor.Purple;
                embed.Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
                {
                    Url = "https://cdn-icons-png.flaticon.com/256/6076/6076813.png"
                };
                break;
            case "dark":
                embed.Color = DiscordColor.Black;
                embed.Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
                {
                    Url = "https://styles.redditmedia.com/t5_2semr/styles/communityIcon_vl21nfr78fp81.png"
                };
                break;
            case "misc":
                embed.Color = DiscordColor.Gray;
                embed.Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
                {
                    Url =
                        "https://icons.iconarchive.com/icons/tribalmarkings/colorflow/256/miscellaneous-icon.png"
                };
                break;
            case "pun":
                embed.Color = DiscordColor.Yellow;
                embed.Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
                {
                    Url =
                        "https://images.vexels.com/media/users/3/234764/isolated/lists/0783c83507b7251cfdee269b866f6d77-insect-pun-funny-badge.png"
                };
                break;
            case "spooky":
                embed.Color = DiscordColor.Orange;
                embed.Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
                {
                    Url = "https://cdn-icons-png.flaticon.com/128/12554/12554074.png"
                };
                break;
            case "christmas":
                embed.Color = DiscordColor.Green;
                embed.Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
                {
                    Url = "https://styles.redditmedia.com/t5_2vlkk/styles/communityIcon_l05g9fzm81m01.png"
                };
                break;
            default:
                throw new Exception();
        }

        switch (joke.Type)
        {
            case "single":
                embed.Title = $"Daily Joke: Category  •  {joke.Category}";
                embed.Description = $"**Joke:** {joke.Joke}";
                return embed;
            case "twopart":
                embed.Title = $"Daily Joke: Category  •  {joke.Category}";
                embed.Description =
                    $"**Setup:** {joke.Setup}\n\n" +
                    $"**Delivery:** {joke.Delivery}";
                break;
            default:
                embed.Title =
                    "Daily Joke: 😔  •  No jokes could be found at this time. Please try again later.";
                break;
        }
        
        return embed;
    }
}