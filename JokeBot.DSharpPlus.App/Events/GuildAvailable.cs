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
                    Nsfw = false,
                    Religious = false,
                    Political = false,
                    Racist = false,
                    Sexist = false,
                    Explicit = false
                }
            };
            await guildService.Create(guildModel);
        }
    }
}