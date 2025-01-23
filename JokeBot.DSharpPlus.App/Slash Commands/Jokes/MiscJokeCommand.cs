using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class MiscJokeCommand : ApplicationCommandModule
{
    [SlashCommand("misc", "Gives you a miscellaneous joke.")]
    public async Task MiscJokeCommandAsync(InteractionContext context)
    {
        await context.DeferAsync();

        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.FollowUpAsync(
                new DiscordFollowupMessageBuilder().AddEmbed(await jokeEmbed.JokeEmbedBuilder(context, "Misc")));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(errorEmbed.NoJokesEmbedBuilder()));
        }
    }
}