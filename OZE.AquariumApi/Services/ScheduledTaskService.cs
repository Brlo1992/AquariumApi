using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using OZE.AquariumApi.Database;
using OZE.AquariumApi.Exceptions;
using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services {
    public class ScheduledTaskService : IScheduledTaskService {
        private readonly IDatabaseContext databaseContext;

        public ScheduledTaskService(IDatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public async Task<Response> AddTaskAsync(ScheduledTaskViewModel scheduledTask) {
            var response = new Response();
            var result = await databaseContext.Add(scheduledTask);

            response.Fetch(result);

            return response;
        }

        public async Task<Response<List<ScheduledTaskViewModel>>> GetAllAsync() {
            var response = new Response<List<ScheduledTaskViewModel>>();
            var result = await databaseContext.GetAll<ScheduledTask>();

            response.Fetch(result);

            if (response.IsValid)
                response.Content = result.Content.Select(scheduledTask => new ScheduledTaskViewModel(scheduledTask)).ToList();

            return response;
        }

        public async Task<Response> RemoveTaskAsync(TaskIdViewModel viewModel) {
            var id = ExtractObjectIdFromViewModel(viewModel);

            return await databaseContext.Remove<ScheduledTask>(id);
        }

        public async Task<Response> UpdateTaskAsync(ScheduledTaskViewModel updatedScheduledTask) {
            var updatedTask = new ScheduledTask(updatedScheduledTask);

            return await databaseContext.Update(updatedTask, updatedTask._id);
        }

        private ObjectId ExtractObjectIdFromViewModel(TaskIdViewModel viewModel) {
            if (viewModel != null && string.IsNullOrWhiteSpace(viewModel.TaskId) == false)
                return ObjectId.Parse(viewModel.TaskId);
            else
                throw new ExtractObjectIdException();
        }
    }
}
