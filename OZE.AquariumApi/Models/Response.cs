using System;
using System.Collections.Generic;
using System.Linq;

namespace OZE.AquariumApi.Models {
    public class Response {
        public void AddError(string error) => Errors.Add(error);
        public ICollection<string> Errors { get; } = new List<string>();
        public bool IsValid => Errors.Any() == false;
        public void Fetch(Response result) {
            if (result.IsValid == false)
                foreach (var error in result.Errors)
                    AddError(error);
        }
    }

    public class Response<T> : Response {
        public T Content { get; set; }
    }
}
