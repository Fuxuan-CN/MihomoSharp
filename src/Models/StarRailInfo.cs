using System.Collections.Generic;
using System.Text.Json.Serialization;
using MihomoSharp.Models.Player;
using MihomoSharp.Models.Character;

namespace MihomoSharp.Models.StarRailInfo;

public sealed class StarrailInfoParsed
{
    [JsonPropertyName("player")]
    public PlayerModel Player { get; set; }

    [JsonPropertyName("characters")]
    public List<CharacterModel> Characters { get; set; }
}
