
namespace MihomoSharp.Exceptions.ApiMissing;

// exception raised when an API is missing
public class ApiMissingException : Exception
{
    public ApiMissingException(string message) : base(message)
    {
    }
}