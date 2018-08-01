using System;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Models {
    public class ScheduledTask {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime? LastExecutionTime { get; set; }
        public string UrlAction { get; internal set; }

        public ScheduledTask() {

        }

        public ScheduledTask(ScheduledTaskViewModel  scheduledTaskViewModel) {
            this.Id = scheduledTaskViewModel.Id;
            this.Name = scheduledTaskViewModel.Name;
            this.Status = scheduledTaskViewModel.Status;
            this.ExecutionTime = scheduledTaskViewModel.ExecutionTime;
            this.LastExecutionTime = scheduledTaskViewModel.LastExecutionTime;
        }
    }
}
