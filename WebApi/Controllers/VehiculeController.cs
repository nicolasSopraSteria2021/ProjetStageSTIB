using Microsoft.AspNetCore.Mvc;
using ProjetStageSTIB.Application.Service.Lines;
using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Application.Service.Vehicules;
using ProjetStageSTIB.Domain.Line;
using ProjetStageSTIB.Domain.Vehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.WebApi.Controllers
{
    //controller, c'est ici qu'on va etablir les appels que pourra faire le FT pour avoir accès aux éléments de la db
    [ApiController]
    [Route("api/Vehicule")]
    public class VehiculeController : ControllerBase
    {

        private readonly IVehiculeService _vehiculeService;
        private readonly ILineService _lineService;

        public VehiculeController(IVehiculeService vehiculeService,ILineService lineService)
        {
            _vehiculeService = vehiculeService;
            _lineService = lineService;
        }


        [HttpGet]
        public ActionResult<IVehicule> GetVehicule()
        {
            return Ok(_vehiculeService.GetVehicule());
        }

        [HttpGet]
        [Route("lineGraph/{vehiculeType:int}")]
        public ActionResult<ILine> GetLineForGraph(int vehiculeType)
        {
            return Ok(_lineService.getLineForCharts(vehiculeType));
        }

        [HttpGet]
        [Route("numberLine/{vehiculeType:int}")]
        public ActionResult<ILine> getLineNumberFromCategory(int vehiculeType)
        {
            return Ok(_lineService.getNumberLineByCategory(vehiculeType));
        }

        [HttpGet]
        [Route("dataForecast/{lineNumber:int}")]
        public ActionResult<DtoLineForLinearChart> GetForecastFromLine(int lineNumber)
        {
            return Ok(_lineService.GetForecastFromLine(lineNumber));
        }

    }
}
