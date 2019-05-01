using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NetcoreChat.Domain.Entities;

namespace NetcoreChat.Infrastructure.Data
{
    public class ChatDbContext
    {
        private readonly IMongoDatabase _db;

        public ChatDbContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ChatDb"));
            _db = client.GetDatabase("ChatDb");

            if (_db.GetCollection<Channel>("Channels") == null)
                _db.CreateCollection("Channels");

            Channels.Indexes.CreateOne(Builders<Channel>.IndexKeys.Geo2DSphere(x => x.Location));
        }

        public IMongoCollection<Channel> Channels => _db.GetCollection<Channel>("Channels");
    }
}
