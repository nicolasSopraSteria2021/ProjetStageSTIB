using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Stations
{
    public class StationServer
    {
        //representation de la db 
        public static readonly string TableName ="STATION";
        public static readonly string ColId ="idstat";
        public static readonly string ColStationName ="STATION_NAME";

        public static readonly string reqGetObjet = $" SELECT * FROM {TableName}";
        public static readonly string reqGetObjetById = reqGetObjet + $" WHERE {ColId} = @{ColId}";


        //creation des requetes 
    }
}
