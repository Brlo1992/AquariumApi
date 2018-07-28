using System.Collections.Generic;
using System.Threading.Tasks;
using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services {
    public class ScheduledTaskService : IScheduledTaskService {
        public Task<Response<IEnumerable<ScheduledTaskViewModel>>> GetAllAsync() {
            throw new System.NotImplementedException();
        }
    }
}
