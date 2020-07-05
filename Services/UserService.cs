using InternshipPlannerServer.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace InternshipPlannerServer.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);

        }

        public User GetUser(string id) =>
           _users.Find(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {

            user.Internships = new List<string>();
            _users.InsertOne(user);
            return user;
        }

        public void UpdateUser(string id, User userIn) =>
            _users.FindOneAndReplace(user => user.Id == id, userIn);

        public User Login(string email, string password) =>
           _users.Find(user => user.Email == email && user.Password == password).FirstOrDefault();
    }
}