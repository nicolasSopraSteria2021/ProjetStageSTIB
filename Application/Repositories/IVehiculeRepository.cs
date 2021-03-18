using ProjetStageSTIB.Domain.Vehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Repositories
{

    //C'est ici que l'on va definir les methodes que l'on va implementer et redefinir dans  la classe concrete VehiculeRepository
    public interface IVehiculeRepository
    {
        //permet d'avoir tous les vehicules qui existent dans la DB
        IEnumerable<IVehicule> GetAll();
    }
}
