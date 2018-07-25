using System.Threading.Tasks;

using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Services {
    public interface ICommunicationService {
        Task<Response<string>> Send(string url);
    }
}
