using System.Text.Json.Serialization;
using MihomoSharp.Models.Avatar;

namespace MihomoSharp.Models.Player;

public class ForgottenHall
{
    [JsonPropertyName("level")]
    public int Memory { get; set; }

    [JsonPropertyName("chaos_id")]
    public int MemoryOfChaosId { get; set; }

    [JsonPropertyName("chaos_level")]
    public int MemoryOfChaos { get; set; }
}

public class PlayerModel
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; }

    [JsonPropertyName("nickname")]
    public string Name { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("world_level")]
    public int WorldLevel { get; set; }

    [JsonPropertyName("friend_count")]
    public int FriendCount { get; set; }

    [JsonPropertyName("avatar")]
    public AvatarModel Avatar { get; set; }

    [JsonPropertyName("signature")]
    public string Signature { get; set; }

    [JsonPropertyName("is_display")]
    public bool IsDisplay { get; set; }

    [JsonPropertyName("memory_data")]
    public ForgottenHall ForgottenHall { get; set; }

    [JsonPropertyName("universe_level")]
    public int SimulatedUniverses { get; set; }

    [JsonPropertyName("light_cone_count")]
    public int LightCones { get; set; }

    [JsonPropertyName("avatar_count")]
    public int Characters { get; set; }

    [JsonPropertyName("achievement_count")]
    public int Achievements { get; set; }
}
