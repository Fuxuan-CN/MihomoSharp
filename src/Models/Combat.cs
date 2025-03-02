
using System.Text.Json.Serialization;

namespace MihomoSharp.Models.Combat;

public class Element
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}

public class Path
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}

public class Trace
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("max_level")]
    public int MaxLevel { get; set; }

    [JsonPropertyName("element")]
    public Element Element { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("type_text")]
    public string TypeText { get; set; }

    [JsonPropertyName("effect")]
    public string Effect { get; set; }

    [JsonPropertyName("effect_text")]
    public string EffectText { get; set; }

    [JsonPropertyName("simple_desc")]
    public string SimpleDesc { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}

public class TraceTreeNode
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("max_level")]
    public int MaxLevel { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("anchor")]
    public string Anchor { get; set; }

    #nullable enable
    [JsonPropertyName("parent")]
    public string? Parent { get; set; }
    #nullable disable
}