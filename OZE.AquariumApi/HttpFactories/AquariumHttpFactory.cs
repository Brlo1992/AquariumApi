using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OZE.AquariumApi.HttpFactories {
    public class AquariumHttpFactory
    {
        private readonly HttpClient client;

        public AquariumHttpFactory(HttpClient client){
            this.client = client;
        }

        public async Task<string> Send(string url) {
            try {
                var response = await this.client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            return string.Empty;
        }

        public async Task TurnOn() => await Send("/turnOn");
        public async Task TurnOff() => await Send("/turnOff");
        public async Task TurnOnLedSet(int id) => await Send($"/turnOnLedSet/{id}");
        public async Task TurnOffLedSet(int id) => await Send($"/turnOffLedSet/{id}");
        public async Task<IEnumerable<int>> GetLedsIds() {
            string content = await Send("/getLedIds");

            var serializer = new JsonSerializer();

            using (var reader = new StringReader(content)) {
                using (var jsonReader = new JsonTextReader(reader)) {
                    return serializer.Deserialize<IEnumerable<int>>(jsonReader);        
                }
            }
        }
    }
}