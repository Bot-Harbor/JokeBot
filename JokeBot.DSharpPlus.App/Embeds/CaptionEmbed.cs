using DSharpPlus.Entities;
using JokeBot.DSharpPlus.App.Enums;

namespace JokeBot.DSharpPlus.App.Embeds;

public class CaptionEmbed
{
    public DiscordEmbedBuilder CaptionEmbedBuilder(string authorName, string authorIconUrl, string authorUrl,
        string title, string description, DiscordAttachment imageEmbed,
        Color color, string footerText, string footerIconUrl)
    {
        if (imageEmbed != null)
        {
            var embed = new DiscordEmbedBuilder
            {
                Author = new DiscordEmbedBuilder.EmbedAuthor()
                {
                    Name = authorName,
                    IconUrl = authorIconUrl,
                    Url = authorUrl
                },
                Title = title,
                Description = description,
                ImageUrl = imageEmbed.Url,
                Color = color switch
                {
                    Color.Aquamarine => DiscordColor.Aquamarine,
                    Color.Azure => DiscordColor.Azure,
                    Color.Black => DiscordColor.Black,
                    Color.Blue => DiscordColor.Blue,
                    Color.Bplurple => DiscordColor.Blurple,
                    Color.Brown => DiscordColor.Brown,
                    Color.Chartreuse => DiscordColor.Chartreuse,
                    Color.Cyan => DiscordColor.Cyan,
                    Color.DarkBlue => DiscordColor.DarkBlue,
                    Color.DarkGray => DiscordColor.DarkGray,
                    Color.DarkGreen => DiscordColor.DarkGreen,
                    Color.DarkRed => DiscordColor.DarkRed,
                    Color.Gold => DiscordColor.Gold,
                    Color.Goldenrod => DiscordColor.Goldenrod,
                    Color.Gray => DiscordColor.Gray,
                    Color.Green => DiscordColor.Green,
                    Color.LightGray => DiscordColor.LightGray,
                    Color.Orange => DiscordColor.Orange,
                    Color.Pink => DiscordColor.HotPink,
                    Color.Purple => DiscordColor.Purple,
                    Color.Red => DiscordColor.Red,
                    Color.SapGreen => DiscordColor.SapGreen,
                    Color.Teal => DiscordColor.Teal,
                    Color.White => DiscordColor.White,
                    Color.Yellow => DiscordColor.Yellow,
                    _ => DiscordColor.None
                },
                Footer = new DiscordEmbedBuilder.EmbedFooter()
                {
                    Text = footerText,
                    IconUrl = footerIconUrl
                }
            };

            return embed;
        }
        else
        {
            var embed = new DiscordEmbedBuilder
            {
                Author = new DiscordEmbedBuilder.EmbedAuthor()
                {
                    Name = authorName,
                    IconUrl = authorIconUrl,
                    Url = authorUrl
                },
                Title = title,
                Description = description,
                Color = color switch
                {
                    Color.Aquamarine => DiscordColor.Aquamarine,
                    Color.Azure => DiscordColor.Azure,
                    Color.Black => DiscordColor.Black,
                    Color.Blue => DiscordColor.Blue,
                    Color.Bplurple => DiscordColor.Blurple,
                    Color.Brown => DiscordColor.Brown,
                    Color.Chartreuse => DiscordColor.Chartreuse,
                    Color.Cyan => DiscordColor.Cyan,
                    Color.DarkBlue => DiscordColor.DarkBlue,
                    Color.DarkGray => DiscordColor.DarkGray,
                    Color.DarkGreen => DiscordColor.DarkGreen,
                    Color.DarkRed => DiscordColor.DarkRed,
                    Color.Gold => DiscordColor.Gold,
                    Color.Goldenrod => DiscordColor.Goldenrod,
                    Color.Gray => DiscordColor.Gray,
                    Color.Green => DiscordColor.Green,
                    Color.LightGray => DiscordColor.LightGray,
                    Color.Orange => DiscordColor.Orange,
                    Color.Pink => DiscordColor.HotPink,
                    Color.Purple => DiscordColor.Purple,
                    Color.Red => DiscordColor.Red,
                    Color.SapGreen => DiscordColor.SapGreen,
                    Color.Teal => DiscordColor.Teal,
                    Color.White => DiscordColor.White,
                    Color.Yellow => DiscordColor.Yellow,
                    _ => DiscordColor.None
                },
                Footer = new DiscordEmbedBuilder.EmbedFooter()
                {
                    Text = footerText,
                    IconUrl = footerIconUrl
                }
            };

            return embed;
        }
    }
}