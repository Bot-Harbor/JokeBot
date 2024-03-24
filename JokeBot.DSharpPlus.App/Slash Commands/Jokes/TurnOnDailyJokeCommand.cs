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
        [Option("time", "Specify the time for the daily joke in a 24-hr format \"HH:mm:ss\". Repeats every \"24\" hours.")]
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
            
            if (scheduledTime.Contains(':'))
            {
                try
                {
                    var parsedScheduledTime = DateTime.Parse(scheduledTime).ToString("HH:mm:ss");
                    var dailyJoke = new DailyJoke();
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
                await context.CreateResponseAsync(errorEmbed.IncorrectTimeFormatEmbedBuilder());
            }
        }
        catch (Exception e)
        {
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message), true);
        }
    }
}