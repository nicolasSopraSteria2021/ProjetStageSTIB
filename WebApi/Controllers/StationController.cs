using Microsoft.AspNetCore.Mvc;
using ProjetStageSTIB.Application.Service.Stations;
using ProjetStageSTIB.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.WebApi.Controllers
{
    [ApiController]
    [Route("api/Station")]
    public class StationController: ControllerBase
    {
        private readonly IStationService _StationService;

        public StationController(IStationService station)
        {
            _StationService = station;
        }

        [HttpGet]
        public ActionResult<IStation> GetStation()
        {
            return Ok(_StationService.GetStation());
        }

    }
}
