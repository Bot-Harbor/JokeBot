using Discord.Commands;
using JokeBot.Commands.JokeCommands;
using JokeBot.Models;
using RestSharp;

namespace JokeBot.Commands;

public class PunCommand : JokeCommand
{
    [Command("pun")]
    public async Task JokeCommandAsync()
    {
        await HandleCommandAsync(
            "https://v2.jokeapi.dev/joke/pun?blacklistFlags=nsfw,religious,political,racist,sexist,explicit");
    }
}