﻿using System;
using MongoDB.Bson;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.ViewModels {
    public class ScheduledTaskViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime? LastExecutionTime { get; set; }
        public string Action { get; set; }
        public string Uri { get; set; }

        public ScheduledTaskViewModel() {

        }

        public ScheduledTaskViewModel(ScheduledTask scheduledTask) {
            this.Id = scheduledTask._id.ToString();
            this.Name = scheduledTask.Name;
            this.Status = scheduledTask.Status;
            this.ExecutionTime = scheduledTask.ExecutionTime;
            this.LastExecutionTime = scheduledTask.LastExecutionTime;
            this.Action = scheduledTask.Action;
        }
    }
}
