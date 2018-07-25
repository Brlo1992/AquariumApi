using System;
using System.Threading.Tasks;

using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Services {
    public class CommunicationService : ICommunicationService {
        public Task<Response<string>> Send(string url) => throw new NotImplementedException();
    }
}
