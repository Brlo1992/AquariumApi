using System;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.ViewModels {
    public class ScheduledTaskViewModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime? LastExecutionTime { get; set; }
        public string UrlAction { get; set; }

        public ScheduledTaskViewModel() {

        }

        public ScheduledTaskViewModel(ScheduledTask scheduledTask) {
            this.Name = scheduledTask.Name;
            this.Status = scheduledTask.Status;
            this.ExecutionTime = scheduledTask.ExecutionTime;
            this.LastExecutionTime = scheduledTask.LastExecutionTime;
            this.UrlAction = scheduledTask.UrlAction;
        }
    }
}
