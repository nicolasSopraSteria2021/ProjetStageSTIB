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

        public DtoQueryMostDelay()
        {
        }

        public DtoQueryMostDelay(int lineNumber, string stationDeparture, int delayForecast)
        {
            if(lineNumber>=0)
            this.lineNumber = lineNumber;
            this.stationDeparture = stationDeparture;
            if(delayForecast>=0)
            this.delayForecast = delayForecast;
        }

        public override bool Equals(object obj)
        {
            return obj is DtoQueryMostDelay delay &&
                   lineNumber == delay.lineNumber &&
                   stationDeparture == delay.stationDeparture &&
                   delayForecast == delay.delayForecast;
        }
    }
}
