using Discord.Commands;
using JokeBot.Commands.JokeCommands;
using JokeBot.Models;
using RestSharp;

namespace JokeBot.Commands;

public class AnyJokeCommand : JokeCommand
{
    [Command("any")]
    public async Task JokeCommandAsync()
    {
        await HandleCommandAsync(
            "https://v2.jokeapi.dev/joke/any?blacklistFlags=nsfw,religious,political,racist,sexist,explicit");
    }
}