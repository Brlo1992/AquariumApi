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
        public async Task<Response<List<ScheduledTaskViewModel>>> GetAllScheduledTasks() => await scheduledTaskService.GetAllAsync();

        [HttpPost]
        [Route("add")]
        public async Task<Response<List<ScheduledTaskViewModel>>> AddScheduledTask([FromBody]ScheduledTaskViewModel scheduledTask) {
            await scheduledTaskService.AddTaskAsync(scheduledTask);

            return await scheduledTaskService.GetAllAsync();
        }

        [HttpGet]
        [Route("remove")]
        public async Task<Response<List<ScheduledTaskViewModel>>> RemoveScheduledTask([FromQuery]TaskIdViewModel viewModel) {
            await scheduledTaskService.RemoveTaskAsync(viewModel);

            return await scheduledTaskService.GetAllAsync();
        }
    }
}
