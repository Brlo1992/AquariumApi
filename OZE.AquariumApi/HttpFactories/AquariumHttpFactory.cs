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
    public class AquariumHttpFactory
    {
        private readonly HttpClient client;
        private readonly IDeserializeService deserializeService;

        public AquariumHttpFactory(HttpClient client, IDeserializeService deserializeService ){
            this.client = client;
            this.deserializeService = deserializeService;
        }

        private async Task<Response<string>> Send(string url) {
            var response = new Response<string>();

            try {
                var result = await this.client.GetAsync(url);
                result.EnsureSuccessStatusCode();

                response.Content = await result.Content.ReadAsStringAsync();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                response.AddError(ex.Message);
            }

            return response;
        }

        

        public async Task<Response> TurnOn() {
            var response = await Send("/turnOn");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }

        public async Task<Response> TurnOff() {
            var response = await Send("/turnOff");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }

        public async Task<Response> TurnOnLedSet(int id) {
            var response = await Send($"/turnOnLedSet/{id}");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }

        public async Task<Response> TurnOffLedSet(int id) {
            var response = await Send($"/turnOffLedSet/{id}");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }

        public async Task<Response<IEnumerable<int>>> GetLedPins() {
            var response = await Send("/getLedPins");
            return deserializeService.Deserialize<IEnumerable<int>>(response);
        }
    }
}