using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InternshipPlannerServer
{
    public class Status
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Event { get; set; }

        public string Description { get; set; }

        public string Progress { get; set; }
    }
}