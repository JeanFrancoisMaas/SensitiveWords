using Moq;
using SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.KeyWords;
using SensitiveWords.MS.Sanitizer.Infrastructure.DTOs.Request.Messages;
using SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces;
using SensitiveWords.MS.Sanitizer.Infrastructure.Services;
using SensitiveWords.MS.Sanitizer.Models.KeyWords;
using SensitiveWords.MS.Sanitizer.ProcedureIndex;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveWords.Sanitizer.Tests.Unit_Tests
{
    public class KeyWordTests
    {
        [Fact] 
        public async Task GetKeyWords_ReturnsKeyWords()
        {
            var mockConnection = Mock.Of<IDbConnection>();
            var mockFactory = new Mock<IDbConnectionFactory>();
            var mockExecutor = new Mock<IDapperExecutor>();

            var expected = new List<KeyWord>
            {
                new KeyWord { SanitizerKeyWordId = 1, Description = "ACTION", Active = true },
                new KeyWord { SanitizerKeyWordId = 2, Description = "ADD", Active = true }
            };

            mockFactory
                .Setup(f => f.CreateConnection())
                .Returns(mockConnection);

            mockExecutor
                .Setup(e => e.QueryAsync<KeyWord>(
                    mockConnection,
                    GetProcedures.GetAllKeyWords))
                .ReturnsAsync(expected);

            var repository = new KeyWordRepository(
                mockFactory.Object,
                mockExecutor.Object);

            var result = await repository.GetKeyWords();

            Assert.Equal(2, result.Count());
            Assert.Equal("ACTION", result.First().Description);

            mockExecutor.Verify(e =>
                e.QueryAsync<KeyWord>(
                    mockConnection,
                    GetProcedures.GetAllKeyWords),
                Times.Once);
        }

        [Fact]
        public async Task PostNewKeyWord_ShouldReturnInsertedKeyWord()
        {
            var mockFactory = new Mock<IDbConnectionFactory>();
            var mockConnection = new Mock<IDbConnection>();
            var mockExecutor = new Mock<IDapperExecutor>();

            mockFactory.Setup(x => x.CreateConnection())
                       .Returns(mockConnection.Object);

            mockExecutor.Setup(x => x.QueryFirstOrDefaultAsync<KeyWord>(
                    mockConnection.Object,
                    It.IsAny<string>(),
                    It.IsAny<object>()))
                .ReturnsAsync(new KeyWord
                {
                    SanitizerKeyWordId = 1,
                    Description = "ACTION",
                    Active = true
                });

            var repo = new KeyWordRepository(
                mockFactory.Object,
                mockExecutor.Object);

            var result = await repo.PostNewKeyWord("ACTION");

            Assert.Equal("ACTION", result.Description);
        }

        [Fact]
        public async Task TOGGLEKeyword_ShouldReturnToggledKeyWord()
        {
            var mockFactory = new Mock<IDbConnectionFactory>();
            var mockConnection = new Mock<IDbConnection>();
            var mockExecutor = new Mock<IDapperExecutor>();

            mockFactory.Setup(x => x.CreateConnection())
                       .Returns(mockConnection.Object);

            mockExecutor.Setup(x => x.QueryFirstOrDefaultAsync<KeyWord>(
                    mockConnection.Object,
                    UpdateProcedures.ToggleKeyWord,
                    It.IsAny<object>()))
                .ReturnsAsync(new KeyWord
                {
                    SanitizerKeyWordId = 1,
                    Description = "ACTION",
                    Active = false
                });

            var repo = new KeyWordRepository(
                mockFactory.Object,
                mockExecutor.Object);

            var result = await repo.ToggleKeyWord(1);
            Assert.False(result.Active);
        }
    }
}
