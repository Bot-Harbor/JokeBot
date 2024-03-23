using System.Timers;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;
using JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

namespace JokeBot.DSharpPlus.App.Events;

public class DailyJoke
{
    public static async void SendDailyJoke(InteractionContext context)
    {
        while (true)
        {
            if (DailyJokeSwitchCommand.IsActive)
            {
                foreach (var guild in context.Client.Guilds)
                {
                    var guildId = guild.Value.Id.ToString();
                    var guildName = guild.Value.Name;
                    var guildIcon = guild.Value.GetIconUrl(ImageFormat.Png);

                    var dailyJokeEmbed = new DailyJokeEmbed();
                    var embed = dailyJokeEmbed.DailyJokeEmbedBuilder("any", guildId, guildName, guildIcon);
                    var defaultChannel = guild.Value.GetDefaultChannel();
                    await defaultChannel.SendMessageAsync(await embed);
                }
            }
            else
            {
                break;
            }
            await Task.Delay(TimeSpan.FromSeconds(10));
        }
    }
}