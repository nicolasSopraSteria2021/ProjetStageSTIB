using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using ProjetStageSTIB.Domain.Tracking_Vehicule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.TrackingVehicules
{
    public interface ITrackingVehiculeService
    {
        // recupere le nombre de retard de chaque vehicule 
        int GetCountBusTrackingVehicule(string dateObser);
        int GetCountTramTrackingVehicule(string dateObser);
        int GetCountMetroTrackingVehicule(string dateObser);


        //recupere le temps total de retard de chaque vehicule 
        int GetTimeDelayBusTrackingVehicule(string dateObser);
        int GetTimeDelayTramTrackingVehicule(string dateObser);
        int GetTimeDelayMetroTrackingVehicule(string dateObser);


        //recupere le nombre de vehicule non en retard 
        int GetCountBusNotDelay(string dateObser);
        int GetCountTramNotDelay(string dateObser);
        int GetCountMetroNotDelay(string dateObser);

        //recupere les infos de tout les vehicules en retards 
        IEnumerable<DtoWarningQueryTrackingVeh> GetInfoForWarning();

        //recupere la date et le nombre de retard en fonction du type de données
        IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(int vehiculeType/*,string timeChange*/);

        //recupere les infos de la ligne la plus en retard
        DtoQueryMostDelay GetInfoForMostDelay(int vehiculeType);
    }
}
