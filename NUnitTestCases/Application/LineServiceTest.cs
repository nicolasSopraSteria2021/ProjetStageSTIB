using NSubstitute;
using NUnit.Framework;
using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service.Lines;
using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Domain.NewLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.NUnitTestCases.Application
{
    [TestFixture]
    public class LineServiceTest
    {
        private static ILineRepository _lineRepository = Substitute.For<ILineRepository>();
        private ILineService _lineService = new LineService(_lineRepository);

        private static IEnumerable<DtoLineForChart> getDtoLineForChart()
        {
            DtoLineForChart[] dtoLineForChart = { new DtoLineForChart(47294,13,21)};
            IEnumerable<DtoLineForChart> list = dtoLineForChart;
            return list;
        }

        //Methode GetLineForChart de lineService renvoie ,-le numero des lignes ainsi que le nombre de retard respectif
        [Test]
        [TestCase("Bus","2021")]
       public void GetLineForCharts_AreSame(string vehiculeType, string value)
        {
            _lineRepository.GetLineForChart(vehiculeType, value).Returns(getDtoLineForChart());
            IEnumerable<DtoLineForChart> res = _lineService.getLineForCharts("Bus", "2021");
            DtoLineForChart dtoLineForChart =  new DtoLineForChart(47294, 13, 21) ;
         
                Assert.IsTrue(res.Contains(dtoLineForChart));
         
        }

        


    }
}
