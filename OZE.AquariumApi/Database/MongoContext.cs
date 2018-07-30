using System.Collections.Generic;
using MongoDB.Driver;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Database {
    //@"mongodb://aquarium-db:uzFtIk2SWnmF2VayfTkx8i4fPt6WoyZSCfTXjbDN5MWhhVAUpaaKZpmNEoBmGPtM9WL2rckZ9qt9SE8PdYiJ6A==@aquarium-db.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

    public class MongoContext : IDatabaseContext {
        private readonly MongoClient client;
        private readonly string database;
        private readonly string collection;

        public MongoContext(string url, string database, string collection) {
            client = new MongoClient(MongoClientSettings.FromUrl(
              new MongoUrl(url)
            ));
            this.database = database;
            this.collection = collection;
        }

        public Response Add<T>(T item) {
            var response = new Response<T>();

            try {
                GetCollection<T>().InsertOne(item);
            }
            catch (System.Exception ex) {
                response.AddError(ex.Message);
            }

            return response;
        }

        public Response<List<T>> GetAll<T>() {
            var response = new Response<List<T>>();

            try {
                var result = GetCollection<T>().AsQueryable();
                response.Content = result.ToList<T>();
            }
            catch (System.Exception ex) {
                response.AddError(ex.Message);
            }

            return response;
        }

        private IMongoCollection<T> GetCollection<T>() => client.GetDatabase(database).GetCollection<T>(collection);
        public Response<T> GetSingle<T>(int id) => throw new System.NotImplementedException();
        public Response Remove(int id) => throw new System.NotImplementedException();
        public void SaveChanges() => throw new System.NotImplementedException();
        public Response Update<T>(T item) => throw new System.NotImplementedException();
    }
}
