using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NetcoreChat.Models;

namespace NetcoreChat.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IMongoCollection<Channel> _channels;

        public ChannelService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("ChatDb"));
            var database = client.GetDatabase("BookstoreDb");
            _channels = database.GetCollection<Channel>("Channels");
        }

        public async Task<Channel> CreateAsync(Channel channel)
        {
            await _channels.InsertOneAsync(channel);

            return channel;
        }
    }
}
