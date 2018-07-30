using System;
using System.Linq;
using OZE.AquariumApi.Database;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.DataSeed {
    public class MongoSeed {
        private readonly IDatabaseContext databaseContext;

        public MongoSeed(IDatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public void SeedData() {
            if (IsEmpty()) {

                var turnOnTask = new ScheduledTask {
                    Id = 1,
                    Name = "TrunOn",
                    Status = "on",
                    ExecutionTime = DateTime.Now.AddHours(-14),
                    LastExecutionTime = DateTime.Now.AddHours(-14)
                };
                
                var turnOffTask = new ScheduledTask {
                    Id = 1,
                    Name = "TrunOff",
                    Status = "off",
                    ExecutionTime = DateTime.Now.AddHours(-1),
                    LastExecutionTime = DateTime.Now.AddHours(-1)
                };

                this.databaseContext.Add(turnOnTask);
                this.databaseContext.Add(turnOffTask);

                this.databaseContext.SaveChanges();
            }
        }

        private bool IsEmpty() => databaseContext.GetAll<ScheduledTask>().Content.Any() == false;
    }
}
