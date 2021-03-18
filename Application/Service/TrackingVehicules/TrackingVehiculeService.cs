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
        public int GetTimeDelayBusTrackingVehicule(string dateObser)
        {
            return _trackingVehiculeRepository.GetTimeDelayByBus(dateObser);
        }

        public int GetTimeDelayTramTrackingVehicule(string dateObser)
        {
            return _trackingVehiculeRepository.GetTimeDelayByTram(dateObser);
        }

        public int GetTimeDelayMetroTrackingVehicule(string dateObser)
        {
            return _trackingVehiculeRepository.GetTimeDelayByMetro(dateObser);
        }
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
        // recupere les lignes qui ont plus de 10 min de retard
        public IEnumerable<DtoWarningQueryTrackingVeh> GetInfoForWarning()
        {
            //creation du DTO
            return _trackingVehiculeRepository.GetInfoForWarning().Select(vehicule => new DtoWarningQueryTrackingVeh
            {
                id = vehicule.Id,
                stationArrival = vehicule.ID_Vehicule.Line.StationArrival.StationName,
                stationDeparture = vehicule.ID_Vehicule.Line.StationDeparture.StationName,
                lineNumber = vehicule.ID_Vehicule.Line.LineNumber,
                hourArrival = vehicule.ID_Vehicule.Line.HourArrival,
                hourDeparture = vehicule.ID_Vehicule.Line.HourDeparture,
                delayForecast = vehicule.DelayForecast
            });
        }
        //renvoie le nombre de retard ainsi que la date en fonction du numero definissant le type de vehicule
        public IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(int vehiculeType/*, string timeChange*/)
        {
            return _trackingVehiculeRepository.GetInfoForTable(vehiculeType/*,timeChange*/);
        }
        //renvoie toutes les infos nécessaires a propos de la ligne la plus en retards
        public DtoQueryMostDelay GetInfoForMostDelay(int vehiculeType)
        {
            return _trackingVehiculeRepository.GetInfoForMostDelay(vehiculeType);
        }
    }
}
