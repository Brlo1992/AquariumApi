using System.Collections.Generic;

using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Database {
    public interface IDatabaseContext {
        Response<List<T>> GetAll<T>();
        Response<T> GetSingle<T>(int id);
        Response Add<T>(T item);
        Response Update<T>(T item);
        Response Remove(int id);    }
}
