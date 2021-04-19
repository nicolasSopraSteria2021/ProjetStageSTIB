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
      
       
        [HttpGet]
        [Route("InfoTable/{vehiculeType}/{value}")]
        public ActionResult<DtoSpecificTableDateObservation> GetInfoForTable(string vehiculeType,string value)
        {
            return Ok(_trackingVehiculeService.GetInfoForTable(vehiculeType,value));
        }

        [HttpGet]
        [Route("InfoMostDelay/{vehiculeType}/{value}")]
        public ActionResult<DtoQueryMostDelay> GetInfoForMostDelay(string vehiculeType,string value)
        {
            return Ok(_trackingVehiculeService.GetInfoForMostDelay(vehiculeType,value));
        }

        [HttpGet]
        [Route("specificMonth/{vehiculeType}/{value}/{monthValue}")]
        public ActionResult<DtoQueryMostDelay> GetDayByMonth(string vehiculeType, string value,string monthvalue)
        {
            return Ok(_trackingVehiculeService.GetDayByMonth(vehiculeType,value,monthvalue));
        }


    }
}
