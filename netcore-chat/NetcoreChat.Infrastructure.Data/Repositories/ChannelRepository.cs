using System.Collections.Generic;
using System.Threading.Tasks;
using NetcoreChat.Domain.Entities;

namespace NetcoreChat.Infrastructure.Data.Repositories
{
    public class ChannelRepository : IRepository<Channel>
    {
        private readonly ChatDbContext _context;

        public ChannelRepository(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<Channel> CreateAsync(Channel channel)
        {
            try
            {
                await _context.Channels.InsertOneAsync(channel);

                return channel;
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Channel>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Channel> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(string id, Channel element)
        {
            throw new System.NotImplementedException();
        }
    }
}
