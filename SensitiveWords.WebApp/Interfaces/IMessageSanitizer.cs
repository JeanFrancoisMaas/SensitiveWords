namespace SensitiveWords.WebApp.Interfaces
{
    public interface IMessageSanitizer
    {
        string Sanitize(string message);
    }
}
