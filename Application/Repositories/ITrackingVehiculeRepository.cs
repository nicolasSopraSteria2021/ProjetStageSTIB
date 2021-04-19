using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using ProjetStageSTIB.Domain.Tracking_Vehicule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Repositories
{
    public interface ITrackingVehiculeRepository
    {
        //recupere le nombre de vehicule en retard pour chaque type de vehicule en fonction de la date (TRAM/BUS/METRO)
        int GetCountDelayBus(string dateObser);
     
        int GetCountDelayTram(string dateObser);
        
        int GetCountDelayMetro(string dateObser);

        //recupere le nombre de vehicule en Non en retard pour chaque type de vehicule en fonction de la date (TRAM/BUS/METRO)
        int GetCountNotDelayBus(string dateObser);

        int GetCountNotDelayTram(string dateObser);

        int GetCountNotDelayMetro(string dateObser);

        //recupere les jours et les retards d'un mois 
         IEnumerable<DtoSpecificTableDateObservation> GetDayByMonth(string vehiculeType, string value, string monthValue);


        //recupere la date et le nombre de retard en fonction du type de vehicule
         IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(string vehiculeType,string value);

        //recupere les infos pour la ligne la plus en retards 
         DtoQueryMostDelay GetInfoForMostDelay(string vehiculeType,string value);
    }
}
