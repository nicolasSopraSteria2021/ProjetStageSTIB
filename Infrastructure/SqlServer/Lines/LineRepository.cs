using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.Lines.Dto;
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
      
        //renvoie les lignes pour le retard en fonction du numéro defissant le type de  vehicule
        public IEnumerable<DtoLineForChart> GetLineForChart(string vehiculeType,string value)
        {
            IList<DtoLineForChart> lines= new List<DtoLineForChart>();
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
                        LineNumber = reader.GetInt32(reader.GetOrdinal("lineNumber")),
                        NumberOfDelay = reader.GetInt32(reader.GetOrdinal("countDelay")),
                        CountStopName = reader.GetInt32(reader.GetOrdinal("StopNameCount"))
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
                while(reader.Read())
                //on va ajouter l'entier que l'on trouve a la colonne lineNumber
                    lines.Add(reader.GetInt32(reader.GetOrdinal("lineNumber")));
                
                return lines;
            }

        }

        public IEnumerable<DtoDelayByHourBarChart> getDelayByHourBarChart(int lineNumber,string vehiculeType,string monthNumber)
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
                        delayForecast = reader.GetInt32(reader.GetOrdinal("delayForecast")),
                        hourArrival = reader.GetString(reader.GetOrdinal("timeArrival")),
                        prediction = reader.GetInt32(reader.GetOrdinal("prediction")),
                        snow = reader.GetDouble(reader.GetOrdinal("neige")),
                        relativeHumidity = reader.GetDouble(reader.GetOrdinal("humidity")),
                        windSpeed = reader.GetDouble(reader.GetOrdinal("vent")),
                        precip = reader.GetDouble(reader.GetOrdinal("precipitation")),
                        visibility = reader.GetDouble(reader.GetOrdinal("visibility"))
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
        }

    }

