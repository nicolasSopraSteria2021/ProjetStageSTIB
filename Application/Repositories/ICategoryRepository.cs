using ProjetStageSTIB.Application.Service;
using ProjetStageSTIB.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<ICategory> GetAllCategory();
        ICategory GetById(int Id);
    }
}
