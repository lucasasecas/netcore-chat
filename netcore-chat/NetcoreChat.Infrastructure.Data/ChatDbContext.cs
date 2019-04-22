using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NetcoreChat.Domain.Entities;

namespace NetcoreChat.Infrastructure.Data
{
    public class ChatDbContext
    {
        private readonly IMongoDatabase _database;

        public ChatDbContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ChatDb"));
            _database = client.GetDatabase("ChatDb");
        }

        public IMongoCollection<Channel> Channels => _database.GetCollection<Channel>("Channels");
    }
}
