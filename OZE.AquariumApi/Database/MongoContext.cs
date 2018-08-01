﻿using System.Collections.Generic;
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

        public Task<Response<T>> GetSingle<T>(int id) => throw new System.NotImplementedException();
        public Task<Response> Remove(int id) => throw new System.NotImplementedException();
        public Task<Response> Update<T>(T item) => throw new System.NotImplementedException();
        private IMongoCollection<T> GetCollection<T>() => client.GetDatabase(database).GetCollection<T>(collection);
        
    }
}
