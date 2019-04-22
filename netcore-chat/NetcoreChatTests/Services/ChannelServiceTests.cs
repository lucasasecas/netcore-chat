using Moq;
using NetcoreChat.Domain.Entities;
using NetcoreChat.Infrastructure.Data.Repositories;
using NetcoreChat.Services;
using System;
using Xunit;

namespace NetcoreChatTests.Services
{
    public class ChannelServiceTests
    {
        private readonly Mock<IRepository<Channel>> _repositoryMock;

        public ChannelServiceTests()
        {
            _repositoryMock = new Mock<IRepository<Channel>>();
        }

        [Fact]
        public async void CreateAsync_ShouldReturnChannel_WhenRepositoryDoesNotCrash()
        {
            _repositoryMock.Setup(x => x.CreateAsync(It.IsAny<Channel>())).ReturnsAsync(new Channel());
            var service = new ChannelService(_repositoryMock.Object);

            var result = await service.CreateAsync(new Channel());

            Assert.NotNull(result);
            Assert.IsType<Channel>(result);
        }

        [Fact]
        public async void CreateAsync_ShouldThrowException_WhenRepositoryThrowException()
        {
            _repositoryMock.Setup(x => x.CreateAsync(It.IsAny<Channel>())).ThrowsAsync(new Exception());
            var service = new ChannelService(_repositoryMock.Object);

            await Assert.ThrowsAsync<Exception>(() => service.CreateAsync(new Channel()));
        }
    }
}
