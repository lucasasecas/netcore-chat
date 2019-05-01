using System.Collections.Generic;
using System.Threading.Tasks;
using NetcoreChat.Domain.Entities;
using NetcoreChat.Infrastructure.Data.Repositories;

namespace NetcoreChat.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IRepository<Channel> _channelRepository;

        public ChannelService(IRepository<Channel> channelRepository)
        {
            _channelRepository = channelRepository;
        }

        public async Task<Channel> CreateAsync(Channel channel)
        {
            return await _channelRepository.CreateAsync(channel);
        }

        public Task<ICollection<Channel>> GetNearbyChannels(double[] position)
        {
            return _channelRepository.FindNear(new Location
            {
                Coordinates = new double[] { position[1], position[0]}
            });
        }
    }
}
