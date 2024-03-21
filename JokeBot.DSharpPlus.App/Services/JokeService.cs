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

    public async Task<JokeModel> Get(string category, bool nsfw, bool religious, bool political, bool racist, bool sexist, bool dirty)
    {
        var baseUrl = $"https://v2.jokeapi.dev/joke/{category}?";
        var blackFlags = "blacklistFlags="; 
        if (nsfw == false)
        {
            blackFlags +=  "nsfw,";
        }
        if (religious == false)
        {
            blackFlags +=  "religious,";
        }
        if (political == false)
        {
            blackFlags +=  "political,";
        } 
        if (racist == false)
        {
            blackFlags +=  "racist,";
        }
        if (sexist == false)
        {
            blackFlags +=  "sexist,";
        }
        if (dirty == false)
        {
            blackFlags +=  "explicit";
        }
        var result = await _httpClient.GetAsync(baseUrl + blackFlags);
        var json = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<JokeModel>(json)!;
    }
}