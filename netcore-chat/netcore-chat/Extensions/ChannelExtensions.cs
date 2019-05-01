using NetcoreChat.Domain.Entities;
using NetcoreChat.Dtos;

namespace NetcoreChat.Extensions
{
    public static class ChannelExtensions
    {
        public static Channel ToModel(this ChannelDto channel)
        {
            return new Channel
            {
                Name = channel.Name,
                Location = new Location
                {
                    Coordinates = new double[] { channel.Location.Longitude, channel.Location.Latitude }
                }
            };
        }

        public static ChannelDto ToDto(this Channel channel)
        {
            return new ChannelDto
            {
                Id = channel.Id,
                Name = channel.Name,
                Location = channel.Location == null ? null
                : new LocationDto
                {
                    Longitude = channel.Location.Coordinates[0],
                    Latitude = channel.Location.Coordinates[1]
                }
            };
        }
    }
}
