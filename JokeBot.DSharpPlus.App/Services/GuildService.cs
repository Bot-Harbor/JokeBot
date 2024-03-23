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

    public async Task<GuildModel> Get(string id)
    {
        var apiKey = Http.ApiKey;
        var requestHeader = Http.RequestHeader;
        _httpClient.DefaultRequestHeaders.Add(requestHeader, apiKey);
        var result = await _httpClient.GetAsync($"https://jokebotapi.azurewebsites.net/guilds/{id}");
        if (!result.IsSuccessStatusCode) return null;
        var json = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<GuildModel>(json);
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

    public async Task<GuildModel> Update(string id, GuildModel guildModel)
    {
        var content = JsonSerializer.Serialize(guildModel);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        var apiKey = Http.ApiKey;
        var requestHeader = Http.RequestHeader;
         _httpClient.DefaultRequestHeaders.Add(requestHeader, apiKey);
        var result = await _httpClient.PutAsync($"https://jokebotapi.azurewebsites.net/guilds/{id}", bodyContent);
        if (!result.IsSuccessStatusCode) return null;
        return new GuildModel();
    }
    
    public async Task Delete(string id)
    {
        var apiKey = Http.ApiKey;
        var requestHeader = Http.RequestHeader;
        _httpClient.DefaultRequestHeaders.Add(requestHeader, apiKey);
        await _httpClient.DeleteAsync($"https://jokebotapi.azurewebsites.net/guilds/{id}");
    }
}