using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Lines
{
    public interface ILineService
    {
        //renvoie la méthode GetLineForChart du repository
        IEnumerable<DtoLineForChart> getLineForCharts(string vehiculeType, string value);

        //renvoie les numeros de lignes par category
        public IEnumerable<int> getNumberLineByCategory(string vehiculeType);

        //renvoie les données de retards pour le graphique
        public IEnumerable<DtoDelayByHourBarChart> GetDelayByHourBarChart(int lineNumber, string vehiculeType, string monthNumber);

        public IEnumerable<string> GetMonthFromDb();

        public IEnumerable<int> GetYearsFromDb();
        public DtoDetailsWeather getDetailsFromDate(string vehiculeType,string dateValue);

        // recupere le nombre de retard de chaque vehicule 
        int GetCountBusTrackingVehicule(string dateObser);
        int GetCountTramTrackingVehicule(string dateObser);
   
        //recupere le nombre de vehicule non en retard 
        int GetCountBusNotDelay(string dateObser);
        int GetCountTramNotDelay(string dateObser);
        IEnumerable<DtoSpecificTableDateObservation> GetDayByMonth(string vehiculeType, int value, string monthValue);
        //recupere la date et le nombre de retard en fonction du type de données
        IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(string vehiculeType, string value);

        //recupere les infos de la ligne la plus en retard
        DtoQueryMostDelay GetInfoForMostDelay(string vehiculeType, string value);
    }
}
