using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Services {
    public interface IDeserializeService {
        Response<T> Deserialize<T>(Response<string> response);
    }
}