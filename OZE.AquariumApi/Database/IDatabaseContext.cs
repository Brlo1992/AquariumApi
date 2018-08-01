using System.Collections.Generic;
using System.Threading.Tasks;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Database {
    public interface IDatabaseContext {
        Task<Response<List<T>>> GetAll<T>();
        Task<Response<T>> GetSingle<T>(int id);
        Task<Response> Add<T>(T item);
        Task<Response> Update<T>(T item);
        Task<Response> Remove<T>(int id);
    }
}
