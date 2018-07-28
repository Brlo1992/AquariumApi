using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services.FakeServices
{
    public class FakeScheduledTaskService : IScheduledTaskService {
        public async Task<Response<IEnumerable<ScheduledTaskViewModel>>> GetAllAsync() {
            return new Response<IEnumerable<ScheduledTaskViewModel>> {
                Content = new List<ScheduledTaskViewModel> {
                    
                }
            };
        }
    }
}
