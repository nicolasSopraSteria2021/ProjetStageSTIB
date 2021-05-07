using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using ProjetStageSTIB.Domain.NewLine;
using ProjetStageSTIB.Infrastructure.SqlServer.Factories;
using ProjetStageSTIB.Infrastructure.SqlServer.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Lines
{
    //redefini les méthodes de l'interface ILineRepository
    public class LineRepository : ILineRepository
    {

        private readonly IInstanceFromReaderFactory<INewLine> _factory = new LineFactory();

        //renvoie les lignes pour le retard en fonction du numéro defissant le type de  vehicule
        public IEnumerable<DtoLineForChart> GetLineForChart(string vehiculeType, string value)
        {
            IList<DtoLineForChart> lines = new List<DtoLineForChart>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqGetLineForChart;
                command.Parameters.AddWithValue($"@{LineServer.colvehiculeType}", vehiculeType);
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", value);
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    lines.Add(new DtoLineForChart
                    {
                        LineNumber = reader.IsDBNull("lineNumber") ? 0 : reader.GetInt32(reader.GetOrdinal("lineNumber")),
                        delays = reader.IsDBNull("countDelay") ? 0 : reader.GetInt32(reader.GetOrdinal("countDelay")),
                        CountStopName = reader.IsDBNull("StopNameCount") ? 0 : reader.GetInt32(reader.GetOrdinal("StopNameCount"))
                    });
                }
                return lines;
            }
        }

        //renvoie tous les numeros de lignes disponible 
        public IEnumerable<int> GetNumberOfLine(string vehiculeType)
        {
            //creation d'une liste 
            IList<int> lines = new List<int>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.Parameters.AddWithValue($"@{LineServer.colvehiculeType}", vehiculeType);
                command.CommandText = LineServer.reqGetLineNumberByCategory;
                var reader = command.ExecuteReader();
                //tant que le reader arrive a lire quelque chose 
                while (reader.Read())
                    //on va ajouter l'entier que l'on trouve a la colonne lineNumber
                    lines.Add(reader.IsDBNull("lineNumber") ? 0 : reader.GetInt32(reader.GetOrdinal("lineNumber")));
                return lines;
            }

        }

        public IEnumerable<DtoDelayByHourBarChart> getDelayByHourBarChart(int lineNumber, string vehiculeType, string monthNumber)
        {
            //creation d'une liste 
            IList<DtoDelayByHourBarChart> lines = new List<DtoDelayByHourBarChart>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.Parameters.AddWithValue($"@{LineServer.ColLineNumber}", lineNumber);
                command.Parameters.AddWithValue($"@{LineServer.colvehiculeType}", vehiculeType);
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", monthNumber);
                command.CommandText = LineServer.reqGetDelayForecastByLineNumber;
                var reader = command.ExecuteReader();
                while (reader.Read())
                    //ajout a la liste le DTO crée 
                    lines.Add(new DtoDelayByHourBarChart
                    {
                        delayForecast = reader.IsDBNull("delayFromDb") ? 0 : reader.GetInt32(reader.GetOrdinal("delayFromDb")),
                        hourArrival = reader.IsDBNull("timeArrival") ? "" : reader.GetString(reader.GetOrdinal("timeArrival")),
                        prediction = reader.IsDBNull("prediction") ? 0 : reader.GetInt32(reader.GetOrdinal("prediction")),
                        snow = reader.IsDBNull("neige") ? 0 : reader.GetDouble(reader.GetOrdinal("neige")),
                        relativeHumidity = reader.IsDBNull("temperature") ? 0 : reader.GetDouble(reader.GetOrdinal("temperature")),
                        windSpeed = reader.IsDBNull("vent") ? 0 : reader.GetDouble(reader.GetOrdinal("vent")),
                        precip = reader.IsDBNull("precipitation") ? 0 : reader.GetDouble(reader.GetOrdinal("precipitation")),
                        visibility = reader.IsDBNull("visibility") ? 0 : reader.GetDouble(reader.GetOrdinal("visibility"))
                    });

                return lines;
            }

        }
        public IEnumerable<int> GetYearsFromDb()
        {
            //creation d'une liste 
            IList<int> lines = new List<int>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqGetYears;
                var reader = command.ExecuteReader();
                int result = 0;
                while (reader.Read()) {
                    result = reader.IsDBNull("timeDb") ? 0 : reader.GetInt32("timeDb");
                    lines.Add(result);
                }
                return lines;
            }

        }
        public IEnumerable<string> GetMonthFromDb()
        {
            //creation d'une liste 
            IList<string> lines = new List<string>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqGetMonth;
                var reader = command.ExecuteReader();
                string result;
                while (reader.Read())
                {
                    result = reader.IsDBNull("timeDb") ? "NAN" : reader.GetString("timeDb");
                    lines.Add(result);
                }
                return lines;
            }

        }

        public DtoDetailsWeather getDetailsFromDate(string vehiculeType, string yearsValue)
        {
            IList<DtoDetailsWeather> dtoweahterList = new List<DtoDetailsWeather>();
            DtoDetailsWeather dto = new DtoDetailsWeather();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqGetDetailMeteo;
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", yearsValue);
                command.Parameters.AddWithValue($"@{LineServer.colvehiculeType}", vehiculeType);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dtoweahterList.Add(new DtoDetailsWeather
                    {

                        snow = reader.IsDBNull("neige") ? 0 : reader.GetDouble("neige"),
                        relativeHumidity = reader.IsDBNull("temperature") ? 0 : reader.GetDouble("temperature"),
                        windSpeed = reader.IsDBNull("vent") ? 0 : reader.GetDouble("vent"),
                        precip = reader.IsDBNull("precipitation") ? 0 : reader.GetDouble("precipitation"),
                        visibility = reader.IsDBNull("visibility") ? 0 : reader.GetDouble("visibility")

                    });
                }

                Console.WriteLine(dtoweahterList.Count);
                dto = new DtoDetailsWeather
                {
                    snow = (dtoweahterList[0].snow / dtoweahterList[1].snow) * 100,
                    relativeHumidity = (dtoweahterList[0].relativeHumidity / dtoweahterList[1].relativeHumidity) * 100,
                    windSpeed = (dtoweahterList[0].windSpeed / dtoweahterList[1].windSpeed) * 100,
                    precip = (dtoweahterList[0].precip / dtoweahterList[1].precip) * 100,
                    visibility = (dtoweahterList[0].visibility / dtoweahterList[1].visibility) * 100
                };
            }
            return dto;
        }
        public int GetCountDelayBus(string dateObser)
        {
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqGetCountByBus;
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", dateObser);
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
                command.CommandText = LineServer.reqGetCountByTram;
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", dateObser);
                var reader = (command.ExecuteReader(CommandBehavior.CloseConnection));
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
                command.CommandText = LineServer.reqCountNotDelayBus;
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", dateObser);
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
                command.CommandText = LineServer.reqCountNotDelayTram;
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", dateObser);
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
                command.CommandText = LineServer.reqCountNotDelayMetro;
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", dateObser);
                var reader = (command.ExecuteReader(CommandBehavior.CloseConnection));
                int result = 0;
                if (reader.Read())
                {
                    result = reader.IsDBNull("nonRetards") ? 0 : reader.GetInt32("nonRetards");

                }
                return result;

            }
        }


        public IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(string vehiculeType, string value)
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
        public IEnumerable<DtoSpecificTableDateObservation> GetDayByMonth(string vehiculeType, int value, string monthValue)
        {
            IList<DtoSpecificTableDateObservation> vehicules = new List<DtoSpecificTableDateObservation>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqGetDay;
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
        public DtoQueryMostDelay GetInfoForMostDelay(string vehiculeType, string value)
        {
            IList<DtoQueryMostDelay> vehicules = new List<DtoQueryMostDelay>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqForMostDelay;
                command.Parameters.AddWithValue($"@{LineServer.colvehiculeType}", vehiculeType);
                command.Parameters.AddWithValue($"@{LineServer.ColDateOb}", value);
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {

                    vehicules.Add(new DtoQueryMostDelay
                    {
                        lineNumber = reader.IsDBNull("lineNumber") ? 0 : reader.GetInt32("lineNumber"),
                        stationDeparture = reader.GetString(reader.GetOrdinal(LineServer.Coltrip)),
                        delayForecast = reader.IsDBNull("delays") ? 0 : reader.GetInt32("delays")
                    });
                }
                return vehicules[0];
            }
        }

       }
    }


