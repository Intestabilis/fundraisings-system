namespace WebApp.Contracts;

[Serializable]
public class BadRequestException : Exception
{
    public BadRequestException(string? message) : base(message)
    {
        
    }
    public BadRequestException(string? message, IDictionary<string, string[]> errors) : base(message)
    {
        Errors = errors;
    }
    public IDictionary<string, string[]> Errors { get; }
}