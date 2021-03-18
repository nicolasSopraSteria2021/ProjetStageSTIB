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

        public IEnumerable<DtoLineForLinearChart> GetForecastFromLine(int lineNumber)
        {
            return _LineRepository.GetForecastFromLine(lineNumber);
        }

        public IEnumerable<DtoLineForChart> getLineForCharts(int vehiculeType)
        {
            return _LineRepository.GetLineForChart(vehiculeType).Select(line => new DtoLineForChart
            {
                LineNumber = line.LineNumber,
                NumberOfDelay = line.Id

            });
        }

        public IEnumerable<int> getNumberLineByCategory(int vehiculeType)
        {
            return _LineRepository.GetNumberOfLine(vehiculeType);
        }


    }
}
