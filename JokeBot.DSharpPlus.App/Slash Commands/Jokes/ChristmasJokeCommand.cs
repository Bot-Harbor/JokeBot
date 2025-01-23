using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class ChristmasJokeCommand : ApplicationCommandModule
{
    [SlashCommand("christmas", "Gives you a christmas joke.")]
    public async Task ChristmasJokeCommandAsync(InteractionContext context)
    {
        await context.DeferAsync();
        
        try
        {
            var jokeEmbed = new JokeEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(await jokeEmbed.JokeEmbedBuilder(context, "Christmas")));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(errorEmbed.NoJokesEmbedBuilder()));
        }
    }
}