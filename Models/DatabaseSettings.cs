

namespace InternshipPlannerServer.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString = "mongodb://localhost:27017";

        public string DatabaseName = "InternshipPlanner";

        public string UserCollectionName = "User";

        public string InternshipsCollectionName = "Internship";

        public string StatusCollectionName = "Status";
    }

}
