using NetcoreChat.Dtos;
using NetcoreChat.Models;

namespace NetcoreChat.Extensions
{
    public static class ChannelExtensions
    {
        public static Channel ToModel(this ChannelDto channel)
        {
            return new Channel
            {
                Name = channel.Name
            };
        }

        public static ChannelDto ToDto(this Channel channel)
        {
            return new ChannelDto
            {
                Id = channel.Id,
                Name = channel.Name
            };
        }
    }
}
