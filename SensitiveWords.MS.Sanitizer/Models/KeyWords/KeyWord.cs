namespace SensitiveWords.MS.Sanitizer.Models.KeyWords
{
    /// <summary>
    /// Represents a key word stored in the system.
    /// </summary>
    public class KeyWord
    {
        /// <summary>
        /// Unique identifier of the key word.
        /// </summary>
        public long SanitizerKeyWordId { get; set; }
        /// <summary>
        /// Text of the word (Description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Indicates whether the key word is active.
        /// </summary>
        public bool Active { get; set; }
    }
}
