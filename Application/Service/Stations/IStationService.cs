using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Stations
{
    //C'est ici que l'on va definir les methodes de service que l'on va implementer et redefinir dans  la classe concrete Services

    public interface IStationService
    {
        IEnumerable<DtoStationQuery> GetStation();
    }
}
