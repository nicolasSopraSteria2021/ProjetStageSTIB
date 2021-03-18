using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Domain.Line;
using ProjetStageSTIB.Infrastructure.SqlServer.Factories;
using ProjetStageSTIB.Infrastructure.SqlServer.Shared;
using ProjetStageSTIB.Infrastructure.SqlServer.Vehicule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Lines
{
    //redefini les méthodes de l'interface ILineRepository
    public class LineRepository : ILineRepository
    {
        private readonly IInstanceFromReaderFactory<ILine> _LineFactory = new LineFactory();


        //permet de recuperer toutes les lines de la DB
        public IEnumerable<ILine> GetAllLine()
        {
            return null;
        }
        //renvoie les lignes pour le retard en fonction du numéro defissant le type de  vehicule
        public IEnumerable<ILine> GetLineForChart(int vehiculeType)
        {
            IList<ILine> lines= new List<ILine>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = LineServer.reqGetLineForChart;
                command.Parameters.AddWithValue($"@{VehiculeServer.ColCategory}", vehiculeType);
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    lines.Add(_LineFactory.CreateFromReader(reader));
                }
                return lines;
            }
        }

        //renvoie tous les numeros de lignes disponible 
        public IEnumerable<int> GetNumberOfLine(int vehiculeType)
        {
            //creation d'une liste 
            IList<int> lines = new List<int>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.Parameters.AddWithValue($"@{VehiculeServer.ColCategory}", vehiculeType);
                command.CommandText = LineServer.reqGetLineNumberByCategory;
                var reader = command.ExecuteReader();
                //tant que le reader arrive a lire quelque chose 
                while(reader.Read())
                //on va ajouter l'entier que l'on trouve a la colonne lineNumber
                    lines.Add(reader.GetInt32(reader.GetOrdinal("lineNumber")));
                
                return lines;
            }

        }

        public IEnumerable<DtoLineForLinearChart> GetForecastFromLine(int lineNumber)
        {
            //creation d'une liste 
            IList<DtoLineForLinearChart> lines = new List<DtoLineForLinearChart>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.Parameters.AddWithValue($"@{LineServer.ColLineNumber}", lineNumber);
                command.CommandText = LineServer.reqGetDelayForecastByLineNumber;
                var reader = command.ExecuteReader();
                while (reader.Read())
                    //ajout a la liste le DTO crée 
                    lines.Add(new DtoLineForLinearChart
                    {
                        delayForecast = reader.GetString(reader.GetOrdinal("delayForecast")),
                        hourArrival = reader.GetString(reader.GetOrdinal("timeArrival"))
                    });

                return lines;
            }

        }
    }
}
