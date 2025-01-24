using DSharpPlus;
using DSharpPlus.EventArgs;
using JokeBot.DSharpPlus.App.Services;

namespace JokeBot.DSharpPlus.App.Events;

public class GuildDeleted
{
    public static async Task ClientOnGuildDeleted(DiscordClient sender, GuildDeleteEventArgs args)
    {
        var client = new HttpClient();
        var guildService = new GuildService(client);
        var guildId = args.Guild.Id.ToString();
        await guildService.Delete(guildId, true);
        Console.WriteLine($"Guild Deleted: {guildId}");
    }
}