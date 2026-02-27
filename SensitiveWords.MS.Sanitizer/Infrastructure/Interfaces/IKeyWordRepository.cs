using SensitiveWords.MS.Sanitizer.Models.KeyWords;

namespace SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces
{
    /// <summary>
    /// Database layer for Key words
    /// </summary>
    public interface IKeyWordRepository
    {
        /// <summary>
        /// Gets all the key words saved in the database.
        /// </summary>
        /// <returns>IEnumberable of KeyWord</returns>
        Task<IEnumerable<KeyWord>> GetKeyWords();
        /// <summary>
        /// Saves a new key word.
        /// </summary>
        /// <param name="description">The description to be saved.</param>
        /// <returns>the inserted KeyWord</returns>
        Task<KeyWord> PostNewKeyWord(string description);
        /// <summary>
        /// Toggles the key word Active column.
        /// </summary>
        /// <param name="sanitizerKeyWordId">The sanitizer key word identifier.</param>
        /// <returns>The affected KeyWord</returns>
        Task<KeyWord> ToggleKeyWord(long sanitizerKeyWordId);
    }
}
