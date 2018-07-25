using System.IO;
using Newtonsoft.Json;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Services {
    public class DeserializeService : IDeserializeService {
        public Response<T> Deserialize<T>(Response<string> response) {
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

            return result;
        }
    }
}
