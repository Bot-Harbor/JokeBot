using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace JokeBot.DSharpPlus.App.Models;

public class BaseResource
{
    [JsonPropertyName("id")] [BsonId] public string Id { get; set; }
    [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updatedAt")] public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("version")] public int Version { get; set; } = 1;
    [JsonIgnore] public bool Deleted { get; set; }
}