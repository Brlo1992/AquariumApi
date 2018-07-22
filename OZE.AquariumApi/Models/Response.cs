using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZE.AquariumApi.Models
{
    public class Response {
        public void AddError(string error) => Errors.Add(error);
        public ICollection<string> Errors { get; }
        public bool IsValid => Errors.Any() == false;
    }
}
