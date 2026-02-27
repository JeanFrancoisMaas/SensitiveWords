using Microsoft.AspNetCore.Connections;
using Moq;
using SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.Messages;
using SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces;
using SensitiveWords.MS.Sanitizer.Infrastructure.Services;
using SensitiveWords.MS.Sanitizer.Models.Messages;
using SensitiveWords.MS.Sanitizer.ProcedureIndex;
using SensitiveWords.WebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveWords.Sanitizer.Tests.Unit_Tests
{
    public class MessageTests
    {
        [Fact]
        public async Task GetMessages_ReturnsMessages()
        {
            var mockConnection = Mock.Of<IDbConnection>();
            var mockFactory = new Mock<IDbConnectionFactory>();
            var mockExecutor = new Mock<IDapperExecutor>();

            var expected = new List<ClientMessage>
            {
                new ClientMessage { ClientMessageId = 1, Message = "SELECT" },
                new ClientMessage { ClientMessageId = 2, Message = "UPDATE" }
            };

            mockFactory
                .Setup(f => f.CreateConnection())
                .Returns(mockConnection);

            mockExecutor
                .Setup(e => e.QueryAsync<ClientMessage>(
                    mockConnection,
                    GetProcedures.GetAllMessages))
                .ReturnsAsync(expected);

            var repository = new MessageRepository(
                mockFactory.Object,
                mockExecutor.Object);

            var result = await repository.GetMessages();

            Assert.Equal(2, result.Count());
            Assert.Equal("SELECT", result.First().Message);

            mockExecutor.Verify(e =>
                e.QueryAsync<ClientMessage>(
                    mockConnection,
                    GetProcedures.GetAllMessages),
                Times.Once);
        }

        [Fact]
        public async Task PostMessage_ShouldReturnInsertedMessage()
        {
            var mockFactory = new Mock<IDbConnectionFactory>();
            var mockConnection = new Mock<IDbConnection>();
            var mockExecutor = new Mock<IDapperExecutor>();

            mockFactory.Setup(x => x.CreateConnection())
                       .Returns(mockConnection.Object);

            mockExecutor.Setup(x => x.QueryFirstOrDefaultAsync<ClientMessage>(
                    mockConnection.Object,
                    It.IsAny<string>(),
                    It.IsAny<object>()))
                .ReturnsAsync(new ClientMessage
                {
                    ClientMessageId = 1,
                    Message = "UPDATE",
                    SanitizedMessage = "******",
                    CreatedDate = DateTime.UtcNow,
                    Active = true
                });

            var repo = new MessageRepository(
                mockFactory.Object,
                mockExecutor.Object);

            var result = await repo.PostMessage(new SaveClientMessageRequestDto
            {
                Message = "UPDATE"
            });

            Assert.Equal("******", result.SanitizedMessage);
        }

        [Fact]
        public async Task DELETEMessage_ShouldReturnBoolean()
        {
            var mockFactory = new Mock<IDbConnectionFactory>();
            var mockConnection = new Mock<IDbConnection>();
            var mockExecutor = new Mock<IDapperExecutor>();

            mockFactory.Setup(x => x.CreateConnection())
                       .Returns(mockConnection.Object);

            mockExecutor.Setup(x => x.ExecuteScalarAsync<bool>(
                It.IsAny<IDbConnection>(),
                DeleteProcedures.DeleteClientMessage,
                It.IsAny<object>()))
            .ReturnsAsync(true);

            var repo = new MessageRepository(
                mockFactory.Object,
                mockExecutor.Object);

            var result = await repo.DeleteClientMessage(1);

            Assert.True(result);

            mockExecutor.Verify(x => x.ExecuteScalarAsync<bool>(
                It.IsAny<IDbConnection>(),
                DeleteProcedures.DeleteClientMessage,
                It.IsAny<object>()),
            Times.Once);

        }
    }
}
