using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JamJunction.App.Embed_Builders;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Other;

public class HelpCommand : ApplicationCommandModule
{
    [SlashCommand("help", "Gives you information about the bot & the available commands.")]
    public async Task HelpCommandAsync(InteractionContext context)
    {
        try
        {
            var helpEmbed = new HelpEmbed();
            await context.CreateResponseAsync(
                new DiscordInteractionResponseBuilder(helpEmbed.HelpEmbedBuilder(context)));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message), true);
        }
    }
}