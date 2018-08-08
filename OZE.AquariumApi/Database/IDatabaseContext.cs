using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Database {
    public interface IDatabaseContext {
        Task<Response<List<T>>> GetAll<T>();
        Task<Response<T>> GetSingle<T>(ObjectId id);
        Task<Response> Add<T>(T item);
        Task<Response> Update<T>(T item, ObjectId id);
        Task<Response> Remove<T>(ObjectId id);
    }
}
