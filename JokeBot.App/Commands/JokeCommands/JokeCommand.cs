using JokeBot.Models;
using RestSharp;

namespace JokeBot.Commands.JokeCommands;

public abstract class JokeCommand : CommandBase
{
    protected async Task HandleCommandAsync(string endpoint)
    {
        var restClient = new RestClient();
        var request = new RestRequest(endpoint);
        var response = await restClient.ExecuteAsync<JokeModel>(request);

        if (response.Data is {Type: "single"})
        {
            await ReplyAsync($"**Category: **{response.Data.Category}{Environment.NewLine}");
            await ReplyAsync($"**Joke:**{Environment.NewLine}");
            await ReplyAsync(response.Data.Joke);
        }

        else if (response.Data is {Type: "twopart"})
        {
            await ReplyAsync($"**Category: **{response.Data.Category}{Environment.NewLine}");
            var joke =
                $"**Setup:**{Environment.NewLine}{response.Data.SetUp}{Environment.NewLine}{Environment.NewLine}" +
                $"**Delivery:**{Environment.NewLine}{response.Data.Delivery}";
            await ReplyAsync(joke);
        }

        else
        {
            await ReplyAsync("No jokes found at this time.");
        }
    }
}