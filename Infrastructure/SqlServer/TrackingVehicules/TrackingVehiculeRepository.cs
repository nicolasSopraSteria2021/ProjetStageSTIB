using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using ProjetStageSTIB.Domain.Tracking_Vehicule;
using ProjetStageSTIB.Infrastructure.SqlServer.Factories;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using ProjetStageSTIB.Infrastructure.SqlServer.Shared;
using ProjetStageSTIB.Infrastructure.SqlServer.Stations;
using ProjetStageSTIB.Infrastructure.SqlServer.Vehicule;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjetStageSTIB.Infrastructure.SqlServer.TrackingVehicules
{
    public class TrackingVehiculeRepository : ITrackingVehiculeRepository
    {
        //Instance of TrackingFactory
        private readonly IInstanceFromReaderFactory<ITrackingVehicule> _TrackingVehicule = new TrackingVehiculeFactory();

        public int GetCountDelayBus(string dateObser)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqGetCountByBus;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", dateObser);
                double reader =(int)(command.ExecuteScalar());

                sqlConnection.Close();
                return (int)reader;
                Console.WriteLine(reader);
               
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
                int reader = (int)(command.ExecuteScalar());
                sqlConnection.Close();
                return reader;
                Console.WriteLine(reader);

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
                int reader = (int)(command.ExecuteScalar());
                sqlConnection.Close();
                return reader;

            }
        }

        public int GetTimeDelayByBus(string DateObserstart)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqGetTimeDelayBus;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", DateObserstart);
                int reader = (int)(command.ExecuteScalar());
                sqlConnection.Close();
                return reader;
                Console.WriteLine(reader);

            }
        }

        public int GetTimeDelayByTram(string DateObserstart)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqGetTimeDelayTam;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", DateObserstart);
                int reader = (int)(command.ExecuteScalar());
                sqlConnection.Close();
                return reader;
                Console.WriteLine(reader);

            }
        }

        public int GetTimeDelayByMetro(string DateObserstart)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqGetTimeDelayMetro;
                command.Parameters.AddWithValue($"@{TrackingVehiculeServer.ColDateObs}", DateObserstart);
                int reader = (int)(command.ExecuteScalar());
                sqlConnection.Close();
                return reader;
                Console.WriteLine(reader);

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
                int reader = (int)(command.ExecuteScalar());
                sqlConnection.Close();
                return reader;
                Console.WriteLine(reader);

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
                int reader = (int)(command.ExecuteScalar());
                sqlConnection.Close();
                return reader;
                Console.WriteLine(reader);

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
                int reader = (int)(command.ExecuteScalar());
                sqlConnection.Close();
                return reader;
                Console.WriteLine(reader);

            }
        }
        public IEnumerable<ITrackingVehicule> GetInfoForWarning()
        {
            IList<ITrackingVehicule> vehicules = new List<ITrackingVehicule>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqForWarning;
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    vehicules.Add(_TrackingVehicule.CreateFromReader(reader));
                }
                return vehicules;

            }
        }

        public IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(int vehiculeType/*,string timeChange*/)
        {
            IList<DtoSpecificTableDateObservation> vehicules = new List<DtoSpecificTableDateObservation>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqDateCountDelayForLine;
                command.Parameters.AddWithValue($"@{VehiculeServer.ColCategory}", vehiculeType);
               // command.Parameters.AddWithValue($"@{LineServer.colTimeChange}", timeChange);
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
        public DtoQueryMostDelay GetInfoForMostDelay(int vehiculeType)
        {
            IList<DtoQueryMostDelay> vehicules = new List<DtoQueryMostDelay>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = TrackingVehiculeServer.reqForMostDelay;
                command.Parameters.AddWithValue($"@{VehiculeServer.ColCategory}", vehiculeType);
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {

                    vehicules.Add(new DtoQueryMostDelay
                    {
                        idLine = reader.GetInt32(reader.GetOrdinal(LineServer.ColId)),
                        lineNumber = reader.GetInt32(reader.GetOrdinal(LineServer.ColLineNumber)),
                        stationDeparture = reader.GetString(reader.GetOrdinal(StationServer.ColStationName)),
                        stationArrival = reader.GetString(reader.GetOrdinal("apStation")),
                        delayForecast = reader.GetString(reader.GetOrdinal("delay"))
                    });
                }
                return vehicules[0];               
            }
        }
    }
}
