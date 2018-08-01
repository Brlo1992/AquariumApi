using System;
using System.Linq;
using System.Threading.Tasks;
using OZE.AquariumApi.Database;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.DataSeed {
    public class MongoSeed {
        private readonly IDatabaseContext databaseContext;

        public MongoSeed(IDatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public void SeedData() {
            if (IsEmpty().Result) {

                var turnOnTask = new ScheduledTask {
                    Id = 1,
                    Name = "TurnOn",
                    Status = "on",
                    ExecutionTime = DateTime.Now.AddHours(-14),
                    LastExecutionTime = DateTime.Now.AddHours(-14)
                };
                
                var turnOffTask = new ScheduledTask {
                    Id = 2,
                    Name = "TurnOff",
                    Status = "off",
                    ExecutionTime = DateTime.Now.AddHours(-1),
                    LastExecutionTime = DateTime.Now.AddHours(-1)
                };

                databaseContext.Add(turnOnTask);
                databaseContext.Add(turnOffTask);
            }
        }

        private async Task<bool> IsEmpty() {
            var result = await databaseContext.GetAll<ScheduledTask>();
            return result.Content.Any() == false;
        }
    }
}
