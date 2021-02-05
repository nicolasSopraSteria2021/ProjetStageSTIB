using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Stations
{
    public interface IStationService
    {
        IEnumerable<DtoStationQuery> GetStation();
    }
}
