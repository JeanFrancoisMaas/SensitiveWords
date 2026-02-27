using Azure.Core;
using Dapper;
using SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces;
using SensitiveWords.MS.Sanitizer.Models.KeyWords;
using SensitiveWords.MS.Sanitizer.ProcedureIndex;

namespace SensitiveWords.MS.Sanitizer.Infrastructure.Services
{
    /// <summary>
    /// Database layer for Key words
    /// </summary>
    /// <seealso cref="SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces.IKeyWordRepository" />
    public class KeyWordRepository : IKeyWordRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly IDapperExecutor _executor;
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyWordRepository"/> class.
        /// </summary>
        /// <param name="dbConnectionFactory">The database connection factory.</param>
        /// <param name="executor">The dapper executor (Mainly for mocking).</param>
        public KeyWordRepository(IDbConnectionFactory dbConnectionFactory, IDapperExecutor executor)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _executor = executor;
        }
        /// <summary>
        /// Gets all the key words saved in the database.
        /// </summary>
        /// <returns>
        /// IEnumberable of KeyWord
        /// </returns>
        public async Task<IEnumerable<KeyWord>> GetKeyWords()
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var keyWords = await _executor.QueryAsync<KeyWord>(connection, GetProcedures.GetAllKeyWords);


            return keyWords ?? new List<KeyWord>();
        }
        /// <summary>
        /// Saves a new key word.
        /// </summary>
        /// <param name="description">The description to be saved.</param>
        /// <returns>
        /// the inserted KeyWord
        /// </returns>
        public async Task<KeyWord> PostNewKeyWord(string description)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var param = new
            {
                Description = description ?? ""
            };

            var keyWord = await _executor.QueryFirstOrDefaultAsync<KeyWord>(connection, PostProcedures.CreateNewKeyWord, param);


            return keyWord;
        }
        /// <summary>
        /// Toggles the key word Active column.
        /// </summary>
        /// <param name="sanitizerKeyWordId">The sanitizer key word identifier.</param>
        /// <returns>
        /// The affected KeyWord
        /// </returns>
        public async Task<KeyWord> ToggleKeyWord(long sanitizerKeyWordId)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            var param = new
            {
                SanitizerKeyWordId = sanitizerKeyWordId
            };
            var keyWord = await _executor.QueryFirstOrDefaultAsync<KeyWord>(connection, UpdateProcedures.ToggleKeyWord, param);

            return keyWord;
        }
    }
}
