using ProjetStageSTIB.Application.Service.Lines.Dto;
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
        public IEnumerable<DtoDelayByHourBarChart> GetForecastFromLine(int lineNumber, string vehiculeType, string monthNumber);

        public IEnumerable<string> GetMonthFromDb();

        public IEnumerable<int> GetYearsFromDb();
        public DtoDetailsWeather getDetailsFromDate(string vehiculeType,string dateValue);
    }
}
