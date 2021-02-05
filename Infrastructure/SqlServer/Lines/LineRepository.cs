using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Domain.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Lines
{
    public class LineRepository : ILineRepository
    {
        public IEnumerable<ILine> GetAllLine()
        {
            return null;
        }
    }
}
