using DSharpPlus;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Commands;
using JokeBot.DSharpPlus.App.Secrets;
using Microsoft.Extensions.Logging;

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
            MinimumLogLevel = LogLevel.Information,
            AutoReconnect = true
        };
        Client = new DiscordClient(discordConfig);
        await Client.ConnectAsync();
        SlashCommands();
        await Task.Delay(-1);
    }

    private void SlashCommands()
    {
        var slashCommands = Client.UseSlashCommands();
        
        slashCommands.RegisterCommands<PingCommand>();
    }
}