using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Infrastructure.SqlServer.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service
{
    public class CategoryService : ICategoryService
    {
        //appel des repo
        private readonly ICategoryRepository _categoryRepository;
      
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<DtoCategoryQuery> GetCategory()
        {
            return _categoryRepository.GetAllCategory().Select(category => new DtoCategoryQuery
            {
                Id = category.Id,
                Vehicule_type = category.Vehicule_type
            });
        }
    }
}
