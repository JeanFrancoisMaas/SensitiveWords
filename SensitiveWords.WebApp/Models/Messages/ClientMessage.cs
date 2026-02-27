namespace SensitiveWords.WebApp.Models.Messages
{
    public class ClientMessage
    {
        public long ClientMessageId { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? SanitizedMessage { get; set; }
        public bool Active { get; set; }
    }
}
