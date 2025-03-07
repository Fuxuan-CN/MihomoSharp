
namespace MihomoSharp.ApiEndpoints;

public class MihomoApiEndpoint
{
    public string BaseUrl { get; } = "https://api.mihomo.me";
    public string PlayerInfoEndpoint { get; } = "/sr_info_parsed";
    public string IconEndpoint { get; } = "https://raw.githubusercontent.com/Mar-7th/StarRailRes/master";
}