using ProjetStageSTIB.Domain.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Repositories
{
   public interface ILineRepository
    {
        IEnumerable<ILine> GetAllLine();
    }
}
