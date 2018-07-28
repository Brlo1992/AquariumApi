using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services.FakeServices {
    public class FakeScheduledTaskService : IScheduledTaskService {
        public async Task<Response<IEnumerable<ScheduledTaskViewModel>>> GetAllAsync() {
            return new Response<IEnumerable<ScheduledTaskViewModel>> {
                Content = new List<ScheduledTaskViewModel> {
                    new ScheduledTaskViewModel {
                        Id = 1,
                        Name = "Turn on all leds",
                        ExecutionTime = DateTime.Now.AddHours(4),
                        LastExecutionTime = DateTime.Now.AddHours(-20),
                        Status = "on"
                    },
                    new ScheduledTaskViewModel {
                        Id = 1,
                        Name = "Run led set no 4",
                        ExecutionTime = DateTime.Now.AddHours(4),
                        LastExecutionTime = DateTime.Now.AddHours(-20),
                        Status = "off"
                    },
                    new ScheduledTaskViewModel {
                        Id = 1,
                        Name = "Turn off all leds",
                        ExecutionTime = DateTime.Now.AddHours(16),
                        LastExecutionTime = DateTime.Now.AddHours(-8),
                        Status = "on"
                    }
                }
            };
        }
    }
}
