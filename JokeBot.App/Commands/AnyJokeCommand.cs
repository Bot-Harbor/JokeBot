using Discord.Commands;
using JokeBot.Interfaces;
using JokeBot.Models;
using RestSharp;

namespace JokeBot.Commands;

public class AnyJokeCommand : CommandBase, ICommandHandler
{
    [Command("any")]
    public async Task HandleCommandAsync()
    {
        RestClient = new RestClient();
        Request = new RestRequest(
            "https://v2.jokeapi.dev/joke/any?blacklistFlags=nsfw,religious,political,racist,sexist,explicit");
        var response = await RestClient.ExecuteAsync<JokeModel>(Request);

        switch (response)
        {
            case var a when (response.Data.Type == "single"):
                await ReplyAsync($"**Type: **{response.Data.Category}{Environment.NewLine}");
                await ReplyAsync($"**Joke:**{Environment.NewLine}");
                await ReplyAsync(response.Data.Joke);
                break;
            case var b when (response.Data.Type == "twopart"):
                await ReplyAsync($"**Type:**{response.Data.Category}{Environment.NewLine}");
                var joke =
                    $"**Setup:**{Environment.NewLine}{response.Data.SetUp}{Environment.NewLine}{Environment.NewLine}" +
                    $"**Delivery:**{Environment.NewLine}{response.Data.Delivery}";
                await ReplyAsync(joke);
                break;
            case var c when (response.Data == null || string.IsNullOrEmpty(response.Data.Joke) ||
                             string.IsNullOrEmpty(response.Data.SetUp) || string.IsNullOrEmpty(response.Data.Delivery)):
                await ReplyAsync("No jokes found at this time.");
                break;
            default:
                await ReplyAsync("Command is currently down.");
                break;
        }
    }
}