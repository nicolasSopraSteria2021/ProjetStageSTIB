using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Infrastructure.SqlServer.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Stations
{
    public class StationService : IStationService
    {
        //appel des repo
        private readonly IStationRepository _StationRepository;

        //constructeur pour creation d'un singleton
        public StationService(IStationRepository StationRepository)
        {
            _StationRepository = StationRepository;
        }
        //On renvoie une liste de DtoStationQuery par la ma méthode GetAllStation qui renvoie une liste de IStation
        public IEnumerable<DtoStationQuery> GetStation()
        {
            //automapper
            return _StationRepository.GetAllStation().Select(station => new DtoStationQuery
            {
                Id = station.Id,
                Station_name = station.StationName
            });
        }
    }
}
