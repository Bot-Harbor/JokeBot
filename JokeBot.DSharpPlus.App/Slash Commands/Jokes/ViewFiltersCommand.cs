using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;
using JokeBot.DSharpPlus.App.Services;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class ViewFiltersCommand : ApplicationCommandModule
{
    [SlashCommand("viewfilters", "Shows you the current joke filters for this server.")]
    public async Task ViewFiltersCommandAsync(InteractionContext context)
    {
        await context.DeferAsync();
        Console.WriteLine(context.Guild.Id);

        try
        {
            var guildId = context.Guild.Id.ToString();
            var client = new HttpClient();
            var guildService = new GuildService(client);
            var guild = await guildService.Get(guildId);
            var viewFiltersEmbed = new ViewFiltersEmbed();
            await context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(
                viewFiltersEmbed.ViewFiltersEmbedBuilder
                (
                    context, guild.Flag.Nsfw,
                    guild.Flag.Religious, guild.Flag.Political, guild.Flag.Racist,
                    guild.Flag.Sexist, guild.Flag.Explicit
                )));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.FollowUpAsync(
                new DiscordFollowupMessageBuilder().AddEmbed(errorEmbed.NoFiltersEmbedBuilder()));
        }
    }
}