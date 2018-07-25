using System.Collections.Generic;
using System.Threading.Tasks;

using OZE.AquariumApi.HttpFactories;
using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services {
    public class AquariumService : IAquariumService {
        private readonly AquariumHttpFactory aquariumHttpFactory;
        private readonly IDeserializeService deserializeService;

        public AquariumService(AquariumHttpFactory aquariumHttpFactory, IDeserializeService deserializeService) {
            this.aquariumHttpFactory = aquariumHttpFactory;
            this.deserializeService = deserializeService;
        }

        public async Task<Response<StatusViewModel>> TurnOn() {
            var response = await aquariumHttpFactory.Send("/turnOn");
            return deserializeService.Deserialize<StatusViewModel>(response);
        }

        public async Task<Response<StatusViewModel>> TurnOff() {
            var response = await aquariumHttpFactory.Send("/turnOff");
            return deserializeService.Deserialize<StatusViewModel>(response);
        }

        public async Task<Response<StatusViewModel>> TurnOnLedSet(int id) {
            var response = await aquariumHttpFactory.Send($"/turnOnLedSet/{id}");
            var result = deserializeService.Deserialize<StatusViewModel>(response);
            result.Content.Id = id;
            return result;
        }

        public async Task<Response<StatusViewModel>> TurnOffLedSet(int id) {
            var response = await aquariumHttpFactory.Send($"/turnOffLedSet/{id}");
            var result = deserializeService.Deserialize<StatusViewModel>(response);
            result.Content.Id = id;
            return result;
        }

        public async Task<Response<IEnumerable<StatusViewModel>>> GetLedPins() {
            var response = await aquariumHttpFactory.Send("/getLedPins");
            return deserializeService.Deserialize<IEnumerable<StatusViewModel>>(response);
        }
    }
}
