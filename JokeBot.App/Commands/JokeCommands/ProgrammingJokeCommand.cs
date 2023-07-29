using Discord.Commands;
using JokeBot.Commands.JokeCommands;
using JokeBot.Models;
using RestSharp;

namespace JokeBot.Commands;

public class ProgrammingJokeCommand : JokeCommand
{
    [Command("programming")]
    public async Task JokeCommandAsync()
    {
        await HandleCommandAsync(
            "https://v2.jokeapi.dev/joke/programming?blacklistFlags=nsfw,religious,political,racist,sexist,explicit");
    }
}