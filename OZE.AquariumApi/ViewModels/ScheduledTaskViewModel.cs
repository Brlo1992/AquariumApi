using System;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.ViewModels {
    public class ScheduledTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime? LastExecutionTime { get; set; }

        public ScheduledTaskViewModel() {

        }

        public ScheduledTaskViewModel(ScheduledTask scheduledTask) {
            this.Id = scheduledTask.Id;
            this.Name = scheduledTask.Name;
            this.Status = scheduledTask.Status;
            this.ExecutionTime = scheduledTask.ExecutionTime;
            this.LastExecutionTime = scheduledTask.LastExecutionTime;
        }
    }
}
