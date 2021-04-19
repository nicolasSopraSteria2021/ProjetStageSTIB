using Microsoft.AspNetCore.Mvc;
using ProjetStageSTIB.Application.Service.Lines;
using ProjetStageSTIB.Application.Service.Lines.Dto;
namespace ProjetStageSTIB.WebApi.Controllers
{
    //controller, c'est ici qu'on va etablir les appels que pourra faire le FT pour avoir accès aux éléments de la db
    [ApiController]
    [Route("api/Vehicule")]
    public class VehiculeController : ControllerBase
    {

     
        private readonly ILineService _lineService;

        public VehiculeController(ILineService lineService)
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
        public ActionResult<DtoDelayByHourBarChart> GetForecastFromLine(int lineNumber, string vehiculeType, string monthNumber)
        {
            return Ok(_lineService.GetForecastFromLine(lineNumber,vehiculeType,monthNumber));
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

    }
}
