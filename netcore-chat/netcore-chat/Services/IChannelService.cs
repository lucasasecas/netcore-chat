using NetcoreChat.Models;
using System.Threading.Tasks;

namespace NetcoreChat.Services
{
    public interface IChannelService
    {
        Task<Channel> CreateAsync(Channel channel);
    }
}
