using ProjetStageSTIB.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service
{
   public interface ICategoryService
    {
        IEnumerable<DtoCategoryQuery> GetCategory();

    }
}
