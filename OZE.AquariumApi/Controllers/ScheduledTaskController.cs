using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Controllers {
    [Route("api/scheduledTask")]
    [ApiController]
    public class ScheduledTaskController : ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public async Task<Response<ScheduledTaskViewModel>> GetAllScheduledTasks() {
            
        }
    }
}
