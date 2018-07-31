using System.Collections.Generic;
using System.Security.Authentication;
using MongoDB.Driver;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Database {
    public class MongoContext : IDatabaseContext {
        private readonly MongoClient client;
        private readonly string database;
        private readonly string collection;

        public MongoContext(string url, string database, string collection) {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(url));

            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            client = new MongoClient(settings);

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
