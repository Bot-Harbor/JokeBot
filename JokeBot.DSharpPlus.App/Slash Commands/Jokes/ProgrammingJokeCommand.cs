using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class ProgrammingJokeCommand : ApplicationCommandModule
{
    [SlashCommand("programming", "Gives you a programming joke.")]
    public async Task ProgrammingJokeCommandAsync(InteractionContext context)
    {
        await context.DeferAsync();

        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.FollowUpAsync(
                new DiscordFollowupMessageBuilder().AddEmbed(await jokeEmbed.JokeEmbedBuilder(context, "Programming")));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(errorEmbed.NoJokesEmbedBuilder()));
        }
    }
}