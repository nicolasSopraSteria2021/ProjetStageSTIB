using Microsoft.AspNetCore.Mvc;
using ProjetStageSTIB.Application.Service.TrackingVehicules;
using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.WebApi.Controllers
{    //controller, c'est ici qu'on va etablir les appels que pourra faire le FT pour avoir accès aux éléments de la db
    [ApiController]
    [Route("api/trackingVehicule")]
    public class TrackingVehiculeController : ControllerBase
    {
        private readonly ITrackingVehiculeService _trackingVehiculeService;

        public TrackingVehiculeController(ITrackingVehiculeService trackingVehiculeService)
        {
            _trackingVehiculeService = trackingVehiculeService;
        }

      
        [HttpGet]
        [Route("delayBus/{dateObser:DateTime}")]
        public ActionResult<int> GetCountDelayBus(String dateObser)
        {
            return Ok(_trackingVehiculeService.GetCountBusTrackingVehicule(dateObser));
        }
        
        [HttpGet]
        [Route("delayTram/{dateObser:DateTime}")]
        public ActionResult<int> GetCountDelayTram(String dateObser)
        {
            return Ok(_trackingVehiculeService.GetCountTramTrackingVehicule(dateObser));
        }
       
       [HttpGet]
        [Route("delayMetro/{dateObser:DateTime}")]
        public ActionResult<int> GetCountDelayMetro(String dateObser)
        {
            return Ok(_trackingVehiculeService.GetCountMetroTrackingVehicule(dateObser));
        }



        //recupere le nombre de vehicule non en retard en fonction de la date 

        [HttpGet]
        [Route("notDelayBus/{dateObser:DateTime}")]
        public ActionResult<int> GetCountNotDelayBus(String dateObser)
        {
            return Ok(_trackingVehiculeService.GetCountBusNotDelay(dateObser));
        }

        [HttpGet]
        [Route("notDelayTram/{dateObser:DateTime}")]
        public ActionResult<int> GetCountNotDelayTram(String dateObser)
        {
            return Ok(_trackingVehiculeService.GetCountTramNotDelay(dateObser));
        }

        [HttpGet]
        [Route("notDelayMetro/{dateObser:DateTime}")]
        public ActionResult<int> GetCountNotDelayMetro(String dateObser)
        {
            return Ok(_trackingVehiculeService.GetCountMetroNotDelay(dateObser));
        }

        //
        [HttpGet]
        [Route("TimeDelayBus/{dateObser:DateTime}")]
        public ActionResult<int> GetTimeDelayBus(string dateObser)
        {
            return Ok(_trackingVehiculeService.GetTimeDelayBusTrackingVehicule(dateObser));
        }
        [HttpGet]
        [Route("TimeDelayMetro/{dateObser:DateTime}")]
        public ActionResult<int> GetTimeDelayTram(string dateObser)
        {
            return Ok(_trackingVehiculeService.GetTimeDelayMetroTrackingVehicule(dateObser));
        }
        [HttpGet]
        [Route("TimeDelayTram/{dateObser:DateTime}")]
        public ActionResult<int> GetTimeDelayMetro(string dateObser)
        {
            return Ok(_trackingVehiculeService.GetTimeDelayTramTrackingVehicule(dateObser));
        }

        [HttpGet]
        [Route("InfoWaring")]
        public ActionResult<DtoWarningQueryTrackingVeh> GetInfoForWarning()
        {
            return Ok(_trackingVehiculeService.GetInfoForWarning());
        }
        ///{timeChange:string}
        [HttpGet]
        [Route("InfoTable/{vehiculeType:int}")]
        public ActionResult<DtoSpecificTableDateObservation> GetInfoForTable(int vehiculeType/*,string timeChange*/)
        {
            return Ok(_trackingVehiculeService.GetInfoForTable(vehiculeType/*,timeChange*/));
        }

        [HttpGet]
        [Route("InfoMostDelay/{vehiculeType:int}")]
        public ActionResult<DtoQueryMostDelay> GetInfoForMostDelay(int vehiculeType)
        {
            return Ok(_trackingVehiculeService.GetInfoForMostDelay(vehiculeType));
        }

    }
}
