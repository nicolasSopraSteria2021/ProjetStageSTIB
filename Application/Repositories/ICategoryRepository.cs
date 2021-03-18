using ProjetStageSTIB.Application.Service;
using ProjetStageSTIB.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Repositories
{
    //C'est ici que l'on va definir les methodes que l'on va implementer et redefinir dans  la classe concrete CategoryRepository
    public interface ICategoryRepository
    {
       //permet d'avoir toutes les categories qui existent dans la DB
        IEnumerable<ICategory> GetAllCategory();
        //recupere une categorie via son ID
        ICategory GetById(int Id);
    }
}
