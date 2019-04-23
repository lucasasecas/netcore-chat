using Microsoft.AspNetCore.Mvc;
using Moq;
using NetcoreChat.Controllers;
using NetcoreChat.Services;
using System.Threading.Tasks;
using Xunit;

namespace NetcoreChatTests.Controllers
{
    public class ChannelsControllerTests
    {
        private readonly Mock<IChannelService> _channelServiceMock;
        private readonly Mock<IRoomService> _roomServiceMock;

        [Fact]
        public async Task Post_ShouldReturnOk_WhenServiceSaveCorrectly()
        {
            var controller = new ChannelsController(_roomServiceMock.Object, _channelServiceMock.Object);

            var result = await controller.Post(new NetcoreChat.Dtos.ChannelDto());

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }


    }
}
