using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
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

        public async Task<ICollection<Channel>> FindNear(Location location, long maxDistance = 100)
        {
            var point = GeoJson.Point(GeoJson.Geographic(location.Coordinates[0], location.Coordinates[1]));
            var filter = Builders<Channel>.Filter.Near(x => x.Location, point, maxDistance);
            var iterator = await _context.Channels.FindAsync<Channel>(filter);
            return iterator.ToList();
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
