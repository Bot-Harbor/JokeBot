namespace JokeBot.API.Settings.Interfaces;

public interface IMongoDbSettings
{
    string DatabaseName { get; set; }
    List<string> Collections { get; set; }
}