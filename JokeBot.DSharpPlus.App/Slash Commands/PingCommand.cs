using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Commands;

public class PingCommand : ApplicationCommandModule
{
    [SlashCommand("ping", "Pongs back to the server.")]
    public async Task PingCommandAsync(InteractionContext context)
    {
        try
        {
            var pingEmbed = new PingEmbed();
            await context.CreateResponseAsync(pingEmbed.PingEmbedBuilder(context));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message));
        }
    }
}