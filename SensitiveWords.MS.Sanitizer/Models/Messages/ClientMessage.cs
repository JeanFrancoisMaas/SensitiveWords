namespace SensitiveWords.MS.Sanitizer.Models.Messages
{
    /// <summary>
    /// Represents a client message stored in the system.
    /// </summary>
    public class ClientMessage
    {
        /// <summary>
        /// Unique identifier of the message.
        /// </summary>
        public long ClientMessageId { get; set; }
        /// <summary>
        /// Original message text.
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// Date the message was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Indicates whether the message is active.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Sanitized message text.
        /// </summary>
        public string? SanitizedMessage { get; set; }
    }
}
