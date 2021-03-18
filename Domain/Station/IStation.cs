using ProjetStageSTIB.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Station
{
   public interface IStation : IEntity
    {
        
        string StationName { get; set; }

    }
}
