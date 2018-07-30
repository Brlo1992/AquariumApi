using OZE.AquariumApi.Database;
using OZE.AquariumApi.Models;

namespace OZE.AquariumApi.DataSeed {
    public class MongoSeed
    {
        private readonly IDatabaseContext databaseContext;

        public MongoSeed(IDatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public void SeedData() {
            var turnOnTask = new ScheduledTask {

            }
        }
    }
}
