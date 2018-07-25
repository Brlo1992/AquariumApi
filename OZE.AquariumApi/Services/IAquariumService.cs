using System.Collections.Generic;
using System.Threading.Tasks;

using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services {
    public interface IAquariumService {
        Task<Response<StatusViewModel>> TurnOn();
        Task<Response<StatusViewModel>> TurnOff();
        Task<Response<StatusViewModel>> TurnOnLedSet(int id);
        Task<Response<StatusViewModel>> TurnOffLedSet(int id);
        Task<Response<IEnumerable<int>>> GetLedPins();
    }
}
