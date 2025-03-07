using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MihomoSharp.ApiEndpoints;
using MihomoSharp.Interface;
using MihomoSharp.Models.StarRailInfo;
using MihomoSharp.Models.Player;
using MihomoSharp.Models.Character;
using MihomoSharp.Models.LanguageSwitch;
using MihomoSharp.Exceptions.UserNotFound;

namespace MihomoSharp.DataFetcher.Mihomo;

public sealed class MihomoDataFetcher : IStarRailDataFetcher<MihomoApiEndpoint, MihomoStarrailInfoParsed>, IDisposable, IAsyncDisposable
{
    private readonly HttpClient _httpClient;
    private readonly MihomoApiEndpoint _apiEndpoint = new MihomoApiEndpoint();
    private List<Task> _tasks = new List<Task>();
    private bool _disposed;

    #nullable enable
    public MihomoDataFetcher(HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
    }
    #nullable disable

    private (string iconUrl, string FileType) GetIconUrl(string Icon)
    {
        return ($"{_apiEndpoint.IconEndpoint}/{Icon}", Path.GetExtension(Icon));
    }

    private async Task FetchAsync(string FileName, string Url, string basePath = "icons")
    {
        var response = await _httpClient.GetAsync(Url);
        if (response.IsSuccessStatusCode)
        {
            byte[] data = await response.Content.ReadAsByteArrayAsync();
            await WriteIconBytesToFileAsync(data, FileName, basePath);
        }
        else
        {
            throw new HttpRequestException("Failed to fetch icon data.");
        }
    }

    public async Task FetchIconAsync(object Model, bool executeImmediately = false)
    {
        Task task = null;

        switch (Model)
        {
            case CharacterModel character:
                var icon = GetIconUrl(character.Icon);
                string characterName = character.Name;
                string characterFileName = $"{characterName}.{icon.FileType}";
                task = FetchAsync(characterFileName, icon.iconUrl, "icons/characters");
                break;

            case PlayerModel player:
                var avatar = GetIconUrl(player.Avatar.Icon);
                string uid = player.Uid;
                string playerFileName = $"{uid}_avatar.{avatar.FileType}";
                task = FetchAsync(playerFileName, avatar.iconUrl, "icons/player");
                break;

            default:
                throw new ArgumentException($"Invalid model type: {Model.GetType().Name}");
        }

        if (executeImmediately)
        {
            await task;  // 异步等待任务完成
        }
        else
        {
            _tasks.Add(task);
        }
    }

    public async Task FetchIconCommitAsync()
    {
        await Task.WhenAll(_tasks);
        _tasks.Clear(); // 清空任务列表
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

    public async Task<MihomoStarrailInfoParsed> FetchUserAsync(string uid, Languages language = Languages.CHS)
    {
        var url = $"{_apiEndpoint.BaseUrl}{_apiEndpoint.PlayerInfoEndpoint}/{uid}?lang={language.ToString().ToLower()}";
        var response = await _httpClient.GetAsync(url);

        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                var content = await response.Content.ReadAsStringAsync();
                var dat = JsonSerializer.Deserialize<MihomoStarrailInfoParsed>(content);
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

    public void Dispose()
    {
        if (!_disposed)
        {
            _httpClient?.Dispose();
            if (_tasks.Count > 0)
            {
                _tasks.Clear(); // 清空任务列表
            }
            _disposed = true;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            await Task.Run(() => Dispose());
        }
    }
}
