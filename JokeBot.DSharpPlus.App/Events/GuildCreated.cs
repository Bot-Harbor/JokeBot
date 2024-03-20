using DSharpPlus;
using DSharpPlus.EventArgs;
using JokeBot.DSharpPlus.App.Services;
using JokeBot.Models;

namespace JokeBot.DSharpPlus.App.Events;

public class GuildCreated
{
    public static async Task ClientOnGuildCreated(DiscordClient sender, GuildCreateEventArgs args)
    {
        var client = new HttpClient();
        var guildService = new GuildService(client);
        var guildId = args.Guild.Id;
        var guildModel = new GuildModel
        {
            Id = guildId.ToString(),
            Flag = new Flag
            {
                Nsfw = false,
                Religious = false,
                Political = false,
                Racist = false,
                Sexist = false,
                Explicit = false
            }
        };
        await guildService.Create(guildModel);
        Console.WriteLine($"Guild Created: {guildId}");
    }
}