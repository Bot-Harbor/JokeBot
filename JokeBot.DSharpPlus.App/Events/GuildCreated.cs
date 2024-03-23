using DSharpPlus;
using DSharpPlus.EventArgs;
using JokeBot.DSharpPlus.App.Models;
using JokeBot.DSharpPlus.App.Services;

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
                Nsfw = true,
                Religious = true,
                Political = true,
                Racist = true,
                Sexist = true,
                Explicit = true
            }
        };
        await guildService.Create(guildModel);
        Console.WriteLine($"Guild Created: {guildId}");
    }
}