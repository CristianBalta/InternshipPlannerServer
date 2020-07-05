using System.Collections.Generic;
using com.sun.corba.se.impl.protocol.giopmsgheaders;
using com.sun.org.apache.xml.@internal.resolver.helpers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InternshipPlannerServer
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<string> Internships { get; set; }



        public string afisare()
        {
            return "cialut";
        }
    }
}