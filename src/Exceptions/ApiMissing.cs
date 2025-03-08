
namespace MihomoSharp.Exceptions.ApiMissing;

// exception raised when an API is missing
public sealed class ApiMissingException : Exception
{
    public ApiMissingException(string message) : base(message)
    {
    }
}