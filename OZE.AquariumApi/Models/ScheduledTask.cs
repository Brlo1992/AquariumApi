using System;
using MongoDB.Bson;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Models {
    public class ScheduledTask {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime? LastExecutionTime { get; set; }
        public string Action { get; internal set; }
        public string Uri { get; set; }

        public ScheduledTask() {

        }

        public ScheduledTask(ScheduledTaskViewModel scheduledTaskViewModel, bool parseId = true) {
            if (parseId)
                _id = ObjectId.Parse(scheduledTaskViewModel.Id);

            Name = scheduledTaskViewModel.Name;
            Status = scheduledTaskViewModel.Status;
            ExecutionTime = scheduledTaskViewModel.ExecutionTime;
            LastExecutionTime = scheduledTaskViewModel.LastExecutionTime;
            Action = scheduledTaskViewModel.Action;
        }
    }
}
