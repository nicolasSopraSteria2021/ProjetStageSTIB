using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.TrackingVehicules.Dto
{
    public class DtoWarningQueryTrackingVeh
    {
     
        //renvoie les lignes ayant un retard de plus de 10 minutes 

        public string stationArrival { get; set; }
        public string stationDeparture { get; set; }

        public int id { get; set; }

        public int lineNumber { get; set; }

        public DateTime hourArrival { get; set; }

        public DateTime hourDeparture { get; set; }

        public string delayForecast { get; set; }

    }
}
