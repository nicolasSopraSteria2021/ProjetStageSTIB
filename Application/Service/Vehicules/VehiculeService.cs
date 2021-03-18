using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Domain.Vehicules;
using ProjetStageSTIB.Domain.Vehicules.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Vehicules
{
    public class VehiculeService : IVehiculeService
    {
        //appel du repository 
        private readonly IVehiculeRepository _vehiculeRepository;
       

        //constructeur
        public VehiculeService(IVehiculeRepository vehiculeRepository)
        {
            _vehiculeRepository = vehiculeRepository;
           
        }

        //renvoie tous les vehicules en routes aujourd'hui 
        public IEnumerable<DtoQueryVehicule> GetVehicule()
        {
           //creation du DTO 
            return _vehiculeRepository.GetAll().Select(vehicule => new DtoQueryVehicule {
                id = vehicule.Id,
                category = vehicule.Category.vehiculeType,
                stationArrival = vehicule.Line.StationArrival.StationName,
                stationDeparture = vehicule.Line.StationDeparture.StationName,
                lineNumber = vehicule.Line.LineNumber,
                hourArrival = vehicule.Line.HourArrival,
                hourDeparture = vehicule.Line.HourDeparture

            });   

        }
    }
}
