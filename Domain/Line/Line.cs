using ProjetStageSTIB.Domain.Shared;
using ProjetStageSTIB.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Line
{
    public class Line : ILine
    {
        public int LineNumber { get ; set ; }
        public IStation StationDeparture { get ; set ; }
        public IStation StationArrival { get ; set ; }
        public DateTime HourDeparture { get ; set ; }
        public DateTime HourArrival { get ; set ; }
        public int Id { get ; set ; }
    }
}
