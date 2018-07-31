using System.Collections.Generic;
using System.Threading.Tasks;

using OZE.AquariumApi.Database;
using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services {
    public class ScheduledTaskService : IScheduledTaskService {
        private readonly IDatabaseContext databaseContext;

        public ScheduledTaskService(IDatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public async Task<Response> AddTask(ScheduledTask scheduledTask) {
            await databaseContext.Add(scheduledTask);
        }

        public async Task<Response<IEnumerable<ScheduledTask>>> GetAllAsync() => await databaseContext.GetAll<ScheduledTask>();
    }
}
