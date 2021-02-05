
using ProjetStageSTIB.Domain.Categories;
using ProjetStageSTIB.Domain.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Vehicule
{
    /**
    *
    * A vehicule is define by 
    *    a line that is the reference for class Line 
    *   a category is the reference for class category
    *   a delay_min is the time of delay 
    *   a delay_forecast is the time of delay by IA
    *   an Id is the number of identification for a vehicule
    */
    public class Vehicule : IVehicule
    {
        public ILine Line { get ; set ; }
        public ICategory Category { get ; set ; }
        public double Delay_min { get ; set ; }
        public double Delay_forecast { get ; set ; }
        public int Id { get ; set ; }
    }
}
