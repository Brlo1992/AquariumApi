using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace OZE.AquariumApi.HttpFactories
{
    public class AquariumHttpFactory
    {
        private readonly HttpClient client;

        public AquariumHttpFactory(HttpClient client){
            this.client = client;
        }

        public async Task TurnOn(){
            try
            {
                var response = await this.client.GetAsync("/turnOn");
                response.EnsureSuccessStatusCode();
            }
            catch (System.Exception ex)
            {
            }
        }

        public async Task TurnOff(){
            try
            {
                var response = await this.client.GetAsync("/turnOff");
                response.EnsureSuccessStatusCode();
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}