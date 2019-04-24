using Microsoft.AspNetCore.Mvc;
using Moq;
using NetcoreChat.Controllers;
using NetcoreChat.Models;
using NetcoreChat.Services;
using System.Threading.Tasks;
using Xunit;

namespace NetcoreChatTests.Controllers
{
    public class ChannelsControllerTests
    {
        private readonly Mock<IChannelService> _channelServiceMock;
        private readonly Mock<IRoomService> _roomServiceMock;

        public ChannelsControllerTests()
        {
            _channelServiceMock = new Mock<IChannelService>();
            _roomServiceMock = new Mock<IRoomService>();
        }

        [Fact]
        public async Task Post_ShouldReturnOk_WhenServiceSaveCorrectly()
        {
            _channelServiceMock.Setup(x => x.CreateAsync(It.IsAny<Channel>())).ReturnsAsync(new Channel());

            var controller = new ChannelsController(_roomServiceMock.Object, _channelServiceMock.Object);

            var result = await controller.Post(new NetcoreChat.Dtos.ChannelDto());

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_WhenServiceReturnsNull()
        {
            _channelServiceMock.Setup(x => x.CreateAsync(It.IsAny<Channel>())).ReturnsAsync((Channel)null);

            var controller = new ChannelsController(_roomServiceMock.Object, _channelServiceMock.Object);

            var result = await controller.Post(new NetcoreChat.Dtos.ChannelDto());

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
