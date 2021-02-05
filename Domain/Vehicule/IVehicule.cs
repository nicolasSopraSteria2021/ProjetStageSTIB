using ProjetStageSTIB.Domain.Categories;
using ProjetStageSTIB.Domain.Line;
using ProjetStageSTIB.Domain.Shared;
using ProjetStageSTIB.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Vehicule
{
  public  interface IVehicule : IEntity
    {
        
        ILine Line { get; set; }

        ICategory Category { get; set; }

        double Delay_min { get; set; }
        double Delay_forecast { get; set; }
    }
}
