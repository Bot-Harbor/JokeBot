using DSharpPlus;
using DSharpPlus.EventArgs;
using JokeBot.DSharpPlus.App.Services;
using JokeBot.Models;

namespace JokeBot.DSharpPlus.App.Events;

public class GuildAvailable
{
    public static async Task ClientOnGuildAvailable(DiscordClient sender, GuildCreateEventArgs args)
    {
        foreach (var guild in sender.Guilds)
        {
            var client = new HttpClient();
            var guildService = new GuildService(client);
            var guildModel = new GuildModel
            {
                Id = guild.Key.ToString(),
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
        }
    }
}