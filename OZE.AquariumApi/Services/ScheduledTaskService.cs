using System.Collections.Generic;
using System.Threading.Tasks;

using OZE.AquariumApi.Database;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.Services {
    public class ScheduledTaskService : IScheduledTaskService {
        private readonly IDatabaseContext databaseContext;

        public ScheduledTaskService(IDatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public async Task<Response> AddTaskAsync(ScheduledTask scheduledTask) => await databaseContext.Add(scheduledTask);

        public async Task<Response<IEnumerable<ScheduledTask>>> GetAllAsync() => await databaseContext.GetAll<ScheduledTask>();
    }
}
