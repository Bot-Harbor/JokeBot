using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Services;

namespace JokeBot.DSharpPlus.App.Embeds;

public class JokeEmbed
{
    public async Task<DiscordEmbedBuilder> JokeEmbedBuilder(InteractionContext context, string category,
        DiscordColor color, string thumbnailUrl)
    {
        var client = new HttpClient();
        var jokeService = new JokeService(client);
        var joke = await jokeService.Get(category);
        var guildName = context.Guild.Name;
        var guildIcon = context.Guild.GetIconUrl(ImageFormat.Png);

        var embed = new DiscordEmbedBuilder()
        {
            Timestamp = DateTimeOffset.Now,
            Color = color,
            Author = new DiscordEmbedBuilder.EmbedAuthor()
            {
                Name = guildName,
                IconUrl = guildIcon
            },
            Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
            {
                Url = thumbnailUrl
            }
        };

        switch (joke.Type)
        {
            case "single":
                embed.Title = $"Category  -  {category}";
                embed.Description = joke.Joke;
                return embed;
            case "twopart":
                embed.Title = $"Category  -  {category}";
                embed.Description =
                    $"**Setup:** {joke.Setup}\n\n" +
                    $"**Delivery:** {joke.Delivery}";
                break;
            default:
                embed.Title = "😔  -  No jokes could be found at this time.";
                break;
        }

        return embed;
    }
}