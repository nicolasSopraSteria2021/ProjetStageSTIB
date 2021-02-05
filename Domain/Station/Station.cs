using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Station
{
    /**
    *
    *A Station is define by a Name an identification 
    */
    public class Station : IStation
    {
        public string StationName { get ; set ; }
        public int Id { get ; set ; }
    }
}
