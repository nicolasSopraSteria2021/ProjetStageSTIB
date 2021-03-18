using Microsoft.AspNetCore.Mvc;
using ProjetStageSTIB.Application.Service.Stations;
using ProjetStageSTIB.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.WebApi.Controllers
{
    //controller, c'est ici qu'on va etablir les appels que pourra faire le FT pour avoir accès aux éléments de la db
    [ApiController]
    [Route("api/Station")]
    public class StationController: ControllerBase
    {
        private readonly IStationService _StationService;
        //creation d'une instance de stationservice
        public StationController(IStationService station)
        {
            _StationService = station;
        }
        //renvoie toutes les stations de la db 
        [HttpGet]
        public ActionResult<IStation> GetStation()
        {
            return Ok(_StationService.GetStation());
        }

    }
}
