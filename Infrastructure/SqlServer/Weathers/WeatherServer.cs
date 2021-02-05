using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Lines
{
    public class WeatherServer
    {
        public static readonly string TableName = "WEATHER";
        public static readonly string ColId = "id";
        public static readonly string ColTemperature = "temperature";
        public static readonly string ColRain = "rain_precipitation";
        public static readonly string ColWind = "wind_precipitation";
        public static readonly string ColSnow = "snow_precipitation";

        public static readonly string reqGetObjet = $" SELECT * FROM {TableName}";
        public static readonly string reqGetObjetById = reqGetObjet + $" WHERE {ColId} = @{ColId}";
    }
}
