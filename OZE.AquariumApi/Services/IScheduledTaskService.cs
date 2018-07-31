using System.Collections.Generic;
using System.Threading.Tasks;

using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Services {
    public interface IScheduledTaskService {
        Task<Response<IEnumerable<ScheduledTask>>> GetAllAsync();
        Task<Response> AddTaskAsync(ScheduledTask scheduledTaskViewModel);
    }
}
