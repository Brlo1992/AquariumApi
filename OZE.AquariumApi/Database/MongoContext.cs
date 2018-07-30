using System.Collections.Generic;
using MongoDB.Driver;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Database {
    //@"mongodb://aquarium-db:uzFtIk2SWnmF2VayfTkx8i4fPt6WoyZSCfTXjbDN5MWhhVAUpaaKZpmNEoBmGPtM9WL2rckZ9qt9SE8PdYiJ6A==@aquarium-db.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

    public class MongoContext : IDatabaseContext {
        private readonly MongoClient client;
        public MongoContext(string url) {
            client = new MongoClient(MongoClientSettings.FromUrl(
              new MongoUrl(url)
            ));
        }

        public Response Add<T>(T item) => throw new System.NotImplementedException();
        public Response<List<T>> GetAll<T>() => throw new System.NotImplementedException();
        public Response<T> GetSingle<T>(int id) => throw new System.NotImplementedException();
        public Response Remove(int id) => throw new System.NotImplementedException();
        public Response Update<T>(T item) => throw new System.NotImplementedException();
    }
}
