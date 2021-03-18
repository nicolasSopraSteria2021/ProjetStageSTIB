using ProjetStageSTIB.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Repositories
{
    //C'est ici que l'on va definir les methodes que l'on va implementer et redefinir dans  la classe concrete StationRepository
    public interface IStationRepository
    {
        //permet d'avoir toutes les stations qui existent dans la DB
        IEnumerable<IStation> GetAllStation();
        IStation GetById(int Id);
    }
}
