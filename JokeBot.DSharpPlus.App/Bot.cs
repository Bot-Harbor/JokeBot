using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using JokeBot.DSharpPlus.App.Events;
using JokeBot.DSharpPlus.App.Secrets;
using JokeBot.DSharpPlus.App.Slash_Commands.Jokes;
using JokeBot.DSharpPlus.App.Slash_Commands.Other;
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
        Events();
        await Task.Delay(-1);
    }

    private void SlashCommands()
    {
        var slashCommands = Client.UseSlashCommands();
        slashCommands.RegisterCommands<HelpCommand>();
        slashCommands.RegisterCommands<PingCommand>();
        slashCommands.RegisterCommands<CaptionCommand>();
        slashCommands.RegisterCommands<AnyJokeCommand>();
        slashCommands.RegisterCommands<ProgrammingJokeCommand>();
        slashCommands.RegisterCommands<MiscJokeCommand>();
        slashCommands.RegisterCommands<DarkJokeCommand>();
        slashCommands.RegisterCommands<PunCommand>();
        slashCommands.RegisterCommands<SpookyJokeCommand>();
        slashCommands.RegisterCommands<ChristmasJokeCommand>();
        slashCommands.RegisterCommands<ViewFiltersCommand>();
    }

    private void Events()
    {
        Client.GuildAvailable += GuildAvailable.ClientOnGuildAvailable;
        Client.GuildCreated += GuildCreated.ClientOnGuildCreated;
        Client.GuildDeleted += GuildDeleted.ClientOnGuildDeleted;
    }
}