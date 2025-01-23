using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class SpookyJokeCommand : ApplicationCommandModule
{
    [SlashCommand("spooky", "Gives you a spooky joke.")]
    public async Task SpookyJokeCommandAsync(InteractionContext context)
    {
        await context.DeferAsync();
        
        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(await jokeEmbed.JokeEmbedBuilder(context, "Spooky")));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(errorEmbed.NoJokesEmbedBuilder()));
        }
    }
}