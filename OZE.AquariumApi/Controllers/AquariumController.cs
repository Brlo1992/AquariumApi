using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OZE.AquariumApi.Models;
using OZE.AquariumApi.Services;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Controllers {
    [Route("api/aquarium")]
    [ApiController]
    public class AquariumController : ControllerBase {
        private readonly IAquariumService aquariumService;

        public AquariumController(IAquariumService aquariumService) {
            this.aquariumService = aquariumService;
        }

        [HttpGet]
        [Route("turnOn")]
        public async Task<Response<StatusViewModel>> TurnOn() => await aquariumService.TurnOn();

        [HttpGet]
        [Route("turnOff")]
        public async Task<Response<StatusViewModel>> TurnOff() => await aquariumService.TurnOff();

        [HttpGet]
        [Route("turnOnLedSet/{id}")]
        public async Task<Response<StatusViewModel>> TurnOnLedSet(int id) => await aquariumService.TurnOnLedSet(id);

        [HttpGet]
        [Route("turnOffLedSet/{id}")]
        public async Task<Response<StatusViewModel>> TurnOffLedSet(int id) => await aquariumService.TurnOffLedSet(id);

        [HttpGet]
        [Route("getLedPins")]
        public async Task<Response<IEnumerable<int>>> GetLedIds() => await aquariumService.GetLedPins();

    }
}
