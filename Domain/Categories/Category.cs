using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Categories
{   
    /**
     * Une category est defini par une type de vehicule et un Id
     */
     public class Category : ICategory
    {
        public string vehiculeType { get ; set ; }
        public int Id { get ; set ; }
    }
}
