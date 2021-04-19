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
    }
}
