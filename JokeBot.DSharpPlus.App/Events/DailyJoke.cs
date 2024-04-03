using DSharpPlus;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;
using JokeBot.DSharpPlus.App.Services;

namespace JokeBot.DSharpPlus.App.Events;

public class DailyJoke
{
    public bool IsFirstTimeRunning { get; set; } = true;

    public async void SendDailyJoke(InteractionContext context, string scheduledTime)
    {
        while (true)
        {
            var guildId = context.Guild.Id.ToString();
            var client = new HttpClient();
            var guildService = new GuildService(client);
            var guildModel = await guildService.Get(guildId);
            var isActive = guildModel.DailyJokeIsActive;

            var easternTimeNow = TimeZoneInfo
                .ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"))
                .ToString("HH:mm:ss");

            if (IsFirstTimeRunning)
            {
                IsFirstTimeRunning = false;
                Console.WriteLine($"Time Now: {easternTimeNow}");
                Console.WriteLine($"Scheduled Time: {scheduledTime}");
                var parsedEasternTimeNow = DateTime.Parse(easternTimeNow);
                var parsedScheduledTime = DateTime.Parse(scheduledTime);
                Console.WriteLine($"=====\nParsed Time Now: {parsedEasternTimeNow}");
                Console.WriteLine($"Parsed Scheduled Time: {parsedScheduledTime}");
                TimeSpan delayUntilFirstDailyJoke;
                var extraTime = TimeSpan.FromSeconds(5);

                if (parsedScheduledTime > parsedEasternTimeNow)
                {
                    delayUntilFirstDailyJoke = parsedScheduledTime - parsedEasternTimeNow;
                }
                else
                {
                    parsedScheduledTime = parsedScheduledTime.AddDays(1);
                    delayUntilFirstDailyJoke = parsedScheduledTime - parsedEasternTimeNow;
                }

                delayUntilFirstDailyJoke -= extraTime;
                Console.WriteLine($"Time Until First Daily Joke: {delayUntilFirstDailyJoke}");
                await Task.Delay(delayUntilFirstDailyJoke);
            }

            if (isActive)
            {
                if (easternTimeNow == scheduledTime)
                {
                    var guildName = context.Guild.Name;
                    var guildIcon = context.Guild.GetIconUrl(ImageFormat.Png);
                    var dailyJokeEmbed = new DailyJokeEmbed();
                    var channel = context.Channel;
                    await channel.SendMessageAsync(
                        await dailyJokeEmbed.DailyJokeEmbedBuilder("any", guildId, guildName, guildIcon));
                    await Task.Delay(TimeSpan.FromHours(23) + TimeSpan.FromMinutes(59) + TimeSpan.FromSeconds(55));
                }
            }
            else
            {
                break;
            }
        }
    }
}