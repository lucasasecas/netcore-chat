﻿namespace NetcoreChat.Domain.Entities
{
    public class Channel
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("Name")]
        public string Name { get; set; }
    }
}
