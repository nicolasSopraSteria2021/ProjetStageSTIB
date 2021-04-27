using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.NewLine
{
    public class Line : INewLine
    {
        public int id { get; set; }
        public string date_observation { get; set; }
        public int delays { get; set; }
        public string trip_headsign { get; set; }
        public string stop_name { get; set; }
        public int lineNumber { get; set; }
        public string vehiculeType { get; set; }
        public double precip1Hour { get; set; }
        public double precip24Hour { get; set; }
        public double precip6Hour { get; set; }
        public double relativeHumidity { get; set; }
        public double snow1Hour { get; set; }
        public double snow24Hour { get; set; }
        public double snow6Hour { get; set; }
        public double temperature { get; set; }
        public double temperatureDewPo { get; set; }
        public double temperatureFeelsLike { get; set; }
        public double temperatureMax24Hour { get; set; }
        public double temperatureMin24Hour { get; set; }
        public double uvIndex { get; set; }
        public double visibility { get; set; }
        public double windSpeed { get; set; }
        public int prediction { get; set; }
    }
}
