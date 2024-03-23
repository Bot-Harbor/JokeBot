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
        
        var guildService = new GuildService(client);
        var guildId = context.Guild.Id.ToString();
        var guild = await guildService.Get(guildId);
        if (guild == null) throw new Exception();

        var jokeService = new JokeService(client);
        var joke = await jokeService.Get(category, guild.Flag.Nsfw, guild.Flag.Religious, guild.Flag.Political,
            guild.Flag.Racist, guild.Flag.Sexist, guild.Flag.Explicit);
        
        var guildName = context.Guild.Name;
        var guildIcon = context.Guild.GetIconUrl(ImageFormat.Png);
        var embed = new DiscordEmbedBuilder()
        {
            Color = color,
            Author = new DiscordEmbedBuilder.EmbedAuthor()
            {
                Name = guildName,
                IconUrl = guildIcon
            },
            Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail()
            {
                Url = thumbnailUrl
            },
            Timestamp = DateTimeOffset.Now
        };

        switch (joke.Type)
        {
            case "single":
                embed.Title = $"Category  •  {joke.Category}";
                embed.Description = $"**Joke:** ```{joke.Joke}```";
                return embed;
            case "twopart":
                embed.Title = $"Category  •  {joke.Category}";
                embed.Description =
                    $"**Setup:** ```{joke.Setup}```\n" +
                    $"**Delivery:** ```{joke.Delivery}```";
                break;
            default:
                embed.Title = "😔  •  No jokes could be found at this time. Please try again later.";
                break;
        }

        return embed;
    }
}