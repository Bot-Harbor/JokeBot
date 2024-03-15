using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class AnyJokeCommand : ApplicationCommandModule
{
    [SlashCommand("any", "Gives you any kind of joke.")]
    public async Task AnyJokeCommandAsync(InteractionContext context)
    {
        try
        {
            var jokeEmbed = new JokeEmbed();
            var thumbnail = "https://cdn-icons-png.flaticon.com/256/6028/6028787.png";
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Any", DiscordColor.Cyan, thumbnail));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message));
        }
    }
}