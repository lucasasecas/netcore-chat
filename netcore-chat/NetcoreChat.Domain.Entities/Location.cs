using MongoDB.Bson.Serialization.Attributes;

namespace NetcoreChat.Domain.Entities
{
    public class Location
    {
        [BsonElement("type")]
        public string Type { get; } = "Point";

        [BsonElement("coordinates")]
        public double[] Coordinates { get; set; }
    }
}