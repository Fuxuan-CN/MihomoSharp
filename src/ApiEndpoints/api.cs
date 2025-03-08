
namespace MihomoSharp.ApiEndpoints;

public sealed class MihomoApiEndpoint
{
    public string BaseUrl { get; } = "https://api.mihomo.me";
    public string PlayerInfoEndpoint { get; } = "/sr_info_parsed";
    public string ActivityInfoEndpoint { get; } = "/sr_activity";
    public string IconEndpoint { get; } = "https://raw.githubusercontent.com/Mar-7th/StarRailRes/master";
}