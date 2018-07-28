using System.Collections.Generic;
using System.Threading.Tasks;

using OZE.AquariumApi.Models;
using OZE.AquariumApi.ViewModels;

namespace OZE.AquariumApi.Services {
    public class FakeAquariumService : IAquariumService {


        public async Task<Response<StatusViewModel>> TurnOn() {
            return new Response<StatusViewModel> {
                Content = new StatusViewModel {
                    Id = 0,
                    Status = "on"
                }
            };
        }

        public async Task<Response<StatusViewModel>> TurnOff() {
            return new Response<StatusViewModel> {
                Content = new StatusViewModel {
                    Id = 0,
                    Status = "off"
                }
            };
        }

        public async Task<Response<StatusViewModel>> TurnOnLedSet(int id) {
            return new Response<StatusViewModel> {
                Content = new StatusViewModel {
                    Id = id,
                    Status = "on"
                }
            };
        }

        public async Task<Response<StatusViewModel>> TurnOffLedSet(int id) {
            return new Response<StatusViewModel> {
                Content = new StatusViewModel {
                    Id = id,
                    Status = "off"
                }
            };
        }

        public async Task<Response<IEnumerable<StatusViewModel>>> GetLedPins() {
            return new Response<IEnumerable<StatusViewModel>> {
                Content = new List<StatusViewModel> {
                    new StatusViewModel {
                        Id = 4,
                        Status = "on"
                    },
                    new StatusViewModel {
                        Id = 5,
                        Status = "off"
                    },
                    new StatusViewModel {
                        Id = 6,
                        Status = "d"
                    }
                }
            };
        }
    }
}
