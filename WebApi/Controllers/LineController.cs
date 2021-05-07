using Microsoft.AspNetCore.Mvc;
using ProjetStageSTIB.Application.Service.Lines;
using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;

namespace ProjetStageSTIB.WebApi.Controllers
{
    //controller, c'est ici qu'on va etablir les appels que pourra faire le FT pour avoir accès aux éléments de la db
    [ApiController]
    [Route("api/line")]
    public class LineController : ControllerBase
    {

     
        private readonly ILineService _lineService;

        public LineController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpGet]
        [Route("lineGraph/{vehiculeType}/{value}")]
        public ActionResult<DtoLineForChart> GetLineForGraph(string vehiculeType,string value)
        {
            return Ok(_lineService.getLineForCharts(vehiculeType,value));
        }

        [HttpGet]
        [Route("numberLine/{vehiculeType}")]
        public ActionResult<int> getLineNumberFromCategory(string vehiculeType)
        {
            return Ok(_lineService.getNumberLineByCategory(vehiculeType));
        }

        [HttpGet]
        [Route("dataForecast/{lineNumber:int}/{vehiculeType}/{monthNumber}")]
        public ActionResult<DtoDelayByHourBarChart> GetDelayByHourBarChart(int lineNumber, string vehiculeType, string monthNumber)
        { 
                return Ok(_lineService.GetDelayByHourBarChart(lineNumber, vehiculeType, monthNumber));
        }

        [HttpGet]
        [Route("years")]
        public ActionResult<int> GetYearsFromDb()
        {
            return Ok(_lineService.GetYearsFromDb());
        }

        [HttpGet]
        [Route("month")]
        public ActionResult<string> GetMonthFromDb()
        {
            return Ok(_lineService.GetMonthFromDb());
        }

        [HttpGet]
        [Route("detailsWeather/{dateValue}/{vehiculeType}")]
        public ActionResult<DtoDetailsWeather> getDetailsWeather(string vehiculeType, string dateValue)
        {
            return Ok(_lineService.getDetailsFromDate(vehiculeType,dateValue));
        }

        [HttpGet]
        [Route("delayBus/{dateObser:DateTime}")]
        public ActionResult<int> GetCountDelayBus(string dateObser)
        {
            return Ok(_lineService.GetCountBusTrackingVehicule(dateObser));
        }

        [HttpGet]
        [Route("delayTram/{dateObser:DateTime}")]
        public ActionResult<int> GetCountDelayTram(string dateObser)
        {
            return Ok(_lineService.GetCountTramTrackingVehicule(dateObser));
        }


        //recupere le nombre de vehicule non en retard en fonction de la date 

        [HttpGet]
        [Route("notDelayBus/{dateObser:DateTime}")]
        public ActionResult<int> GetCountNotDelayBus(string dateObser)
        {
            return Ok(_lineService.GetCountBusNotDelay(dateObser));
        }

        [HttpGet]
        [Route("notDelayTram/{dateObser:DateTime}")]
        public ActionResult<int> GetCountNotDelayTram(string dateObser)
        {
            return Ok(_lineService.GetCountTramNotDelay(dateObser));
        }

        [HttpGet]
        [Route("InfoTable/{vehiculeType}/{value}")]
        public ActionResult<DtoSpecificTableDateObservation> GetInfoForTable(string vehiculeType, string value)
        {
            return Ok(_lineService.GetInfoForTable(vehiculeType, value));
        }

        [HttpGet]
        [Route("InfoMostDelay/{vehiculeType}/{value}")]
        public ActionResult<DtoQueryMostDelay> GetInfoForMostDelay(string vehiculeType, string value)
        {
            return Ok(_lineService.GetInfoForMostDelay(vehiculeType, value));
        }

        [HttpGet]
        [Route("specificMonth/{vehiculeType}/{value:int}/{monthValue}")]
        public ActionResult<DtoQueryMostDelay> GetDayByMonth(string vehiculeType, int value, string monthvalue)
        {
            return Ok(_lineService.GetDayByMonth(vehiculeType, value, monthvalue));
        }

    }
}
