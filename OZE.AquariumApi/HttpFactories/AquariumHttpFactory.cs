using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OZE.AquariumApi.Models;
using OZE.AquariumApi.Services;

namespace OZE.AquariumApi.HttpFactories {
    public class AquariumHttpFactory {
        private readonly ICommunicationService communicationService;
        private readonly IDeserializeService deserializeService;

        public AquariumHttpFactory(ICommunicationService communicationService, IDeserializeService deserializeService) {
            this.communicationService = communicationService;
            this.deserializeService = deserializeService;
        }

        public async Task<Response> TurnOn() {
            var response = await communicationService.Send("/turnOn");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }

        public async Task<Response> TurnOff() {
            var response = await communicationService.Send("/turnOff");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }

        public async Task<Response> TurnOnLedSet(int id) {
            var response = await communicationService.Send($"/turnOnLedSet/{id}");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }

        public async Task<Response> TurnOffLedSet(int id) {
            var response = await communicationService.Send($"/turnOffLedSet/{id}");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }

        public async Task<Response<IEnumerable<int>>> GetLedPins() {
            var response = await communicationService.Send("/getLedPins");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }
    }
}