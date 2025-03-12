using System.Collections.Generic;
using System.Text.Json.Serialization;
using MihomoSharp.Models.Combat;
using MihomoSharp.Models.Equipment;
using MihomoSharp.Models.Stat;
using MihomoSharp.Interface;

namespace MihomoSharp.Models.Character;

public sealed class CharacterModel : IIconGetable
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("rarity")]
    public int Rarity { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("promotion")]
    public int Ascension { get; set; }

    [JsonPropertyName("rank")]
    public int Eidolon { get; set; }

    [JsonPropertyName("rank_icons")]
    public List<string> EidolonIcons { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("preview")]
    public string Preview { get; set; }

    [JsonPropertyName("portrait")]
    public string Portrait { get; set; }

    [JsonPropertyName("path")]
    public MihomoSharp.Models.Combat.Path Path { get; set; }

    [JsonPropertyName("element")]
    public Element Element { get; set; }

    [JsonPropertyName("skills")]
    public List<Trace> Traces { get; set; }

    [JsonPropertyName("skill_trees")]
    public List<TraceTreeNode> TraceTree { get; set; }

    [JsonPropertyName("light_cone")]
    public LightCone LightCone { get; set; }

    [JsonPropertyName("relics")]
    public List<Relic> Relics { get; set; }

    [JsonPropertyName("relic_sets")]
    public List<RelicSet> RelicSets { get; set; }

    [JsonPropertyName("attributes")]
    public List<MihomoSharp.Models.Stat.Attribute> Attributes { get; set; }

    [JsonPropertyName("additions")]
    public List<MihomoSharp.Models.Stat.Attribute> Additions { get; set; }

    [JsonPropertyName("properties")]
    public List<Property> Properties { get; set; }

    public int MaxLevel => 20 + 10 * Ascension;

    public string GetIconName() => Name;

    public string GetIconPlace() => Icon;

    public string GetIconFileStorePath() => "icons/characters";
}
