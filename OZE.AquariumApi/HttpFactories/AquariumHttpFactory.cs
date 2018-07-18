using System;
using System.Collections.Generic;
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

        public async Task Send(string url) {
            try {
                var response = await this.client.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (System.Exception ex) {

            }
        }

        public async Task<string> Send(string url) {
            try {
                var response = await this.client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (System.Exception ex) {

            }

            return string.Empty;
        }


        public async Task TurnOn() => await Send("/turnOn");
        public async Task TurnOff() => await Send("/turnOff");
        public async Task TurnOnLedSet(int id) => await Send($"/turnOnLedSet/{id}");
        public async Task TurnOffLedSet(int id) => await Send($"/turnOffLedSet/{id}");
        public async Task<IEnumerable<int>> GetLedsIds() {
            string content = await Send("/getLedIds");
        }
    }
}