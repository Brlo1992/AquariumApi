using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Services {
    public class CommunicationService : ICommunicationService {
        private readonly HttpClient client;

        public CommunicationService(HttpClient client) {
            this.client = client;
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
