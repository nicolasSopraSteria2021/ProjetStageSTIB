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
        //appel de la classe repository, on pourra avoir accès a toutes les méthodes du repo
        private readonly ICategoryRepository _categoryRepository;
        
        /**
         * Singleton du Repository
         * 
         * */
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //On renvoie une liste de DtoCategory 
        public IEnumerable<DtoCategoryQuery> GetCategory()
        {
            return _categoryRepository.GetAllCategory().Select(category => new DtoCategoryQuery
            {
                Id = category.Id,
                Vehicule_type = category.vehiculeType
            });
        }
    }
}
