using ProjetStageSTIB.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service
{
    //C'est ici que l'on va definir les methodes de service que l'on va implementer et redefinir dans  la classe concrete Services
    public interface ICategoryService
    {
        /**
         * DtoCategoryQuery : classe creer qui comporte les éléments important de catégorie
         * 
         */
        IEnumerable<DtoCategoryQuery> GetCategory();

    }
}
