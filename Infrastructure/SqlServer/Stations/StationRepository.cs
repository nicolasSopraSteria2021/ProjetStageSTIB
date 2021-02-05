using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Domain.Station;
using ProjetStageSTIB.Infrastructure.SqlServer.Factories;
using ProjetStageSTIB.Infrastructure.SqlServer.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Stations
{
    public class StationRepository : IStationRepository
    {
        //Instance of StationFactory
        private readonly IInstanceFromReaderFactory<IStation> _factory = new StationFactory();

        //return a list of stations
        public IEnumerable<IStation> GetAllStation()
        {
            //init a list of station
            IList<IStation> stations = new List<IStation>();
            using (var connection = DataBase.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = StationServer.reqGetObjet;
                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //until the reader can read in the db 
                while (reader.Read())
                {
                    stations.Add(_factory.CreateFromReader(reader));
                }
            }
            return stations;
        }

        public IStation GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
