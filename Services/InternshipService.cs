using InternshipPlannerServer.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace InternshipPlannerServer.Services
{
    public class InternshipService
    {
        private readonly IMongoCollection<Internship> _internships;

        public InternshipService(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _internships = database.GetCollection<Internship>(settings.InternshipsCollectionName);

        }

        public Internship GetInternship(string id) =>
            _internships.Find(internship => internship.Id == id).FirstOrDefault();

        public Internship CreateInternship(Internship internship)
        {
            internship.Status = new List<string>();
            _internships.InsertOne(internship);
            return internship;
        }

        public void DeleteInternship(string id)
        {
            _internships.DeleteOne(need => need.Id == id);
        }

        public void UpdateInternship(string id, Internship internshipIn) =>
            _internships.FindOneAndReplace(need => need.Id == id, internshipIn);



    }
}