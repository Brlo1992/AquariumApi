using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.HttpFactories {
    public class AquariumHttpFactory
    {
        private readonly HttpClient client;

        public AquariumHttpFactory(HttpClient client){
            this.client = client;
        }

        public async Task<Response> Send(string url) {
            var response = new Response();
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

        public async Task TurnOn() => await Send("/turnOn");
        public async Task TurnOff() => await Send("/turnOff");
        public async Task TurnOnLedSet(int id) => await Send($"/turnOnLedSet/{id}");
        public async Task TurnOffLedSet(int id) => await Send($"/turnOffLedSet/{id}");
        public async Task<IEnumerable<int>> GetLedPins() {
            string content = await Send("/getLedPins");

            var serializer = new JsonSerializer();

            using (var reader = new StringReader(content)) {
                using (var jsonReader = new JsonTextReader(reader)) {
                    return serializer.Deserialize<IEnumerable<int>>(jsonReader);        
                }
            }
        }
    }
}