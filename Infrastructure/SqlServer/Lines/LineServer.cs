using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Lines
{
    public class LineServer
    {
        public static readonly string TableName = "line";
        public static readonly string ColId = "id";
        public static readonly string ColLineNumber = "lineNumber";
        public static readonly string ColStationDeparture = "id_station_departure";
        public static readonly string ColStationArrival = "id_station_arrival";
        public static readonly string ColHourDeparture = "hour_departure";
        public static readonly string colHourArrival = "hour_arrival";

        public static readonly string reqGetObjet = $" SELECT * FROM {TableName}";
        public static readonly string reqGetObjetById = reqGetObjet + $" WHERE {ColId} = @{ColId}";
    }
}
