namespace SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.Messages
{
    /// <summary>
    /// Request object for deleting a client message.
    /// </summary>
    public class DeleteClientMessageRequestDto
    {
        /// <summary>
        /// Unique identifier of the message.
        /// </summary>
        public long ClientMessageId { get; set; }
    }
}
