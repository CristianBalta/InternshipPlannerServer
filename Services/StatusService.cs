using InternshipPlannerServer.Models;
using MongoDB.Driver;

namespace InternshipPlannerServer.Services
{
    public class StatusService
    {
        private readonly IMongoCollection<Status> _status;


        public StatusService(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _status = database.GetCollection<Status>(settings.StatusCollectionName);

        }


        public Status GetStatus(string id) =>
            _status.Find(status => status.Id == id).FirstOrDefault();

        public Status CreateStatus(Status status)
        {
            _status.InsertOne(status);
            return status;
        }

        public void DeleteStatus(string id)
        {
            _status.DeleteOne(need => need.Id == id);
        }

        public void UpdateStatus(string id, Status statusIn) =>
            _status.FindOneAndReplace(need => need.Id == id, statusIn);




    }
}