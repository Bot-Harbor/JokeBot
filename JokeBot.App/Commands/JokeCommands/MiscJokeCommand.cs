using Discord.Commands;
using JokeBot.Commands.JokeCommands;
using JokeBot.Models;
using RestSharp;

namespace JokeBot.Commands;

public class MiscJokeCommand : JokeCommand
{
    [Command("misc")]
    public async Task JokeCommandAsync()
    {
        await HandleCommandAsync(
            "https://v2.jokeapi.dev/joke/misc?blacklistFlags=nsfw,religious,political,racist,sexist,explicit");
    }
}