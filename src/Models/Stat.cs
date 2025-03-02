using System.Text.Json.Serialization;

namespace MihomoSharp.Models.Stat;

public sealed class Attribute
{
    [JsonPropertyName("field")]
    public string Field { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("value")]
    public float Value { get; set; }

    [JsonPropertyName("display")]
    public string DisplayedValue { get; set; }

    [JsonPropertyName("percent")]
    public bool IsPercent { get; set; }
}

public class Property
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("field")]
    public string Field { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("value")]
    public float Value { get; set; }

    [JsonPropertyName("display")]
    public string DisplayedValue { get; set; }

    [JsonPropertyName("percent")]
    public bool IsPercent { get; set; }
}

public class MainAffix : Property
{
}

public sealed class SubAffix : MainAffix
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("step")]
    public int Step { get; set; }
}
