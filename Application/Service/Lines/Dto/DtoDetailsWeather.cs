using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Lines.Dto
{
    public class DtoDetailsWeather
    {
        public double delays { get; set; }
        public double snow { get; set; }
        
        public double relativeHumidity { get; set; }
        
        public double windSpeed { get; set; }

        public double precip { get; set; }

        public double visibility { get; set; }

        public DtoDetailsWeather()
        {
        }

        public DtoDetailsWeather(double delays, double snow, double relativeHumidity, double windSpeed, double precip, double visibility)
        {
            if(delays>=0)
                this.delays = delays;
            if (snow >= 0)
                this.snow = snow;
            if (relativeHumidity >= 0)
                this.relativeHumidity = relativeHumidity;
            if (windSpeed >= 0)
                this.windSpeed = windSpeed;
            if (precip >= 0)
                this.precip = precip;
            this.visibility = visibility;
        }

        public override bool Equals(object obj)
        {
            return obj is DtoDetailsWeather weather &&
                   delays == weather.delays &&
                   snow == weather.snow &&
                   relativeHumidity == weather.relativeHumidity &&
                   windSpeed == weather.windSpeed &&
                   precip == weather.precip &&
                   visibility == weather.visibility;
        }
    }


}
