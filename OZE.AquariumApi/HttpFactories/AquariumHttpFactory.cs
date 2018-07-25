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

        private async Task<Response> Deserialize(Response<string> response) {
            var result = new Response<T>();

            if (response.IsValid) {
                using (var reader = new StringReader(response.Content)) {
                    using (var jsonReader = new JsonTextReader(reader)) {
                        var serializer = new JsonSerializer();
                        result.Content = serializer.Deserialize<T>(jsonReader);
                    }
                }
            }
            else {
                foreach (var error in response.Errors) {
                    response.AddError(error);
                }
            }

            return response;
        }

        public async Task<Response> TurnOn() => await Send("/turnOn");
        public async Task<Response> TurnOff() => await Send("/turnOff");
        public async Task<Response> TurnOnLedSet(int id) => await Send($"/turnOnLedSet/{id}");
        public async Task<Response> TurnOffLedSet(int id) => await Send($"/turnOffLedSet/{id}");
        public async Task<Response<IEnumerable<int>>> GetLedPins() {
            var result = await Send("/getLedPins");
           
        }
    }
}