
# MihomoSharp

## Languages

- [Chinese Documentation](README.md)
- [English Documentation](README.EN.md)

## Description

MihomoSharp is a C# library for fetching and parsing player data from [Mihomo API](https://api.mihomo.me) for the game Honkai: Star Rail. It is a rewrite of the original Python version `mihomo`, which can be found at [Mihomo](https://github.com/KT-Yeh/mihomo).

- C# Version: .NET 9 (version must greater than .NET 5, because I used C# 10.0 features)

## Quick Start

### Installation

- Clone the project to your local machine

```bash
git clone https://github.com/Fuxuan-CN/MihomoSharp.git
```

- Open the project and install dependencies

```bash
cd MihomoSharp
dotnet restore
```

### Usage Example

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MihomoSharp.ApiEndpoints;
using MihomoSharp.DataFetcher.Mihomo;
using MihomoSharp.Models.LanguageSwitch;
using MihomoSharp.Exceptions.UserNotFound;

namespace MihomoSharpTest;

class Program
{
    static async Task Main(string[] args)
    {
        // 初始化客户端
        var dataFetcher = new MihomoDataFetcher();

        try
        {
            // 获取玩家数据
            var uid = "110554887"; // 示例 UID
            var language = Languages.CHS; // 选择语言
            var playerData = await dataFetcher.FetchUserAsync(uid, language);
            await dataFetcher.FetchIconAsync(playerData.Player);
            
            // 打印玩家信息
            Console.WriteLine($"玩家名: {playerData.Player.Name}");
            Console.WriteLine($"等级: {playerData.Player.Level}");
            Console.WriteLine($"玩家签名: {playerData.Player.Signature}");

            // 打印角色信息
            Console.WriteLine("\n展示的角色:");
            foreach (var character in playerData.Characters)
            {
                Console.WriteLine($"  - 名字: {character.Name}, 等级: {character.Level}, 角色星级: {character.Rarity}");
                await dataFetcher.FetchIconAsync(character);
            }

            await dataFetcher.FetchIconCommitAsync(); // 等待所有异步任务完成
        }
        catch (UserNotFound ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }
    }
}

```

### Fetch Player Avatar

```csharp
// please make sure the player type is PlayerModel, or you will get a ArgumentException
await client.FetchPlayerIconAsync(playerData.Player);
```

### Fetch Character Avatar

```csharp
// please make sure the character type is CharacterModel, or you will get a ArgumentException
await client.FetchCharacterIconAsync(character);
```

### commit fetch player avatar task

```csharp
// please make sure to invoke this method to execute your fetch tasks
// or you will get noting.
await client.FetchIconCommitAsync();
```

### don't want to invoke commit fetch icon method?

- don't worry, here is the code to fetch player avatar without invoking commit fetch player method.

```csharp
// ensure the obj is a PlayerModel or CharacterModel.
await client.FetchIconAsync(obj, executeImmediately: true);
```

### Project Progress

- [x] Re implementation of the original mihomo V2 version.
- [ ] Implementation of mihomo V1 API.
- [x] Provided examples showing how to use C# `System.Linq` for data filtering.

#### Using System.Linq for Data Filtering

The player data models provided by `MihomoSharp` can be directly used with C# `System.Linq` for flexible data filtering and processing. Here are some common examples:

##### Filter characters with rarity greater than or equal to 5

```csharp
var highRarityCharacters = playerData.Characters.Where(c => c.Rarity >= 5);
foreach (var character in highRarityCharacters)
{
    Console.WriteLine($"  - High Rarity Character: {character.Name}, Rarity: {character.Rarity}");
}
```

##### Filter characters with specific attributes

```csharp
var fireCharacters = playerData.Characters.Where(c => c.Element.Name == "Fire");
foreach (var character in fireCharacters)
{
    Console.WriteLine($"  - Fire Character: {character.Name}");
}
```

#### Sort characters by level

```csharp
var sortedCharacters = playerData.Characters.OrderByDescending(c => c.Level);
foreach (var character in sortedCharacters)
{
    Console.WriteLine($"  - Character: {character.Name}, Level: {character.Level}");
}
```

### Notes

- Player data is fetched using UID, not username.
- This project is for learning and open-source project use only. Any legal responsibilities caused are not related to the author.
- If you have any questions, please contact the author.

### PR Contributions

PR contributions are welcome to improve this project.

### Acknowledgments

- Thanks to [KT-Yeh](https://github.com/KT-Yeh) for the original `mihomo`, from which this project is rewritten.
- Thanks to the following contributors:

---
