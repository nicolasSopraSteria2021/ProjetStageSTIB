namespace ProjetStageSTIB.Infrastructure.SqlServer.Lines
{
    public class LineServer
    {
        //Representation de la db en variable
        public static readonly string TableName = "line";
        public static readonly string ColId = "idLine";
        public static readonly string ColLineNumber = "lineNumber";
        public static readonly string ColDateOb = "date_observation";
        public static readonly string ColStationArrival = "id_station_arrival";
        public static readonly string ColHourDeparture = "hour_departure";
        public static readonly string colvehiculeType = "vehiculeType";
        public static readonly string Coltrip = "trip_headsign";

    
        //recupère une  liste des lignes les plus en retards en fonction d'un type de vehicule
        public static readonly string reqGetLineForChart = $"select lineNumber as'lineNumber', sum(delays) as 'countDelay', count(distinct(stop_name))as 'StopNameCount' from line where vehiculeType=@{LineServer.colvehiculeType} and (year(date_observation))=@{LineServer.ColDateOb}  group by lineNumber order by sum(delays) desc";

        //recupère le numero de ligne pour les grapghiques
        public static readonly string reqGetLineNumberByCategory = $"select distinct(line.lineNumber) from line where vehiculeType=@{LineServer.colvehiculeType} order by lineNumber desc";

       //recupere les heures et les retards d'une ligne,d'un mois et d'une année donnée. 
        public static readonly string reqGetDelayForecastByLineNumber = $"select avg(prediction) as 'prediction', avg(delays) as 'delayForecast',cast(cast(date_observation as time)as varchar(5)) as'timeArrival',avg(snow24Hour) as 'neige',avg(temperature) as 'humidity',avg(windSpeed) as 'vent' ,avg(precip24hour)as 'precipitation',avg(visibility) as 'visibility' " +
            $"from line where vehiculeType =@{LineServer.colvehiculeType} and YEAR(date_observation)=year(@{LineServer.ColDateOb}) and lineNumber =@{LineServer.ColLineNumber} and month(date_observation)=month(@{LineServer.ColDateOb})   group by cast(cast(date_observation as time)as varchar(5))  order by cast(cast(date_observation as time)as varchar(5))";

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
