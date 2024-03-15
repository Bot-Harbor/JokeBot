using Discord.Commands;
using JokeBot.Commands.JokeCommands;
using JokeBot.Models;
using RestSharp;

namespace JokeBot.Commands;

public class ChristmasJokeCommand : JokeCommand
{
    [Command("christmas")]
    public async Task JokeCommandAsync()
    {
        await HandleCommandAsync(
            "https://v2.jokeapi.dev/joke/christmas?blacklistFlags=nsfw,religious,political,racist,sexist,explicit");
    }
}