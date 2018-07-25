﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OZE.AquariumApi.HttpFactories;

namespace OZE.AquariumApi.Controllers {
    [Route("api/aquarium")]
    [ApiController]
    public class AquariumController : ControllerBase {
        private readonly AquariumHttpFactory aquariumHttpFactory;

        public AquariumController(AquariumHttpFactory aquariumHttpFactory) {
            this.aquariumHttpFactory = aquariumHttpFactory;
        }

        [HttpGet]
        [Route("turnOn")]
        public async Task TurnOn() => await aquariumHttpFactory.TurnOn();

        [HttpGet]
        [Route("turnOff")]
        public async Task TurnOff() => await aquariumHttpFactory.TurnOff();

        [HttpGet]
        [Route("turnOnLedSet/{id}")]
        public async Task TurnOnLedSet(int id) => await aquariumHttpFactory.TurnOnLedSet(id);

        [HttpGet]
        [Route("turnOffLedSet/{id}")]
        public async Task TurnOffLedSet(int id) => await aquariumHttpFactory.TurnOffLedSet(id);

        //[HttpGet]
        //[Route("getLedPins")]
        //public async Task<IEnumerable<int>> GetLedIds() => await aquariumHttpFactory.GetLedPins();

        [HttpGet]
        [Route("getLedPins")]
        public IEnumerable<int> Test() =>
             new List<int>() { 12, 13, 14 };

    }
}
