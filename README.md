# MihomoSharp

## 语言 / Language

- [中文文档](README.md)
- [English Documentation](README.EN.md)

## 描述

MihomoSharp 是一个基于 C# 的库，用于从 [Mihomo API](https://api.mihomo.me) 获取和解析《崩坏：星穹铁道》（Honkai: Star Rail）的玩家数据。它是基于 Python 版本的 `mihomo` 重构而来，源地址为：[Mihomo](https://github.com/KT-Yeh/mihomo)。

- C# 版本: .NET 9 (理论上来说 .NET 5 以上都可以，不包含.NET5，因为用了C# 10的语法)

## 示例用法（快速开始）

### 安装

- 克隆项目到本地：

```bash
git clone https://github.com/Fuxuan-CN/MihomoSharp.git
```

- 打开项目并安装依赖：

```bash
cd MihomoSharp
dotnet restore
```

### 示例用法

```csharp
using System;
using System.Threading.Tasks;
using MihomoSharp.Core.Client;
using MihomoSharp.Models.StarRailInfo;
using MihomoSharp.Models.LanguageSwitch;
using MihomoSharp.Exceptions.UserNotFound;

namespace YourNamespace;

class Program
{
    static async Task Main(string[] args)
    {
        // 初始化客户端
        var client = new MihomoClient();

        try
        {
            // 获取玩家数据
            var uid = "110554887"; // 示例 UID
            var language = Languages.CHS; // 选择语言
            var playerData = await client.FetchUserAsync(uid, language);
            
            // 打印玩家信息
            Console.WriteLine($"玩家名: {playerData.Player.Name}");
            Console.WriteLine($"等级: {playerData.Player.Level}");
            Console.WriteLine($"玩家签名: {playerData.Player.Signature}");

            // 打印角色信息
            Console.WriteLine("\n展示的角色:");
            foreach (var character in playerData.Characters)
            {
                Console.WriteLine($"  - 名字: {character.Name}, 等级: {character.Level}, 角色星级: {character.Rarity}");
            }
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

### 获取玩家头像

```csharp
// 确保playerData是PlayerData类型，不然会抛出ArgumentException
await client.FetchIconAsync(playerData.Player);
```

### 获取角色头像

```csharp
// 确保character是CharacterModel类型，不然会抛出ArgumentException
await client.FetchIconAsync(character);
```

### 下载头像任务提交

```csharp
// 最后，不要忘了提交头像下载任务噢!
await client.FetchIconCommitAsync(); // 提交所有头像下载任务
```

### 不想显示提交，希望立即执行咋办？

- 没事，我提供了一个选项，可以不显示提交，立即执行头像下载任务。

```csharp
// 确保 obj 是 PlayerData 或 CharacterModel 类型，不然会抛出 ArgumentException
await client.FetchIconAsync(obj, executeImmediately: true); // 不显示提交，立即执行
```

### 项目进度

- [x] 实现了原 mihomo V2 版本的重构。
- [ ] 实现 mihomo V1 版本的 API。
- [x] 提供示例，展示如何使用 C# 的 `System.Linq` 实现数据筛选。

#### 使用 System.Linq 进行数据筛选

`MihomoSharp` 提供的玩家数据模型可以直接与 C# 的 `System.Linq` 结合使用，实现灵活的数据筛选和处理。以下是一些常见示例：

##### 筛选稀有度大于等于 5 的角色

```csharp
var highRarityCharacters = playerData.Characters.Where(c => c.Rarity >= 5);
foreach (var character in highRarityCharacters)
{
    Console.WriteLine($"  - High Rarity Character: {character.Name}, Rarity: {character.Rarity}");
}
```

##### 筛选特定属性的角色

```csharp
var fireCharacters = playerData.Characters.Where(c => c.Element.Name == "Fire");
foreach (var character in fireCharacters)
{
    Console.WriteLine($"  - Fire Character: {character.Name}");
}
```

#### 按照等级排序角色

```csharp
var sortedCharacters = playerData.Characters.OrderByDescending(c => c.Level);
foreach (var character in sortedCharacters)
{
    Console.WriteLine($"  - Character: {character.Name}, Level: {character.Level}");
}
```

### 注意事项

- 获取玩家数据需要使用 UID，而非用户名。
- 此项目仅供学习交流或者开源项目使用，所有造成的法律责任与作者无关。
- 如有任何问题，请联系作者。

### PR 贡献

欢迎提交 PR，共同完善此项目。

### 鸣谢

- 感谢 [KT-Yeh](https://github.com/KT-Yeh) mihomo，本项目基于其重构而来。
- 感谢以下参与贡献的开发者：

---
