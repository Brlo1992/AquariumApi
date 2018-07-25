using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using OZE.AquariumApi.Models;
using OZE.AquariumApi.Services;

namespace OZE.AquariumApi.HttpFactories {
    public class AquariumHttpFactory {
        private readonly HttpClient client;
        private readonly IAquariumService communicationService;
        private readonly IDeserializeService deserializeService;

        public AquariumHttpFactory(HttpClient client, IAquariumService communicationService, IDeserializeService deserializeService) {
            this.client = client;
            this.communicationService = communicationService;
            this.deserializeService = deserializeService;
        }

        public async Task<Response<string>> Send(string url) {
            var response = new Response<string>();

            try {
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();

                response.Content = await result.Content.ReadAsStringAsync();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                response.AddError(ex.Message);
            }

            return response;
        }
    }
}