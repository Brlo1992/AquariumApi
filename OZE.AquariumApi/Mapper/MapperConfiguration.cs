using Nelibur.ObjectMapper;

using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Mapper {
    public static class MapperConfiguration
    {
        public static void AddMaps() {
            TinyMapper.Bind<ScheduledTaskViewModel, ScheduledTask>();
            TinyMapper.Bind<ScheduledTask, ScheduledTaskViewModel>();
        }
    }
}
