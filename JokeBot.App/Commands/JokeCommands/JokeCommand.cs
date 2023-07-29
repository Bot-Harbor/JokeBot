using JokeBot.Models;
using RestSharp;

namespace JokeBot.Commands.JokeCommands;

public class JokeCommand : CommandBase
{
    protected async Task HandleCommandAsync(string endpoint)
    {
        var restClient = new RestClient();
        var request = new RestRequest(endpoint);
        var response = await restClient.ExecuteAsync<JokeModel>(request);

        switch (response)
        {
            case var a when (response.Data.Type == "single"):
                await ReplyAsync($"**Category: **{response.Data.Category}{Environment.NewLine}");
                await ReplyAsync($"**Joke:**{Environment.NewLine}");
                await ReplyAsync(response.Data.Joke);
                break;
            case var b when (response.Data.Type == "twopart"):
                await ReplyAsync($"**Category: **{response.Data.Category}{Environment.NewLine}");
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