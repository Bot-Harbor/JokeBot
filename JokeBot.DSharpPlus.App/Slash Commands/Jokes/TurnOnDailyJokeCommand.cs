using DSharpPlus;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;
using JokeBot.DSharpPlus.App.Events;
using JokeBot.DSharpPlus.App.Services;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class TurnOnDailyJokeCommand : ApplicationCommandModule
{
    [SlashCommand("scheduledailyjoke", "Schedule a time for the daily joke.")]
    [SlashCommandPermissions(Permissions.Administrator)]
    public async Task TurnOnDailyJokeCommandAsync(InteractionContext context,
        [Option("time", "Specify the time for the daily joke in a 24-hr format \"HH:mm\".")]
        string scheduledTime)
    {
        var dailyJokeSwitchEmbed = new DailyJokeSwitchEmbed();
        var errorEmbed = new ErrorEmbed();
        try
        {
            var client = new HttpClient();
            var guildService = new GuildService(client);
            var guildId = context.Guild.Id.ToString();
            var guildModel = await guildService.Get(guildId);
            guildModel.DailyJokeIsActive = true;
            await guildService.Update(guildId, guildModel);
            
            var dailyJoke = new DailyJoke();
            string parsedScheduledTime;
            if (!scheduledTime.Contains(':'))
            {
                try
                {
                    scheduledTime = scheduledTime.Insert(scheduledTime.Length - 2, ":");
                    parsedScheduledTime = DateTimeOffset.Parse(scheduledTime).ToString("HH:mm");
                    dailyJoke.SendDailyJoke(context, parsedScheduledTime);
                    await context.CreateResponseAsync(dailyJokeSwitchEmbed.DailyJokeOnEmbedBuilder());
                }
                catch (Exception e)
                {
                    await context.CreateResponseAsync(errorEmbed.IncorrectTimeFormatEmbedBuilder());
                }
            }
            else
            {
                try
                {
                    parsedScheduledTime = DateTimeOffset.Parse(scheduledTime).ToString("HH:mm");
                    dailyJoke.SendDailyJoke(context, parsedScheduledTime);
                    await context.CreateResponseAsync(dailyJokeSwitchEmbed.DailyJokeOnEmbedBuilder());
                }
                catch (Exception e)
                {
                    await context.CreateResponseAsync(errorEmbed.IncorrectTimeFormatEmbedBuilder());
                }
            }
            
        }
        catch (Exception e)
        {
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message), true);
        }
    }
}