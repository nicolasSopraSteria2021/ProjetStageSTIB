using ProjetStageSTIB.Domain.Categories;
using ProjetStageSTIB.Domain.Line;
using ProjetStageSTIB.Domain.Station;
using ProjetStageSTIB.Domain.Vehicules;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using ProjetStageSTIB.Infrastructure.SqlServer.Stations;
using ProjetStageSTIB.Infrastructure.SqlServer.Vehicule;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Factories
{
    public class VehiculeFactory : IInstanceFromReaderFactory<IVehicule>
    {
        public IVehicule CreateFromReader(SqlDataReader reader)
        {
            return new VehiculeModel
            {
                
                Id= reader.GetInt32(reader.GetOrdinal(VehiculeServer.ColId)),
                Category = new Domain.Categories.Category
                {
                    Id = reader.GetInt32(reader.GetOrdinal(CategoryServer.ColId)),
                    vehiculeType = reader.GetString(reader.GetOrdinal(CategoryServer.ColType))

                },
                Line = new LineModel
                {
                    Id = reader.GetInt32(reader.GetOrdinal(LineServer.ColId)),
                    LineNumber = reader.GetInt32(reader.GetOrdinal(LineServer.ColLineNumber)),

                    StationArrival = new Station
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(StationServer.ColId)),
                        StationName = reader.GetString(reader.GetOrdinal(StationServer.ColStationName))
                    },

                    StationDeparture = new Station
                    {  
                        Id = reader.GetInt32(reader.GetOrdinal("idStats")),
                        StationName = reader.GetString(reader.GetOrdinal("stationDeparture"))
                    },

                    HourArrival = reader.GetDateTime(reader.GetOrdinal(LineServer.colHourArrival)),
                    HourDeparture = reader.GetDateTime(reader.GetOrdinal(LineServer.ColHourDeparture))
                }
            };
        }
    }
}
