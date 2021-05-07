using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.TrackingVehicules.Dto
{
    //renvoie la date et le nombre de retard
    public class DtoSpecificTableDateObservation
    {
        public  int count { get; set; }
        public string dateObservation { get; set; }
        public double snow { get; set; }

        public double relativeHumidity { get; set; }

        public double windSpeed { get; set; }

        public double precip { get; set; }

        public double visibility { get; set; }

        public DtoSpecificTableDateObservation(int count, string dateObservation, double snow, double relativeHumidity, double windSpeed, double precip, double visibility)
        {
            if(count>=0)
            this.count = count;
              this.dateObservation = dateObservation;
            if (snow >= 0)
                this.snow = snow;
            if (relativeHumidity >= 0)
                this.relativeHumidity = relativeHumidity;
            if (windSpeed >= 0)
                this.windSpeed = windSpeed;
            if (precip >= 0)
                this.precip = precip;
            if (visibility >= 0)
                this.visibility = visibility;
        }

        public DtoSpecificTableDateObservation()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is DtoSpecificTableDateObservation observation &&
                   count == observation.count &&
                   dateObservation == observation.dateObservation &&
                   snow == observation.snow &&
                   relativeHumidity == observation.relativeHumidity &&
                   windSpeed == observation.windSpeed &&
                   precip == observation.precip &&
                   visibility == observation.visibility;
        }
    }

}
