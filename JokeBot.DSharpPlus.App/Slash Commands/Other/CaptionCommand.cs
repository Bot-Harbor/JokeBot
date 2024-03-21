using System.Runtime.InteropServices;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Embeds;
using JokeBot.DSharpPlus.App.Enums;

namespace JokeBot.DSharpPlus.App.Slash_Commands.Other;

public class CaptionCommand : ApplicationCommandModule
{
    [SlashCommand("embed", "Add a custom embedded message.")]
    public async Task CaptionCommandAsync(InteractionContext context,
        [Option("title", "Add a title to your embed.")] string title,
        [Option("image", "Pick the image you want to add to the embed.")] DiscordAttachment imageEmbed = null,
        [Option("color", "Pick a color for your embed.")] Color color = default,
        [Option("authorName", "Add an author name to your embed.")] string authorName = "",
        [Option("authorIconUrl", "Add an image url to your author's icon.")] string authorIconUrl = "",
        [Option("authorUrl", "Add a url to which the author leads.")] string authorUrl = "",
        [Option("description", "Add a description to your embed.")] string description = "",
        [Option("footerText", "Add footer text to your embed.")] string footerText = "",
        [Option("footerIconUrl", "Add an image url to your footer's icon.")] string footerIconUrl = "")
    {
        try
        {
            var captionEmbed = new CaptionEmbed();
            await context.CreateResponseAsync(captionEmbed.CaptionEmbedBuilder(authorName, authorIconUrl, authorUrl,
                title, description, imageEmbed, color, footerText, footerIconUrl));
        }
        catch (Exception e)
        {
            var errorEmbed = new ErrorEmbed();
            await context.CreateResponseAsync(errorEmbed.CommandFailedEmbedBuilder(e.Message), true);
        }
    }
}