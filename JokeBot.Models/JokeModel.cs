using System.Text.Json.Serialization;

namespace JokeBot.Models;

public class JokeModel
{
    [JsonPropertyName("error")] public bool Error { get; set; }
    [JsonPropertyName("category")] public string Category { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("joke")] public string Joke { get; set; }
    [JsonPropertyName("setup")] public string Setup { get; set; }
    [JsonPropertyName("delivery")] public string Delivery { get; set; }
    [JsonPropertyName("flags")] public Flags Flags { get; set; }
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("safe")] public bool Safe { get; set; }
}

public class Flags
{
    [JsonPropertyName("nsfw")] public bool Nsfw { get; set; }
    [JsonPropertyName("religious")] public bool Religious { get; set; }
    [JsonPropertyName("political")] public bool Political { get; set; }
    [JsonPropertyName("racist")] public bool Racist { get; set; }
    [JsonPropertyName("sexist")] public bool Sexist { get; set; }
    [JsonPropertyName("explicit")] public bool Explicit { get; set; }
}