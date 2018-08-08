using System.Collections.Generic;
using System.Threading.Tasks;

using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services {
    public interface IScheduledTaskService {
        Task<Response<List<ScheduledTaskViewModel>>> GetAllAsync();
        Task<Response> AddTaskAsync(ScheduledTaskViewModel scheduledTaskViewModel);
        Task<Response> RemoveTaskAsync(TaskIdViewModel viewModel);
    }
}
