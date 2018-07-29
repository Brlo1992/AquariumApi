using MongoDB.Driver;

namespace OZE.AquariumApi.Database {
    //@"mongodb://aquarium-db:uzFtIk2SWnmF2VayfTkx8i4fPt6WoyZSCfTXjbDN5MWhhVAUpaaKZpmNEoBmGPtM9WL2rckZ9qt9SE8PdYiJ6A==@aquarium-db.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

    public class MongoContext : IDatabaseContext {
        private readonly MongoClient client;
        public MongoContext(string url) {
            client = new MongoClient(MongoClientSettings.FromUrl(
              new MongoUrl(url)
            ));
        }
    }
}
