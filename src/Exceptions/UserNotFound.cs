

namespace MihomoSharp.Exceptions.UserNotFound;

public sealed class UserNotFound : Exception
{
    public UserNotFound(string message) : base(message ?? "User not found")
    {
    }
}