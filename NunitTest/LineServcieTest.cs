using NSubstitute;
using NUnit.Framework;
using ProjetStageSTIB.Application.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.NunitTest
{
    [TestFixture]
    public class LineServcieTest
    {
        private readonly ILineRepository _LineRepository = Substitute.For<ILineRepository>();


        [Test]
        public void GetMonthFromDb()
        {
            bool res;
            IEnumerable<string> monthList = _LineRepository.GetMonthFromDb();
            IEnumerable month = "Jan 2021";

            if (monthList.Contains(month))
            {
                 res = true;
            }
            else
            {
                res = false;   
            }
        
            Assert.IsTrue(res);
        }
    }
}
