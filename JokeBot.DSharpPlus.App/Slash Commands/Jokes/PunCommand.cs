using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class PunCommand : ApplicationCommandModule
{
    [SlashCommand("pun", "Gives you a pun.")]
    public async Task PunCommandAsync(InteractionContext context)
    {
        await context.DeferAsync();

        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.FollowUpAsync(
                new DiscordFollowupMessageBuilder().AddEmbed(await jokeEmbed.JokeEmbedBuilder(context, "Pun")));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(errorEmbed.NoJokesEmbedBuilder()));
        }
    }
}