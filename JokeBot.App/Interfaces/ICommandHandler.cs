using Discord.Net.Queue;

namespace JokeBot.Interfaces;

public interface ICommandHandler
{
    Task HandleCommandAsync();
}