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


        //recupère le tems de retard en seconde pour chaque type de vehicule en fonction de la date (TRAM/BUS/METRO)
        int GetTimeDelayByBus(string DateObserstart);
        int GetTimeDelayByTram(string DateObserstart);
        int GetTimeDelayByMetro(string DateObserstart);


        //récupère les infos des moyens de transport avec beaucoup de retard
        IEnumerable<ITrackingVehicule> GetInfoForWarning();

        //recupere la date et le nombre de retard en fonction du type de vehicule
         IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(int vehiculeType/*, string timeChange*/);

        //recupere les infos pour la ligne la plus en retards 
         DtoQueryMostDelay GetInfoForMostDelay(int vehiculeType);
    }
}
