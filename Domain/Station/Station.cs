using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Station
{

    
    //une station est defini par une numero d'identification et d'un nom de station
    public class Station : IStation
    {
        public string StationName { get ; set ; }
        public int Id { get ; set ; }
    }
}
