namespace SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.KeyWords
{
    /// <summary>
    /// Request object for saving a key word.
    /// </summary>
    public class SaveKeyWordRequestDto
    {
        /// <summary>
        /// The key word text submitted by the client.
        /// </summary>
        /// <example>Update</example>
        public string? Description { get; set; }
    }
}
