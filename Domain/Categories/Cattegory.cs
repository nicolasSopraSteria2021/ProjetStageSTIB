using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Categories
{   
    /**
     * A category define a vehicule like a Tram , Bus or Metro
     */
     public class Cattegory : ICategory
    {
        public string Vehicule_type { get ; set ; }
        public int Id { get ; set ; }
    }
}
