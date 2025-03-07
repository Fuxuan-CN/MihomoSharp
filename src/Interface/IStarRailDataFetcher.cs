
using System.Threading.Tasks;
using MihomoSharp.Models.StarRailInfo;
using MihomoSharp.Models.LanguageSwitch;
using MihomoSharp.Models.BaseStarRailInfo;

namespace MihomoSharp.Interface;

// 定义接口，获取《崩坏星穹铁道》的规范
public interface IStarRailDataFetcher<TApiEndpoint, TData> where TData : BaseStarRailInfoData
{
    Task<TData> FetchUserAsync(string uid, Languages language = Languages.CHS);
    Task FetchIconAsync(object model, bool executeImmediately = false);
    Task FetchIconCommitAsync();
}