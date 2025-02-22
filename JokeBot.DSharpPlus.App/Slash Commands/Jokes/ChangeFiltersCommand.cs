﻿using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using JokeBot.DSharpPlus.App.Embeds;
using JokeBot.DSharpPlus.App.Services;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Jokes;

public class ChangeFiltersCommand : ApplicationCommandModule
{
    [SlashCommand("changefilters",
        "Change the blacklist filters for this server. All filters are turned on by default.")]
    public async Task ChangeFiltersCommandAsync(
        InteractionContext context,
        [Option("nsfw", "Change to true to or false.")]
        bool nsfw,
        [Option("religious", "Change to true or false.")]
        bool religious,
        [Option("political", "Change to true or false.")]
        bool political,
        [Option("racist", "Change to true or false.")]
        bool racist,
        [Option("sexist", "Change to true or false.")]
        bool sexist,
        [Option("explicit", "Change to true or false.")]
        bool dirty
    )
    {
        await context.DeferAsync();

        try
        {
            var guildId = context.Guild.Id.ToString();
            var client = new HttpClient();
            var guildService = new GuildService(client);

            var guild = await guildService.Get(guildId);
            guild.Flag.Nsfw = nsfw;
            guild.Flag.Religious = religious;
            guild.Flag.Political = political;
            guild.Flag.Racist = racist;
            guild.Flag.Sexist = sexist;
            guild.Flag.Explicit = dirty;

            var result = await guildService.Update(guildId, guild);
            if (result == null) throw new Exception();
            var changeFiltersEmbed = new ChangeFiltersEmbed();
            await context.FollowUpAsync(
                new DiscordFollowupMessageBuilder().AddEmbed(changeFiltersEmbed.ChangeFiltersEmbedBuilder(context)));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.FollowUpAsync(
                new DiscordFollowupMessageBuilder().AddEmbed(errorEmbed.ChangingFiltersFailedEmbedBuilder()));
        }
    }
}