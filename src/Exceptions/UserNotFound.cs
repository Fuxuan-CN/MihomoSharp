

namespace MihomoSharp.Exceptions.UserNotFound;

public class UserNotFound : Exception
{
    public UserNotFound(string message) : base(message ?? "User not found")
    {
    }
}