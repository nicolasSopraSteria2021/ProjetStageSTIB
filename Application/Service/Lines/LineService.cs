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
        //appel des repo 
        private readonly ILineRepository _LineRepository;


        public LineService(ILineRepository lineRepository)
        {
            _LineRepository = lineRepository;

        }

        public DtoDetailsWeather getDetailsFromDate(string vehiculeType,string value)
        {
            return _LineRepository.getDetailsFromDate(vehiculeType,value);
        }

        public IEnumerable<DtoDelayByHourBarChart> GetForecastFromLine(int lineNumber, string vehiculeType, string monthNumber)
        {
            return _LineRepository.getDelayByHourBarChart(lineNumber,vehiculeType,monthNumber);
        }

        public IEnumerable<DtoLineForChart> getLineForCharts(string vehiculeType,string value)
        {
            return _LineRepository.GetLineForChart(vehiculeType,value);
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
