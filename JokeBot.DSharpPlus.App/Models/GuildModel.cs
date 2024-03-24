using System.Text.Json.Serialization;

namespace JokeBot.DSharpPlus.App.Models;

public class GuildModel : BaseResource
{
    [JsonPropertyName("flag")] public Flag Flag { get; set; }
    [JsonPropertyName("dailyJokeIsActive")]public bool DailyJokeIsActive { get; set; }
}

public class Flag
{
    [JsonPropertyName("nsfw")] public bool Nsfw { get; set; }
    [JsonPropertyName("religious")] public bool Religious { get; set; }
    [JsonPropertyName("political")] public bool Political { get; set; }
    [JsonPropertyName("racist")] public bool Racist { get; set; }
    [JsonPropertyName("sexist")] public bool Sexist { get; set; }
    [JsonPropertyName("explicit")] public bool Explicit { get; set; }
}