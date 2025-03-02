
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MihomoSharp.Models.Combat;
using MihomoSharp.Models.Stat;

namespace MihomoSharp.Models.Equipment;

public sealed class LightCone
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("rarity")]
    public int Rarity { get; set; }

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("promotion")]
    public int Promotion { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("preview")]
    public string Preview { get; set; }

    [JsonPropertyName("portrait")]
    public string Portrait { get; set; }

    [JsonPropertyName("path")]
    public MihomoSharp.Models.Combat.Path Path { get; set; }

    [JsonPropertyName("attributes")]
    public List<MihomoSharp.Models.Stat.Attribute> Attributes { get; set; }

    [JsonPropertyName("properties")]
    public List<Property> Properties { get; set; }

    public int MaxLevel => 20 + 10 * Promotion;
}

public sealed class Relic
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("set_id")]
    public string SetId { get; set; }

    [JsonPropertyName("set_name")]
    public string SetName { get; set; }

    [JsonPropertyName("rarity")]
    public int Rarity { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("main_affix")]
    public MainAffix MainAffix { get; set; }

    [JsonPropertyName("sub_affix")]
    public List<SubAffix> SubAffixes { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}

public sealed class RelicSet
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("num")]
    public int Num { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("properties")]
    public List<Property> Properties { get; set; }
}
