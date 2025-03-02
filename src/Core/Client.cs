using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MihomoSharp.Models.StarRailInfo;
using MihomoSharp.Models.Player;
using MihomoSharp.Models.Character;
using MihomoSharp.Models.LanguageSwich;
using MihomoSharp.Exceptions.UserNotFound;

namespace MihomoSharp.Core.Client;

public class MihomoClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://api.mihomo.me/sr_info_parsed";
    private readonly string _assertUrl = "https://raw.githubusercontent.com/Mar-7th/StarRailRes/master";

    public MihomoClient()
    {
        _httpClient = new HttpClient();
    }

    private (string iconUrl, string FileType) GetIconUrl(string Icon)
    {
        return ($"{_assertUrl}/{Icon}", Path.GetExtension(Icon));
    }

    private async Task FetchAsync(string FileName, string Url, string basePath = "icons")
    {
        var response = await _httpClient.GetAsync(Url);
        if (response.IsSuccessStatusCode)
        {
            byte[] data = await response.Content.ReadAsByteArrayAsync();
            await WriteIconBytesToFileAsync(data, FileName, basePath);
        }
    }

    public async Task FetchIconAsync(object Model)
    {
        List<Task> tasks = new List<Task>();

        switch (Model)
        {
            case CharacterModel character:
                var icon = GetIconUrl(character.Icon);
                string Name = character.Name;
                string AllName = $"{Name}.{icon.FileType}";
                tasks.Add(FetchAsync(AllName, icon.iconUrl, "icons/characters"));
                break;
            case PlayerModel player:
                var avatar = GetIconUrl(player.Avatar.Icon);
                string uid = player.Uid;
                string name = $"{uid}_avatar.{avatar.FileType}";
                tasks.Add(FetchAsync(name, avatar.iconUrl, "icons/player"));
                break;
            default:
                throw new ArgumentException($"Invalid model type. {nameof(Model)}");
        }

        // 等待所有任务完成
        await Task.WhenAll(tasks);
    }

    public async Task WriteIconBytesToFileAsync(byte[] data, string name, string basePath = "icons")
    {
        if (!Directory.Exists(basePath))
        {
            Directory.CreateDirectory(basePath);
        }
        string path = Path.Combine(basePath, name);
        // 这里确认文件如果存在的话，就不重复写入磁盘
        if (!File.Exists(path))
        {
            await File.WriteAllBytesAsync(path, data);
        }
    }

    

    public async Task<StarrailInfoParsed> FetchUserAsync(string uid, Languages language = Languages.CHS)
    {
        var url = $"{_baseUrl}/{uid}?lang={language.ToString().ToLower()}";
        var response = await _httpClient.GetAsync(url);

        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                var content = await response.Content.ReadAsStringAsync();
                var dat = JsonSerializer.Deserialize<StarrailInfoParsed>(content);
                return dat;
            case System.Net.HttpStatusCode.NotFound:
                throw new UserNotFound("User not found.");
            case System.Net.HttpStatusCode.BadRequest:
                var ErrorMessage = JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync())["detail"];
                throw new ArgumentException($"Invalid parameters, reason: {ErrorMessage}.");
            default:
                throw new HttpRequestException("Failed to fetch user data.");
        }
    }
}
