using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OZE.AquariumApi.Models;
using OZE.AquariumApi.Services;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Controllers {
    [Route("api/scheduledTask")]
    [ApiController]
    public class ScheduledTaskController : ControllerBase
    {
        private readonly IScheduledTaskService scheduledTaskService;

        public ScheduledTaskController(IScheduledTaskService scheduledTaskService) {
            this.scheduledTaskService = scheduledTaskService;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<Response<IEnumerable<ScheduledTaskViewModel>>> GetAllScheduledTasks() => await scheduledTaskService.GetAllAsync();
    }
}
