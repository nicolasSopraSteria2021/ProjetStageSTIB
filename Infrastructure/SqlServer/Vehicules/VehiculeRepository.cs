using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Domain.Line;
using ProjetStageSTIB.Domain.Vehicules;
using ProjetStageSTIB.Infrastructure.SqlServer.Factories;
using ProjetStageSTIB.Infrastructure.SqlServer.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Vehicule
{
    public class VehiculeRepository : IVehiculeRepository
    {
        //Instance of VehiculeFactory
        private readonly IInstanceFromReaderFactory<IVehicule> _VehiculeFactory = new VehiculeFactory();

        public IEnumerable<IVehicule> GetAll()
        {
            IList<IVehicule> vehicules = new List<IVehicule>();
            using (var sqlConnection = DataBase.GetConnection())
            {
                sqlConnection.Open();
                var command = sqlConnection.CreateCommand();
                command.CommandText = VehiculeServer.reqGetObjet;
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    vehicules.Add(_VehiculeFactory.CreateFromReader(reader));
                }
                return vehicules;
            }
           
        }
    }
}
