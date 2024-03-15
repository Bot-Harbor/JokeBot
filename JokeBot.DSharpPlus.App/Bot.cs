using DSharpPlus;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Secrets;

namespace JokeBot.DSharpPlus.App;

public class Bot
{
    private static DiscordClient Client { get; set; }

    public async Task RunBotAsync()
    {
        var discordConfig = new DiscordConfiguration()
        {
            Intents = DiscordIntents.All,
            Token = Discord.BotToken,
            TokenType = TokenType.Bot,
            AutoReconnect = true
        };
        Client = new DiscordClient(discordConfig);
        await Client.ConnectAsync();
        await Task.Delay(-1);
    }
}