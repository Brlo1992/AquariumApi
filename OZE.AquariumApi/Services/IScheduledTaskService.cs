using System.Collections.Generic;
using System.Threading.Tasks;

using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services {
    public interface IScheduledTaskService {
        Task<IEnumerable<ScheduledTaskViewModel>> GetAllAsync();
    }
}
