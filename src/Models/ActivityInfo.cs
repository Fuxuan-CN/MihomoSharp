
using MihomoSharp.Models.BaseActivity;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MihomoSharp.Models.ActivityInfo;

public sealed class MihomoActivityInfo : BaseActivityInfo
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; }

    [JsonPropertyName("info")]
    public List<UserActInfo> Infos { get; set; }
}

public sealed class UserActInfo
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("content")]
    public UserActInfoContent Content { get; set; }
}

public sealed class UserActInfoContent
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("param")]
    public string Param { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}