using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.TrackingVehicules
{
    public class TrackingVehiculeService : ITrackingVehiculeService
    {
        //appel des repo 
        private readonly ITrackingVehiculeRepository _trackingVehiculeRepository;

        public TrackingVehiculeService(ITrackingVehiculeRepository trackingVehiculeRepository)
        {
            _trackingVehiculeRepository = trackingVehiculeRepository;
        }


        // recupere le nombre de retard de chaque vehicule par l'intermediaire du repository
        public int GetCountBusTrackingVehicule(string dateObser)
        {
            return _trackingVehiculeRepository.GetCountDelayBus(dateObser);
        }
        
        public int GetCountMetroTrackingVehicule(string dateObser)
        {
            return _trackingVehiculeRepository.GetCountDelayMetro(dateObser);
        }

        public int GetCountTramTrackingVehicule(string dateObser)
        {
            return _trackingVehiculeRepository.GetCountDelayTram(dateObser);
        }
        // recupere le temps de retard de chaque vehicule par l'intermediaire du repository
    
        // recupere le nombre de non retard de chaque vehicule par l'intermediaire du repository
        public int GetCountBusNotDelay(string dateObser)
        {
            return _trackingVehiculeRepository.GetCountNotDelayBus(dateObser);
        } 

        public int GetCountTramNotDelay(string dateObser)
        {
            return _trackingVehiculeRepository.GetCountNotDelayTram(dateObser);
        }

        public int GetCountMetroNotDelay(string dateObser)
        {
            return _trackingVehiculeRepository.GetCountNotDelayMetro(dateObser);
        }

        public IEnumerable<DtoSpecificTableDateObservation> GetDayByMonth(string vehiculeType, int value, string monthValue)
        {
            return _trackingVehiculeRepository.GetDayByMonth(vehiculeType, value, monthValue);
        }


        //renvoie le nombre de retard ainsi que la date en fonction du numero definissant le type de vehicule
        public IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(string vehiculeType,string value)
        {
            return _trackingVehiculeRepository.GetInfoForTable(vehiculeType,value);
        }
        //renvoie toutes les infos nécessaires a propos de la ligne la plus en retards
        public DtoQueryMostDelay GetInfoForMostDelay(string vehiculeType,string value)
        {
            return _trackingVehiculeRepository.GetInfoForMostDelay(vehiculeType,value);
        }
    }
}
