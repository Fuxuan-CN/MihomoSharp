using System.Threading.Tasks;
using MihomoSharp.Models.StarRailInfo;
using MihomoSharp.Models.LanguageSwitch;
using MihomoSharp.Models.BaseStarRailInfo;
using MihomoSharp.Models.BaseActivity;

namespace MihomoSharp.Interface;

// 定义接口，获取《崩坏星穹铁道》的规范
public interface IStarRailDataFetcher<TApiEndpoint, TUserData, TUserActivity> where TUserData : BaseStarRailInfoData where TUserActivity : BaseActivityInfo
{
    Task<TUserData> FetchUserAsync(string uid, Languages language = Languages.CHS, bool IsForceUpdate = false);
    Task<TUserActivity> FetchUserActivityAsync(string uid, Languages language = Languages.CHS, bool IsForceUpdate = false);
    Task FetchIconAsync(object model, bool executeImmediately = false);
    Task FetchIconCommitAsync();
}