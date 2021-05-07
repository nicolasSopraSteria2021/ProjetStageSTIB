using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Application.Service.TrackingVehicules.Dto;
using ProjetStageSTIB.Domain.NewLine;
using System.Collections.Generic;

namespace ProjetStageSTIB.Application.Repositories
{
    //C'est ici que l'on va definir les methodes que l'on va implementer et redefinir dans  la classe concrete LineRepository
    public interface ILineRepository

    {   
        //recupere la ligne la plus en retards ainsi que son nombre de retards
        IEnumerable<DtoLineForChart> GetLineForChart(string vehiculeType, string value);
        //recupere toutes les lignes en fonction du type de vehicule
        IEnumerable<int> GetNumberOfLine(string vehiculeType);

        //renvoie les données de retard pour le graphiques
        IEnumerable<DtoDelayByHourBarChart> getDelayByHourBarChart(int lineNumber, string vehiculeType, string monthNumber);

         IEnumerable<int> GetYearsFromDb();
         IEnumerable<string> GetMonthFromDb();

        DtoDetailsWeather getDetailsFromDate(string vehiculeType,string value);

        //recupere le nombre de vehicule en retard pour chaque type de vehicule en fonction de la date (TRAM/BUS/METRO)
        int GetCountDelayBus(string dateObser);

        int GetCountDelayTram(string dateObser);


        //recupere le nombre de vehicule en Non en retard pour chaque type de vehicule en fonction de la date (TRAM/BUS/METRO)
        int GetCountNotDelayBus(string dateObser);

        int GetCountNotDelayTram(string dateObser);

        //recupere les jours et les retards d'un mois 
        IEnumerable<DtoSpecificTableDateObservation> GetDayByMonth(string vehiculeType, int value, string monthValue);


        //recupere la date et le nombre de retard en fonction du type de vehicule
        IEnumerable<DtoSpecificTableDateObservation> GetInfoForTable(string vehiculeType, string value);

        //recupere les infos pour la ligne la plus en retards 
        DtoQueryMostDelay GetInfoForMostDelay(string vehiculeType, string value);
    }

}
