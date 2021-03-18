using ProjetStageSTIB.Infrastructure.SqlServer.Stations;
using ProjetStageSTIB.Infrastructure.SqlServer.Vehicule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Lines
{
    public class LineServer
    {
        //Representation de la db en variable
        public static readonly string TableName = "line";
        public static readonly string ColId = "idLine";
        public static readonly string ColLineNumber = "lineNumber";
        public static readonly string ColStationDeparture = "id_station_departure";
        public static readonly string ColStationArrival = "id_station_arrival";
        public static readonly string ColHourDeparture = "hour_departure";
        public static readonly string colHourArrival = "hour_arrival";



        //creation des requetes 
        public static readonly string reqGetObjet = $" SELECT * FROM {TableName} INNER JOIN {StationServer.TableName} on {StationServer.ColId} = {ColStationArrival}";
        public static readonly string reqGetObjetById = reqGetObjet + $" WHERE {ColId} = @{ColId}";

        //recupère une la liste des lignes les plus en retards en fonction d'un type de vehicule
        public static readonly string reqGetLineForChart = $" SELECT count(distinct(tracking_vehicule.id_vehicule)) as 'countDelay', line.lineNumber from tracking_vehicule inner join VEHICULE on VEHICULE.idVeh = tracking_vehicule.id_vehicule inner join line on line.idLine = VEHICULE.id_line where tracking_vehicule.delay_forecast >'00:01' and VEHICULE.id_category=@{VehiculeServer.ColCategory} group by line.lineNumber order by count(distinct(tracking_vehicule.id_vehicule)) desc";

        //recupère le numero de ligne pour les grapghiques
        public static readonly string reqGetLineNumberByCategory = $"select distinct(line.lineNumber) from VEHICULE inner join line on line.idLine = VEHICULE.id_line inner join category on category.idCat = VEHICULE.id_category where VEHICULE.id_category=@{VehiculeServer.ColCategory}";

        //recupere les minutes pour le graphiques en fonction de la ligne 
        public static readonly string reqGetDelayForecastByLineNumber = $"select cast(delay_forecast as varchar(5)) as 'delayForecast' ,cast(cast(date_observation as time) as varchar(5)) as 'timeArrival' from tracking_vehicule " +
            $"inner join VEHICULE on tracking_vehicule.id_vehicule = VEHICULE.idVeh " +
            $"inner join line on line.idLine = VEHICULE.id_line where line.lineNumber=@{LineServer.ColLineNumber}";

        //recupère une liste d'objet qui reprend les dates et le nombre de retard par ordre decroissant
        public static readonly string reqDateCountDelayForLine = $"select distinct  count(distinct(id_vehicule)) as 'countVeh',cast(date_observation as varchar(11)) as 'dateOb' from tracking_vehicule " +
            $"inner join VEHICULE on tracking_vehicule.id_vehicule = VEHICULE.idVeh " +
            $"where delay_forecast>'00:01' and id_category =@{VehiculeServer.ColCategory}" +
            $" group by cast(date_observation as varchar(11)) " +
            $"order by 'countVeh' desc";
    
    }
}
