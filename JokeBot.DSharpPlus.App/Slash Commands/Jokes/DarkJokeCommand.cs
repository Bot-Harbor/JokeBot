using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class DarkJokeCommand : ApplicationCommandModule
{
    [SlashCommand("dark", "Gives you a dark joke.")]
    public async Task DarkJokeCommandAsync(InteractionContext context)
    {
        await context.DeferAsync();
        
        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(await jokeEmbed.JokeEmbedBuilder(context, "Dark")));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(errorEmbed.NoJokesEmbedBuilder()));
        }
    }
}