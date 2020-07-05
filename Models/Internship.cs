using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InternshipPlannerServer
{
    public class Internship
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }
        public string Paid { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public List<string> Status { get; set; }
    }
}