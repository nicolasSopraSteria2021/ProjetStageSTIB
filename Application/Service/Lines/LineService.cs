using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Lines
{
    public class LineService : ILineService
    {
        //declaration du repository
        private readonly ILineRepository _LineRepository;

        //constructeur permettant d'initialiser le repositories
        public LineService(ILineRepository lineRepository)
        {
            _LineRepository = lineRepository;

        }

        public DtoDetailsWeather getDetailsFromDate(string vehiculeType,string value)
        {
            return _LineRepository.getDetailsFromDate(vehiculeType,value);
        }


      
        ///<param name="lineNumber">attribut de type int : permet d'identifier le numéro de ligne </param> 
        /// <param name="vehiculeType">attribut de type string, exemple Bus</param> 
        /// <param name="monthNumber">attribut de type string, exemple Feb 2021</param> 
        /// <returns>retourne une liste de DtoDelayByHourBarChart </returns> 
       public IEnumerable<DtoDelayByHourBarChart> GetDelayByHourBarChart(int lineNumber, string vehiculeType, string monthNumber)
        {
            return _LineRepository.getDelayByHourBarChart(lineNumber,vehiculeType,monthNumber);
        }

        public IEnumerable<DtoLineForChart> getLineForCharts(string vehiculeType, string value)
        {
            return _LineRepository.GetLineForChart(vehiculeType, value);
        }

        public IEnumerable<string> GetMonthFromDb()
        {
            return _LineRepository.GetMonthFromDb();
        }

        public IEnumerable<int> getNumberLineByCategory(string vehiculeType)
        {
            return _LineRepository.GetNumberOfLine(vehiculeType);
        }

        public IEnumerable<int> GetYearsFromDb()
        {
            return _LineRepository.GetYearsFromDb();
        }
    }
}
