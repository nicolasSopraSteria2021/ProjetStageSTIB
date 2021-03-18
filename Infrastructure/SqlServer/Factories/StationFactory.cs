using ProjetStageSTIB.Domain.Station;
using ProjetStageSTIB.Infrastructure.SqlServer.Stations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Factories
{
    public class StationFactory : IInstanceFromReaderFactory<IStation>
    {
        public IStation CreateFromReader(SqlDataReader reader)
        {
            //return Station Object 
            return new Station
            {
                Id = reader.GetInt32(reader.GetOrdinal(StationServer.ColId)),
                StationName = reader.GetString(reader.GetOrdinal(StationServer.ColStationName))

            };
        }
    }
}
