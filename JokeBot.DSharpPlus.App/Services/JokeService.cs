using JokeBot.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JokeBot.DSharpPlus.App.Services;

public class JokeService
{
    private readonly HttpClient _httpClient;

    public JokeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<JokeModel> Get(string category)
    {
        var result = await _httpClient.GetAsync(
            $"https://v2.jokeapi.dev/joke/{category}?blacklistFlags=nsfw,religious,political,racist,sexist,explicit");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<JokeModel>(json)!;
        }

        return new JokeModel();
    }
}