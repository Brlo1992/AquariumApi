using System.Collections.Generic;
using System.Linq;

namespace OZE.AquariumApi.Models {
    public class Response {
        public void AddError(string error) => Errors.Add(error);
        public ICollection<string> Errors { get; }
        public bool IsValid => Errors.Any() == false;
    }
    public class Response<T> :Response {
        public T Content { get; set; }
    }
}
