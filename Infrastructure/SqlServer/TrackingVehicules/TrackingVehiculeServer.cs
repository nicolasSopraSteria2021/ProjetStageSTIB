using ProjetStageSTIB.Infrastructure.SqlServer.Vehicule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.TrackingVehicules
{
    public class TrackingVehiculeServer
    {
        //representation de la db
        public static readonly string TableName = "tracking_vehicule";
        public static readonly string ColId = "id";
        public static readonly string ColVehicule = "id_vehicule";
        public static readonly string ColDateObs = "date_observation";
        public static readonly string ColDelayMin = "delay_min";
        public static readonly string ColDelayForecast = "delay_forecast";

        public static readonly string reqGetObjet = $" SELECT * FROM {TableName}";
        public static readonly string reqGetObjetById = reqGetObjet + $" WHERE {ColId} = @{ColId}";


        //requete générique pour recuperer le nombre de retard en fonction d'une date selon la category
        public static readonly string reqCount = $"SELECT COUNT(DISTINCT({ColVehicule})) FROM {TableName} " +
            $"INNER JOIN {VehiculeServer.TableName} " +
            $"on {VehiculeServer.ColId} ={TrackingVehiculeServer.ColVehicule} " +
            $"where date_observation >= @{ColDateObs} " +
            $"AND date_observation< current_timestamp" +
            $" AND VEHICULE.id_category=";

        //definition de la category ( 3 = bus , 2 = metro , 1 = Tram ) 
        public static readonly string reqGetCountByBus = reqCount + $"3";
        public static readonly string reqGetCountByMetro = reqCount + $"2";
        public static readonly string reqGetCountByTram = reqCount + $"1";

        //requete générique pour recuperer le temps de retard en fonction d'une date selon la category
        public static readonly string reqGetTime = $"select sum(distinct( " +
            $"(DATEPART(HOUR, tracking_vehicule.delay_forecast) * 3600) + " +
            $"(DATEPART(MINUTE, tracking_vehicule.delay_forecast) * 60) +" +
            $"(DATEPART(SECOND, tracking_vehicule.delay_forecast)))) " +
            $" FROM tracking_vehicule " +
            $"INNER JOIN VEHICULE on tracking_vehicule.id_vehicule = VEHICULE.idVeh " +
            $"where date_observation >= @{ColDateObs} " +
            $"AND date_observation< current_timestamp " +
            $"AND VEHICULE.id_category=";

        //definition de la category ( 3 = bus , 2 = metro , 1 = Tram ) 
        public static readonly string reqGetTimeDelayBus = reqGetTime + $"3";
        public static readonly string reqGetTimeDelayTam = reqGetTime + $"2";
        public static readonly string reqGetTimeDelayMetro = reqGetTime + $"1";

        public static readonly string reqCountNotDelay = $"select count(distinct(tracking_vehicule.id_vehicule)) from tracking_vehicule" +
            $" inner join VEHICULE on VEHICULE.idVeh=tracking_vehicule.id_vehicule " +
            $"where tracking_vehicule.delay_min<'00:01' " +
            $"AND date_observation >= @{ColDateObs} " +
            $"AND date_observation<current_timestamp " +
            $"and VEHICULE.id_category= ";

        //definition de la category ( 3 = bus , 2 = metro , 1 = Tram ) 
        public static readonly string reqCountNotDelayBus =reqCountNotDelay+$"3";
        public static readonly string reqCountNotDelayMetro =reqCountNotDelay+$"2";
        public static readonly string reqCountNotDelayTram=reqCountNotDelay+$"1";

        // bonne requete quand on aura toutes les données 
        // select distinct(tracking_vehicule.id_vehicule),line.lineNumber, line.hour_arrival,line.hour_departure,STATION.STATION_NAME, ap.STATION_NAME as 'stationDeparture' from tracking_vehicule inner join VEHICULE on VEHICULE.idVeh = tracking_vehicule.id_vehicule inner join line on line.idLine = VEHICULE.id_line inner join STATION on STATION.idstat=line.id_station_arrival inner join STATION as ap on ap.idstat=line.id_station_departure where delay_forecast>'00:10' and  CAST(tracking_vehicule.date_observation as DATE)=CAST(GETDATE() as DATE) order by line.LineNumber;
        public static readonly string reqForWarning = $"select distinct(tracking_vehicule.id_vehicule),line.lineNumber, line.hour_arrival,line.hour_departure,cast(delay_forecast as varchar(5)) as 'delay_forecast',STATION.STATION_NAME, ap.STATION_NAME as 'stationDeparture' from tracking_vehicule" +
            $" inner join VEHICULE on VEHICULE.idVeh = tracking_vehicule.id_vehicule " +
            $"inner join line on line.idLine = VEHICULE.id_line " +
            $"inner join STATION on STATION.idstat=line.id_station_arrival " +
            $"inner join STATION as ap on ap.idstat=line.id_station_departure" +
            $" where delay_forecast>'00:10' order by line.LineNumber";


        public static readonly string reqForMostDelay = $"select distinct(line.idLine),line.lineNumber,STATION.STATION_NAME,ap.STATION_NAME as 'apStation',cast(delay_forecast as varchar(5)) as 'delay' from tracking_vehicule " +
            $"inner join VEHICULE on VEHICULE.idVeh=tracking_vehicule.id_vehicule " +
            $"inner join line on VEHICULE.id_line = line.idLine " +
            $"inner join STATION on STATION.idstat = line.id_station_arrival " +
            $"inner join STATION as ap on ap.idstat = line.id_station_departure " +
            $"where VEHICULE.id_category=@{VehiculeServer.ColCategory}  order by 'delay' desc";
    }

}
