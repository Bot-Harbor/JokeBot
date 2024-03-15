using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class ProgrammingJokeCommand : ApplicationCommandModule
{
    [SlashCommand("programming", "Gives you a programming joke")]
    public async Task ProgrammingJokeCommandAsync(InteractionContext context)
    {
        try
        {
            var jokeEmbed = new JokeEmbed();
            var thumbnail = "https://cdn-icons-png.flaticon.com/256/6076/6076813.png";
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Programming",
                DiscordColor.Purple, thumbnail));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message));
        }
    }
}