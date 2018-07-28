using System;

namespace OZE.AquariumApi.ViewModels {
    public class ScheduledTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime? LastExecutionTime { get; set; }
    }
}
