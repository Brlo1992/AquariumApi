using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
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

        public async Task<Response> Add<T>(T item) {
            var response = new Response<T>();

            try {
                await GetCollection<T>().InsertOneAsync(item);
            }
            catch (System.Exception ex) {
                response.AddError(ex.Message);
            }

            return response;
        }

        public async Task<Response<List<T>>> GetAll<T>() {
            var response = new Response<List<T>>();

            try {
                response.Content = await GetCollection<T>().AsQueryable().ToListAsync();
            }
            catch (System.Exception ex) {
                response.AddError(ex.Message);
            }

            return response;
        }

        public async Task<Response<T>> GetSingle<T>(int id) {
            var response = new Response<T>();

            var filter = GetIdFilter<T>(id);

            try {
                var result = await GetCollection<T>().FindAsync<T>(filter);
                response.Content = await result.FirstOrDefaultAsync();
            }
            catch (System.Exception ex) {
                response.AddError(ex.Message);
            }

            return response;
        }

        private FilterDefinition<T> GetIdFilter<T>(int id) {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq("id", id);

            return filter;
        }

        public async Task<Response> Remove<T>(int id) {
            var response = new Response();

            var exist = await DoExist<T>(id);

            if (exist) {
                var filter = GetIdFilter<T>(id);

                try {
                    await GetCollection<T>().FindOneAndDeleteAsync(filter);
                }
                catch (System.Exception ex) {
                    response.AddError(ex.Message);
                }
            }

            return response;
        }

        public Task<Response> Update<T>(T item) => throw new System.NotImplementedException();

        private async Task<bool> DoExist<T>(int id) {
            var result = await GetSingle<T>(id);

            return result.Content != null;
        }

        private IMongoCollection<T> GetCollection<T>() => client.GetDatabase(database).GetCollection<T>(collection);
        
    }
}
