namespace ProjetStageSTIB.Infrastructure.SqlServer.Lines
{
    public class LineServer
    {
        //Representation de la db en variable
        public static readonly string TableName = "line";
        public static readonly string ColId = "id";
        public static readonly string ColLineNumber = "lineNumber";
        public static readonly string ColDateOb = "date_observation";
        public static readonly string colvehiculeType = "vehiculeType";
        public static readonly string Coltrip = "trip_headsign";
        public static readonly string ColPrediction = "prediction";
        public static readonly string ColDelays = "delays";
        public static readonly string ColSnow = "snow24Hour";
        public static readonly string ColTemp = "temperature";
        public static readonly string ColWind = "windSpeed";
        public static readonly string ColPrec = "precip24hour";
        public static readonly string ColVis = "visibility";
        public static readonly string ColSnow6 = "snow6Hour";
        public static readonly string colTempDewPo = "temperatureDewPo";
        public static readonly string colTempFeels ="temperatureFeelsLike";
        public static readonly string  colTempMax="temperatureMax24Hour";
        public static readonly string colTempMin="temperatureMin24Hour" ;
        public static readonly string colUv ="uvIndex" ;
        public static readonly string colStopName = "stop_name";
        public static readonly string colHumidity = "relativeHumidity";





    
        //recupère une  liste des lignes les plus en retards en fonction d'un type de vehicule
      public static readonly string reqGetLineForChart = $"select lineNumber as'lineNumber', sum(delays) as 'countDelay', count(distinct(stop_name))as 'StopNameCount' from line where vehiculeType=@{LineServer.colvehiculeType} and (year(date_observation))=@{LineServer.ColDateOb}  group by lineNumber order by sum(delays) desc";
       // public static readonly string reqGetLineForChart = $"select avg(delays) as 'countDelay', avg(prediction) as'lineNumber', ROUND(precip24Hour,2) as 'StopNameCount' from line where vehiculeType=@{LineServer.colvehiculeType} and (month(date_observation))=month(@{LineServer.ColDateOb}) group by ROUND(precip24Hour,2) order by ROUND(precip24Hour,2) asc";

        //recupère le numero de ligne pour les grapghiques
        public static readonly string reqGetLineNumberByCategory = $"select distinct(line.lineNumber) from line where vehiculeType=@{LineServer.colvehiculeType} order by lineNumber desc";

       //recupere la moyenne des  heures,des retards predits et des retards réels sur un arret d'une ligne,d'un mois et d'une année donnée. 
        public static readonly string reqGetDelayForecastByLineNumber = 
            $"select avg({LineServer.ColPrediction}) as 'prediction', avg({LineServer.ColDelays}) as 'delayFromDb'," +
            $"cast(cast(date_observation as time)as varchar(5)) as'timeArrival'," +
            $"avg({LineServer.ColSnow}) as 'neige',avg({LineServer.ColTemp}) as 'temperature'" +
            $",avg({LineServer.ColWind}) as 'vent' ,avg({LineServer.ColPrec})as 'precipitation',avg({LineServer.ColVis}) as 'visibility' " +
            $"from line " +
            $"where vehiculeType =@{LineServer.colvehiculeType} " +
            $"and YEAR(date_observation)=year(@{LineServer.ColDateOb}) " +
            $"and lineNumber =@{LineServer.ColLineNumber} " +
            $"and month(date_observation)=month(@{LineServer.ColDateOb})   " +
            $"group by cast(cast(date_observation as time)as varchar(5))  " +
            $"order by cast(cast(date_observation as time)as varchar(5))";

        //recupere la date et son nombre de retard. Ces données seront utilisées dans le tableau en dessous du barchart
        public static readonly string reqDateCountDelayForLine = $"select sum(delays) as 'countVeh',sum(prediction) as 'prediction',cast(date_observation as varchar(4)) as 'dateOb' from line where vehiculeType=@{LineServer.colvehiculeType}  and (year(date_observation))=@{LineServer.ColDateOb}  group by cast(date_observation as varchar(4)) order by sum(delays) desc";
        //récupere les années utilisées dans la base de données
        public static readonly string reqGetYears = $"select distinct(year(date_observation)) as 'timeDb' from line";
        //recupère tout les mois de la db
        public static readonly string reqGetMonth = $"select concat(cast(date_observation as varchar(4)),year(date_observation)) as 'timeDb' from line group by concat(cast(date_observation as varchar(4)),year(date_observation)) ";

        //requete qui renvoie les details météo pour le radarchart 
        public static readonly string reqGetDetailMeteo = $" select avg(snow24Hour) as 'neige',avg(temperature)as 'temperature',avg(windSpeed) as 'vent' ,avg(precip24Hour) as 'precipitation',avg(visibility) as 'visibility' " +
            $"from line where vehiculeType = @{LineServer.colvehiculeType} and cast((date_observation) as varchar(11)) =@{ LineServer.ColDateOb} union select max(snow24Hour) as 'neige',max(temperature) as 'temperature',max(windSpeed) as 'vent' ,max(precip24Hour) as 'precipitation',max(visibility) as 'visibility' " +
            $"from line where vehiculeType = @{LineServer.colvehiculeType} and month(date_observation) =month(@{LineServer.ColDateOb})";

      
    }
}
