using System;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Models {
    public class ScheduledTask {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime? LastExecutionTime { get; set; }
        public string UrlAction { get; internal set; }

        public ScheduledTask() {

        }

        public ScheduledTask(ScheduledTaskViewModel  scheduledTaskViewModel) {
            this.Name = scheduledTaskViewModel.Name;
            this.Status = scheduledTaskViewModel.Status;
            this.ExecutionTime = scheduledTaskViewModel.ExecutionTime;
            this.LastExecutionTime = scheduledTaskViewModel.LastExecutionTime;
        }
    }
}
