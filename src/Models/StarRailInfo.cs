using System.Collections.Generic;
using System.Text.Json.Serialization;
using MihomoSharp.Models.Player;
using MihomoSharp.Models.Character;
using MihomoSharp.Models.BaseStarRailInfo;

namespace MihomoSharp.Models.StarRailInfo;


//继承BaseStarRailInfoData确保返回的数据正确
public sealed class MihomoStarrailInfoParsed : BaseStarRailInfoData
{
    [JsonPropertyName("player")]
    public PlayerModel Player { get; set; }

    [JsonPropertyName("characters")]
    public List<CharacterModel> Characters { get; set; }
}
