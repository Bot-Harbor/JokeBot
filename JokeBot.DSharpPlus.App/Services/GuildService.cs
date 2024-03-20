using System.Text;
using System.Text.Json;
using JokeBot.DSharpPlus.App.Secrets;
using JokeBot.Models;

namespace JokeBot.DSharpPlus.App.Services;

public class GuildService
{
    private readonly HttpClient _httpClient;

    public GuildService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Create(GuildModel guildModel)
    {
        var content = JsonSerializer.Serialize(guildModel);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        var apiKey = Http.ApiKey;
        var requestHeader = Http.RequestHeader;
        _httpClient.DefaultRequestHeaders.Add(requestHeader, apiKey);
        await _httpClient.PostAsync("https://jokebotapi.azurewebsites.net/guilds", bodyContent);
    }

    public async Task Delete(string id)
    {
        var apiKey = Http.ApiKey;
        var requestHeader = Http.RequestHeader;
        _httpClient.DefaultRequestHeaders.Add(requestHeader, apiKey);
        await _httpClient.DeleteAsync($"https://jokebotapi.azurewebsites.net/guilds/{id}");
    }
}