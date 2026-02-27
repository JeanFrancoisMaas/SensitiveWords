using SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.Messages;
using SensitiveWords.MS.Sanitizer.Models.Messages;

namespace SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces
{
    /// <summary>
    /// Database layer for Messages
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Deletes the client message.
        /// </summary>
        /// <param name="clientMessageId">The client message identifier.</param>
        /// <returns>True if success, False if failed</returns>
        Task<bool> DeleteClientMessage(long clientMessageId);
        /// <summary>
        /// Gets all client messages.
        /// </summary>
        /// <returns>IEnumerable of ClientMessage</returns>
        Task<IEnumerable<ClientMessage>> GetMessages();
        /// <summary>
        /// Saves a new message.
        /// </summary>
        /// <param name="request">DTO conaining "Message" as a string property .</param>
        /// <returns></returns>
        Task<ClientMessage> PostMessage(SaveClientMessageRequestDto request);


    }
}
