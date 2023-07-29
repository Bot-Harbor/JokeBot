using Discord.Commands;
using JokeBot.Models;
using RestSharp;
using RestRequest = Discord.Net.Queue.RestRequest;

namespace JokeBot.Commands;

public class JokeCommand : CommandBase
{
    [Command("joke")]
    public async Task HandleCommandAsync()
    {
        var restClient = new RestClient();
        var request = new RestSharp.RestRequest("https://v2.jokeapi.dev/joke/programming");
        var response = await restClient.ExecuteAsync<JokeModel>(request);

        switch (response)
        {
            case var a when (response.Data.Type == "single"):
                await ReplyAsync($"**Joke:**{Environment.NewLine}");
                await ReplyAsync(response.Data.Joke);
                break;
            case var b when (response.Data.Type == "twopart"):
                var joke =
                    $"**Setup:**{Environment.NewLine}{response.Data.SetUp}{Environment.NewLine}" +
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