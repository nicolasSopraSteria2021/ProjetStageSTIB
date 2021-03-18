using ProjetStageSTIB.Domain.Shared;
using ProjetStageSTIB.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Line
{
   public interface ILine : IEntity
    {
        int LineNumber { get; set; }
        IStation StationDeparture { get; set; }
        IStation StationArrival { get; set; }

        DateTime HourDeparture { get; set; }
        DateTime HourArrival{ get; set; }

        
    }
}
