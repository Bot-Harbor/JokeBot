using DSharpPlus;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;
using JokeBot.DSharpPlus.App.Services;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class TurnOffDailyJokeCommand : ApplicationCommandModule
{
    [SlashCommand("turnoffdailyjoke", "Turn off daily joke.")]
    [SlashCommandPermissions(Permissions.Administrator)]
    public async Task TurnOffDailyJokeCommandAsync(InteractionContext context)
    {
        var dailyJokeSwitchEmbed = new DailyJokeSwitchEmbed();
        var errorEmbed = new ErrorEmbed();
        try
        {
            var client = new HttpClient();
            var guildService = new GuildService(client);
            
            var guildId = context.Guild.Id.ToString();
            var guildModel = await guildService.Get(guildId);
            guildModel.DailyJokeIsActive = false;
            await guildService.Update(guildId, guildModel);
            await context.CreateResponseAsync(dailyJokeSwitchEmbed.DailyJokeOffEmbedBuilder());
            
        }
        catch (Exception e)
        {
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message), true);
        }
    }
}