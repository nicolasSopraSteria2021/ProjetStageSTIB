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

        public DtoWarningQueryTrackingVeh()
        {

        }

        public DtoWarningQueryTrackingVeh(string stationArrival, string stationDeparture, int id, int lineNumber, DateTime hourArrival, DateTime hourDeparture, string delayForecast)
        {
            this.stationArrival = stationArrival;
            this.stationDeparture = stationDeparture;
            this.id = id;
            this.lineNumber = lineNumber;
            this.hourArrival = hourArrival;
            this.hourDeparture = hourDeparture;
            this.delayForecast = delayForecast;
        }

        public override bool Equals(object obj)
        {
            return obj is DtoWarningQueryTrackingVeh veh &&
                   stationArrival == veh.stationArrival &&
                   stationDeparture == veh.stationDeparture &&
                   id == veh.id &&
                   lineNumber == veh.lineNumber &&
                   hourArrival == veh.hourArrival &&
                   hourDeparture == veh.hourDeparture &&
                   delayForecast == veh.delayForecast;
        }
    }
}
