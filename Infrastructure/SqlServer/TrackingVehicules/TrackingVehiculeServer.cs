using ProjetStageSTIB.Infrastructure.SqlServer.Lines;

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


        //renvoie le nombre de retard en fonction d'une date 
        public static readonly string reqCount = $"select count(delays) as 'retards' from line where date_observation >=@{ColDateObs} and date_observation<current_timestamp and vehiculeType like('";

        public static readonly string reqGetCountByBus = reqCount + $"Bus')";
        public static readonly string reqGetCountByMetro = reqCount + $"Metro')";
        public static readonly string reqGetCountByTram = reqCount + $"Tram')";

      
        //recupère le nombre de vehicule a l'heure 
        public static readonly string reqCountNotDelay = $"select count(delays) as 'nonRetards' from line where date_observation >=@{ColDateObs} and date_observation<current_timestamp and delays = 0 ";
        public static readonly string reqCountNotDelayBus =reqCountNotDelay+$"and vehiculeType like('Bus') ";
        public static readonly string reqCountNotDelayMetro =reqCountNotDelay+$"and vehiculeType like('Metro') ";
        public static readonly string reqCountNotDelayTram=reqCountNotDelay+$"and vehiculeType like('Tram') ";

       
        public static readonly string reqForMostDelay = $"select lineNumber as 'lineNumber',sum(delays) as 'delays',trip_headsign from line where vehiculeType=@{LineServer.colvehiculeType} and year({LineServer.ColDateOb})=@{LineServer.ColDateOb} group by lineNumber,trip_headsign order by sum(delays) desc";

        //renvoie les jours du mois selectionner par le graphiques avec le nombre de retars par mois 
        public static readonly string reqGetDay = $"select avg(delays) as 'countVeh',cast(date_observation as varchar(11)) as 'dateOb',avg(snow24Hour) as 'neige',avg(prediction) as 'humidity',avg(windSpeed) as 'vent' ,avg(precip24hour)as 'precipitation',avg(visibility) as 'visibility'" +
            $" from line where vehiculeType = @{LineServer.colvehiculeType}  and(year(date_observation))=year(@{LineServer.ColDateOb}) and month(date_observation)=month(@{LineServer.ColDateOb})   group by cast(date_observation as varchar(11)) order by cast(date_observation as varchar(11)) ";
    }

}
