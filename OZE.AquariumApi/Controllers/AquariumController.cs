using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZE.AquariumApi.HttpFactories;

namespace OZE.AquariumApi.Controllers
{
    [Route("api/aquarium")]
    [ApiController]
    public class AquariumController : ControllerBase
    {
        private readonly AquariumHttpFactory aquariumHttpFactory;

        public AquariumController(AquariumHttpFactory aquariumHttpFactory)
        {
            this.aquariumHttpFactory = aquariumHttpFactory;
        }

        [HttpGet]
        [Route("turnOn")]
        public async Task TurnOn() => await aquariumHttpFactory.TurnOn();

        [HttpGet]
        [Route("turnOff")]
        public async Task TurnOff() => await aquariumHttpFactory.TurnOff();
    }
}
