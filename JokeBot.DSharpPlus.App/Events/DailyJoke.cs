using System.Timers;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;
using JokeBot.DSharpPlus.App.Enums;
using JokeBot.DSharpPlus.App.Secrets;
using JokeBot.DSharpPlus.App.Services;
using JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

namespace JokeBot.DSharpPlus.App.Events;

public class DailyJoke
{
    public async void SendDailyJoke(InteractionContext context, string scheduledTime)
    {
        while (true)
        {
            var guildId = context.Guild.Id.ToString();
            var client = new HttpClient();
            var guildService = new GuildService(client);
            var guildModel = await guildService.Get(guildId);
            var isActive = guildModel.DailyJokeIsActive;
            
            if (isActive)
            {
                var easternTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")).ToString("HH:mm:ss");
                if (easternTimeNow == scheduledTime)
                {
                    var guildName = context.Guild.Name;
                    var guildIcon = context.Guild.GetIconUrl(ImageFormat.Png);
                    var dailyJokeEmbed = new DailyJokeEmbed();
                    var channel = context.Channel;
                    await channel.SendMessageAsync(
                        await dailyJokeEmbed.DailyJokeEmbedBuilder("any", guildId, guildName, guildIcon));
                    await Task.Delay(TimeSpan.FromSeconds(3));
                }
            }
            else
            {
                break;
            }
            
        }
    }
}