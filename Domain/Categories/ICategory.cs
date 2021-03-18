using ProjetStageSTIB.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Categories
{
   
 public interface ICategory : IEntity
    {
        //category du vehicule
        string vehiculeType { get; set; }

    }
}
