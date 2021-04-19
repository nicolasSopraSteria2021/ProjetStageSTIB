using ProjetStageSTIB.Application.Service.Lines.Dto;
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


    }

}
