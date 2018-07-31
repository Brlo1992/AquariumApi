using System.Collections.Generic;
using System.Threading.Tasks;

using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services {
    public interface IScheduledTaskService {
        Task<Response<IEnumerable<ScheduledTask>>> GetAllAsync();
        Task<Response> AddTask(ScheduledTask scheduledTaskViewModel);
    }
}
