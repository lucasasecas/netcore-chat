using NetcoreChat.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetcoreChat.Services
{
    public interface IChannelService
    {
        Task<Channel> CreateAsync(Channel channel);
        Task<ICollection<Channel>> GetNearbyChannels(double[] position);
    }
}
