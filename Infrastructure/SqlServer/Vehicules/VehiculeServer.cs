using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using ProjetStageSTIB.Infrastructure.SqlServer.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Vehicule
{
    public class VehiculeServer
    {
        //representation de la db 
        public static readonly string TableName = "VEHICULE";
        public static readonly string ColId = "idVeh";
        public static readonly string ColLine = "id_line";
        public static readonly string ColCategory = "id_category";



        //creation des requetes 

        //recupere un liste de vehicule de tout type ajouter une condition avec la date et l'heure d'ajd
        public static readonly string reqGetObjet = $" SELECT {ColId} ,line.idLine, line.lineNumber, line.hour_arrival,line.hour_departure, ap.STATION_NAME as 'stationDeparture' ,ap.idstat as 'idStats' , station.STATION_NAME, station.idstat,category.idCat,category.vehicule_type FROM {TableName}  " +
            $"INNER JOIN {CategoryServer.TableName} category on {ColCategory}={CategoryServer.ColId} " +
            $"INNER JOIN {LineServer.TableName} line on {ColLine}={LineServer.ColId} " +
            $"INNER JOIN {StationServer.TableName} station on {StationServer.ColId} =line.id_station_arrival " +
            $"INNER JOIN {StationServer.TableName} as ap on ap.idstat =line.id_station_departure";

        public static readonly string reqGetObjetById = reqGetObjet + $" WHERE {ColId} = @{ColId}";




        //requete qui recupere le nombre de retards par heure 
        public static readonly string requGetListForGraphDelay = $"SELECT {ColId},line.lineNumber,tracking_vehicule.date_observation";
    }
}
