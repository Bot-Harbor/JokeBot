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
        var blackFlags = ""; 
        if (nsfw)
        {
            blackFlags +=  "nsfw,";
        }
        if (religious)
        {
            blackFlags +=  "religious,";
        }
        if (political)
        {
            blackFlags +=  "political,";
        } 
        if (racist)
        {
            blackFlags +=  "racist,";
        }
        if (sexist)
        {
            blackFlags +=  "sexist,";
        }
        if (dirty)
        {
            blackFlags +=  "explicit,";
        }
        
        if (!string.IsNullOrEmpty(blackFlags))
        {
            blackFlags = "blacklistFlags=" + blackFlags.TrimEnd(',') + "&";
        }

        var url = baseUrl + blackFlags;
        var requestUrl = url.Substring(0, url.Length - 1);
        var result = await _httpClient.GetAsync(requestUrl);
        if (!result.IsSuccessStatusCode) return null;
        var json = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<JokeModel>(json)!;
    }
}