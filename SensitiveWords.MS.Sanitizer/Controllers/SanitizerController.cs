using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.KeyWords;
using SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.Messages;
using SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces;
using SensitiveWords.MS.Sanitizer.Models.KeyWords;
using SensitiveWords.MS.Sanitizer.Models.Messages;
using Swashbuckle.AspNetCore.Annotations;

namespace SensitiveWords.MS.Sanitizer.Controllers
{
    /// <summary>
    /// MicroService API Controller for functionality regarding sanitizing of messages.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class SanitizerController : ControllerBase
    {
        private readonly ILogger<SanitizerController> _logger;
        private readonly IKeyWordRepository _keyWordRepo;
        private readonly IMessageRepository _messageRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SanitizerController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="keyWordRepo">The key word repo.</param>
        /// <param name="messageRepo">The message repo.</param>
        public SanitizerController(ILogger<SanitizerController> logger, IKeyWordRepository keyWordRepo, IMessageRepository messageRepo)
        {
            _logger = logger;
            _keyWordRepo = keyWordRepo;
            _messageRepo = messageRepo;
        }

        #region Messages        
        /// <summary>
        /// Saves a new client message.
        /// </summary>
        /// <param name="request">Message payload.</param>
        /// <remarks>
        /// Saves the original message and returns the Inserted Row.
        /// </remarks>
        /// <response code="200">Inserted Row data returned</response>
        /// <response code="400">Failed to save message.</response>
        [HttpPost("postmessage")]
        [SwaggerOperation(
            Summary = "Create a new key word",
            Description = "Saves a new client message and returns the inserted row including the sanitized message."
        )]
        [ProducesResponseType(typeof(ClientMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostMessage([FromBody] SaveClientMessageRequestDto request)
        {
            if (string.IsNullOrEmpty(request.Message))
            {
                return BadRequest("No Message Found.");
            }
            try
            {
                var clientMessage = await _messageRepo.PostMessage(request);

                return Ok(clientMessage);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to save message.{Message}", e.Message);
                return BadRequest("Failed to save message.");
            }
        }

        /// <summary>
        /// Gets all client messages.
        /// </summary>
        /// <remarks>
        /// Returns all messages stored in the system.
        /// </remarks>
        /// /// <response code="200">Returns the list of messages</response>
        /// <response code="500">BadRequest:Failed to get messages.</response>
        [HttpGet("messages")]
        [SwaggerOperation(
            Summary = "Get all client messages",
            Description = "Returns all messages stored in the database."
        )]
        [ProducesResponseType(typeof(IEnumerable<ClientMessage>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMessages()
        {
            try
            {
                var messages = await _messageRepo.GetMessages();

                return Ok(messages ?? new List<ClientMessage>());
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to get messages.{Message}", e.Message);
                return BadRequest("Failed to get messages.");
            }
        }
        /// <summary>
        /// Deletes a client message.
        /// </summary>
        /// <param name="request">Client message ID Payload (object).</param>
        /// <response code="200">Returns true if deleted</response>
        /// <response code="404">Message not found</response>
        [HttpDelete("deletemessage")]
        [SwaggerOperation(
            Summary = "Delete a client message",
            Description = "Deletes a message by ClientMessageId."
        )]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMessage(DeleteClientMessageRequestDto request)
        {
            try
            {
                var success = await _messageRepo.DeleteClientMessage(request.ClientMessageId);

                return Ok(success);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to delete message.{Message}", e.Message);
                return BadRequest("Failed to delete message.");
            }
        }
        #endregion Messages
        #region KeyWords
        /// <summary>
        /// Gets all key words.
        /// </summary>
        /// <remarks>
        /// Returns all key words stored in the system.
        /// </remarks>
        /// /// <response code="200">Returns the list of key words</response>
        /// <response code="500">BadRequest:Failed to get key words.</response>
        [HttpGet("keywords")]
        [SwaggerOperation(
            Summary = "Get all key words",
            Description = "Returns all key words stored in the database."
        )]
        [ProducesResponseType(typeof(IEnumerable<KeyWord>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetKeywords()
        {
            try
            {
                var keyWords = await _keyWordRepo.GetKeyWords();

                return Ok(keyWords);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to get key words.{Message}", e.Message);
                return BadRequest("Failed to get key words.");
            }
        }
        /// <summary>
        /// Saves a new key word.
        /// </summary>
        /// <param name="request">key word payload.</param>
        /// <remarks>
        /// Saves the key word and returns the inserted row
        /// </remarks>
        /// <response code="200">Inserted Row data returned</response>
        /// <response code="400">Failed to save key word.</response>
        [HttpPost("postkeyword")]
        [SwaggerOperation(
            Summary = "Create a new key word",
            Description = "Saves a new key word and returns the inserted row."
        )]
        [ProducesResponseType(typeof(KeyWord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostKeyWord([FromBody] SaveKeyWordRequestDto request)
        {
            if (string.IsNullOrEmpty(request.Description))
            {
                return BadRequest("No Description Found.");
            }
            try
            {
                var keyWord = await _keyWordRepo.PostNewKeyWord(request.Description);

                return Ok(keyWord);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to save key word.{Message}", e.Message);
                return BadRequest("Failed to save key word.");
            }
        }
        /// <summary>
        /// Toggles the key word Active column.
        /// </summary>
        /// <param name="request">Toggle Key Word Request Dto consisting of SanitizerKeyWordId.</param>
        /// <remarks>
        /// Updates the key word record, toggles the active column, and returns the row.
        /// <response code="200">Updated row</response>
        /// <response code="400">Failed to update key word</response>
        /// </remarks>
        [HttpPost("togglekeyword")]
        public async Task<IActionResult> ToggleKeyWord([FromBody] ToggleKeyWordRequestDto request)
        {
            if (request.SanitizerKeyWordId <= 0)
            {
                return BadRequest("ID Required.");
            }
            try
            {
                var keyWord = await _keyWordRepo.ToggleKeyWord(request.SanitizerKeyWordId);
                return Ok(keyWord);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to update key word.{Message}", e.Message);
                return BadRequest("Failed to update key word.");
            }
        }
        #endregion KeyWords
    }
}
