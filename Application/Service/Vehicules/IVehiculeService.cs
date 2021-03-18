using ProjetStageSTIB.Domain.Vehicules;
using ProjetStageSTIB.Domain.Vehicules.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Vehicules
{

    //C'est ici que l'on va definir les methodes de service que l'on va implementer et redefinir dans  la classe concrete Services
    public interface IVehiculeService
    {

        //Renvoie tous les vehicules du jour 
        IEnumerable<DtoQueryVehicule> GetVehicule();
    }
}
