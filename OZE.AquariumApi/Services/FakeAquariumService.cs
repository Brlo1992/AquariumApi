using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services
{
    public class FakeAquariumService : IAquariumService {
        public Task<Response<IEnumerable<StatusViewModel>>> GetLedPins() => throw new NotImplementedException();
        public Task<Response<StatusViewModel>> TurnOff() => throw new NotImplementedException();
        public Task<Response<StatusViewModel>> TurnOffLedSet(int id) => throw new NotImplementedException();
        public Task<Response<StatusViewModel>> TurnOn() => throw new NotImplementedException();
        public Task<Response<StatusViewModel>> TurnOnLedSet(int id) => throw new NotImplementedException();
    }
}
