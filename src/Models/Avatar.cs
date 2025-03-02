using System.Text.Json.Serialization;

namespace MihomoSharp.Models.Avatar;

public sealed class AvatarModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}