using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OZE.AquariumApi.Models;
using OZE.AquariumApi.Services;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.HttpFactories {
    public class AquariumHttpFactory {
        private readonly HttpClient client;
        private readonly ICommunicationService communicationService;
        private readonly IDeserializeService deserializeService;

        public AquariumHttpFactory(HttpClient client, ICommunicationService communicationService, IDeserializeService deserializeService) {
            this.client = client;
            this.communicationService = communicationService;
            this.deserializeService = deserializeService;
        }

        private async Task<Response<T>> HandleSend<T>(string url) {
            var response = await communicationService.Send(url);
            return deserializeService.Deserialize<T>(response);
        }

        public async Task<Response<StatusViewModel>>  TurnOn() {
            var response = await communicationService.Send("/turnOn");
            return deserializeService.Deserialize<StatusViewModel>(response);
        }

        public async Task<Response<StatusViewModel>>  TurnOff() {
            var response = await communicationService.Send("/turnOff");
            return deserializeService.Deserialize<StatusViewModel>(response);
        }

        public async Task<Response<StatusViewModel>>  TurnOnLedSet(int id) {
            var response = await communicationService.Send($"/turnOnLedSet/{id}");
            return deserializeService.Deserialize<StatusViewModel>(response);
        }

        public async Task<Response<StatusViewModel>>  TurnOffLedSet(int id) {
            var response = await communicationService.Send($"/turnOffLedSet/{id}");
            return deserializeService.Deserialize<StatusViewModel>(response);
        }

        public async Task<Response<IEnumerable<int>>> GetLedPins() {
            var response = await communicationService.Send("/getLedPins");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }
    }
}