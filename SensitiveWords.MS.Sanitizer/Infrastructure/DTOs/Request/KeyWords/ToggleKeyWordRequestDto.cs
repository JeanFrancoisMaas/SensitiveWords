namespace SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.KeyWords
{
    /// <summary>
    /// Request object for toggling the active column on a key word.
    /// </summary>
    public class ToggleKeyWordRequestDto
    {
        /// <summary>
        /// Unique identifier of the message.
        /// </summary>
        public long SanitizerKeyWordId { get; set; }
    }
}
