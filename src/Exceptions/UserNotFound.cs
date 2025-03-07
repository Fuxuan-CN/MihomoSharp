

namespace MihomoSharp.Exceptions.UserNotFound;

// raised when a user is not found in the data resource(s).
public sealed class UserNotFound : Exception
{
    public UserNotFound(string message) : base(message ?? "User not found")
    {
    }
}