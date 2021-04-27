using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using ProjetStageSTIB.Domain.Tracking_Vehicule;
using ProjetStageSTIB.Infrastructure.SqlServer.Factories;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using ProjetStageSTIB.Infrastructure.SqlServer.Shared;
using System.Collections.Generic;
using System.Data;

namespace ProjetStageSTIB.Infrastructure.SqlServer.TrackingVehicules
{
    public class TrackingVehiculeRepository : ITrackingVehiculeRepository
    {
        
        public int GetCountDelayBus(string dateObser)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqGetCountByBus;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", dateObser);
                var reader = (command.ExecuteReader(CommandBehavior.CloseConnection));
                int result = 0;
                if (reader.Read())
                {
                    result = reader.IsDBNull("retards") ? 0 : reader.GetInt32("retards");

                }
                return result;

            }
        }

        public int GetCountDelayTram(string dateObser)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqGetCountByTram;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", dateObser);
                var reader = (command.ExecuteReader(CommandBehavior.CloseConnection));
                int result = 0;
                if (reader.Read()) {
                    result = reader.IsDBNull("retards") ? 0 : reader.GetInt32("retards");
               
                }
                return result;
          

            }
        }
        public int GetCountDelayMetro(string dateObser)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqGetCountByMetro;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", dateObser);
               var  reader = (command.ExecuteReader(CommandBehavior.CloseConnection));
                int result = 0;
                if (reader.Read())
                {
                    result = reader.IsDBNull("retards") ? 0 : reader.GetInt32("retards");

                }
                return result;

            }
        }


        public int GetCountNotDelayBus(string dateObser)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqCountNotDelayBus;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", dateObser);
                var reader = (command.ExecuteReader(CommandBehavior.CloseConnection));
                int result = 0;
                if (reader.Read())
                {
                    result = reader.IsDBNull("nonRetards") ? 0 : reader.GetInt32("nonRetards");

                }
                return result;

            }
        }

        public int GetCountNotDelayTram(string dateObser)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqCountNotDelayTram;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", dateObser);
                var reader = (command.ExecuteReader(CommandBehavior.CloseConnection));
                int result = 0;
                if (reader.Read())
                {
                    result = reader.IsDBNull("nonRetards") ? 0 : reader.GetInt32("nonRetards");

                }
                return result;

            }
        }

        public int GetCountNotDelayMetro(string dateObser)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqCountNotDelayMetro;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", dateObser);
                var reader = (command.ExecuteReader(CommandBehavior.CloseConnection));
                int result = 0;
                if (reader.Read())
                {
                    result = reader.IsDBNull("nonRetards") ? 0 : reader.GetInt32("nonRetards");

                }
                return result;

            }
        }
  

        public IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(string vehiculeType,string value)
        {
            IList<DtoSpecificTableDateObservation> vehicules = new List<DtoSpecificTableDateObservation>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqDateCountDelayForLine;
                command.Parameters.AddWithValue($"@{LineServer.colvehiculeType}", vehiculeType);
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", value);
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                   
                    vehicules.Add(new DtoSpecificTableDateObservation
                    {
                        count = reader.GetInt32(reader.GetOrdinal("countVeh")),
                        dateObservation = reader.GetString(reader.GetOrdinal("dateOb"))
                    });
                }
                return vehicules;

            }
        }
        //renvoies les jours du mois ciblé
        public IEnumerable<DtoSpecificTableDateObservation> GetDayByMonth(string vehiculeType, int value,string monthValue )
        {
            IList<DtoSpecificTableDateObservation> vehicules = new List<DtoSpecificTableDateObservation>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqGetDay;
                command.Parameters.AddWithValue($"@{LineServer.colvehiculeType}", vehiculeType);
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", monthValue);
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {

                    vehicules.Add(new DtoSpecificTableDateObservation
                    {
                        count = reader.GetInt32(reader.GetOrdinal("countVeh")),
                        dateObservation = reader.GetString(reader.GetOrdinal("dateOb")),
                        snow = reader.GetDouble(reader.GetOrdinal("neige")),
                        relativeHumidity = reader.GetInt32(reader.GetOrdinal("humidity")),
                        windSpeed = reader.GetDouble(reader.GetOrdinal("vent")),
                        precip = reader.GetDouble(reader.GetOrdinal("precipitation")),
                        visibility = reader.GetDouble(reader.GetOrdinal("visibility"))
                    });
                }
                return vehicules;

            }
        }

        //renvoie les informations sur la lignes la plus en retards
        public DtoQueryMostDelay GetInfoForMostDelay(string vehiculeType,string value)
        {
            IList<DtoQueryMostDelay> vehicules = new List<DtoQueryMostDelay>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqForMostDelay;
                command.Parameters.AddWithValue($"@{LineServer.colvehiculeType}", vehiculeType);
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", value);
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {

                    vehicules.Add(new DtoQueryMostDelay
                    {
                        lineNumber = reader.GetInt32(reader.GetOrdinal("lineNumber")),
                        stationDeparture = reader.GetString(reader.GetOrdinal(LineServer.Coltrip)),
                        delayForecast = reader.GetInt32(reader.GetOrdinal("delays"))
                    });
                }
                return vehicules[0];               
            }
        }

    }
}
