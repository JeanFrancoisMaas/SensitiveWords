using Dapper;
using Microsoft.AspNetCore.Mvc;
using SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.Messages;
using SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces;
using SensitiveWords.MS.Sanitizer.Models.KeyWords;
using SensitiveWords.MS.Sanitizer.Models.Messages;
using SensitiveWords.MS.Sanitizer.ProcedureIndex;
using System.Text.RegularExpressions;

namespace SensitiveWords.MS.Sanitizer.Infrastructure.Services
{
    /// <summary>
    /// Database layer for Messages
    /// </summary>
    /// <seealso cref="SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces.IMessageRepository" />
    public class MessageRepository : IMessageRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly IDapperExecutor _executor;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageRepository"/> class.
        /// </summary>
        /// <param name="dbConnectionFactory">The database connection factory.</param>
        /// <param name="executor">The dapper executor (Mainly for mocking).</param>
        public MessageRepository(IDbConnectionFactory dbConnectionFactory, IDapperExecutor executor)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _executor = executor;
        }
        /// <summary>
        /// Deletes the client message.
        /// </summary>
        /// <param name="clientMessageId">The client message identifier.</param>
        /// <returns>
        /// True if success, False if failed
        /// </returns>
        public async Task<bool> DeleteClientMessage(long clientMessageId)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            var param = new { ClientMessageId = clientMessageId};
            var result = await _executor.ExecuteScalarAsync<bool>(connection, DeleteProcedures.DeleteClientMessage, param);
            return result;
        }
        /// <summary>
        /// Gets all client messages.
        /// </summary>
        /// <returns>
        /// IEnumerable of ClientMessage
        /// </returns>
        public async Task<IEnumerable<ClientMessage>> GetMessages()
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            return await _executor.QueryAsync<ClientMessage>(connection,GetProcedures.GetAllMessages);
        }
        /// <summary>
        /// Saves a new message.
        /// </summary>
        /// <param name="request">DTO conaining "Message" as a string property .</param>
        /// <returns></returns>
        public async Task<ClientMessage> PostMessage(SaveClientMessageRequestDto request)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            var param = new
            {
                Message = request.Message ?? ""
            };

            var result = await _executor.QueryFirstOrDefaultAsync<ClientMessage>(connection, PostProcedures.PostClientMessage, param);

            return result;
        }

        
    }
}
