using ProjetStageSTIB.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Repositories
{
    public interface IStationRepository
    {
        IEnumerable<IStation> GetAllStation();
        IStation GetById(int Id);
    }
}
