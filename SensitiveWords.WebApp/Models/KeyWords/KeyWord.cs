namespace SensitiveWords.WebApp.Models.KeyWords
{
    public class KeyWord
    {
        public long SanitizerKeyWordId { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
    }
}
