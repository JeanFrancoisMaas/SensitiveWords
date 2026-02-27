namespace SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.Messages
{
    /// <summary>
    /// Request object for saving a client message.
    /// </summary>
    public class SaveClientMessageRequestDto
    {
        /// <summary>
        /// The message text submitted by the client.
        /// </summary>
        /// <example>Select an Update statement</example>
        public string? Message { get; set; }
    }
}
