using JokeBot.API.Settings.Interfaces;

namespace JokeBot.API.Settings;

public class JokeBotDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; set; } = "JokeBot";
    public List<string> Collections { get; set; } = new() {"Guilds"};
}