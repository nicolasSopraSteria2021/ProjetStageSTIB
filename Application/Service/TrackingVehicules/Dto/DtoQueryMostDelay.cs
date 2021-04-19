using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.TrackingVehicules.Dto
{
    //renvoie l'objet ligne le plus en retard de la base de donnée 
    public class DtoQueryMostDelay
    {

 
        public int lineNumber { get; set; }
        public string stationDeparture { get; set; }
        public int delayForecast { get; set; }
    }
}
