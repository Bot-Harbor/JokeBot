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
            var thumbnail =
                "https://images.twinkl.co.uk/tw1n/image/private/s--2Ugg-lBJ--/q_auto:eco,w_740/v1/u/event/image/%5Bjack%5D-event-page-tell-a-joke-day-1688473899.png";
            await context.CreateResponseAsync(await jokeEmbed.JokeEmbedBuilder(context, "Any", DiscordColor.White, thumbnail));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message));
        }
    }
}