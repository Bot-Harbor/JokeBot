using Discord.Commands;
using JokeBot.Commands.JokeCommands;
using JokeBot.Models;
using RestSharp;

namespace JokeBot.Commands;

public class SpookyJokeCommand : JokeCommand
{
    [Command("spooky")]
    public async Task JokeCommandAsync()
    {
        await HandleCommandAsync(
            "https://v2.jokeapi.dev/joke/spooky?blacklistFlags=nsfw,religious,political,racist,sexist,explicit");
    }
}