using ProjetStageSTIB.Application.Service.Lines.Dto;
using ProjetStageSTIB.Domain.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Repositories
{
    //C'est ici que l'on va definir les methodes que l'on va implementer et redefinir dans  la classe concrete LineRepository
   public interface ILineRepository

    {   //recupere toutes les lignes de la db
        IEnumerable<ILine> GetAllLine();
        //recupere la ligne la plus en retards ainsi que son nombre de retards
        IEnumerable<ILine> GetLineForChart(int vehiculeType);
        //recupere toutes les lignes en fonction du type de vehicule
        IEnumerable<int> GetNumberOfLine(int vehiculeType);

        //renvoie les données de retard pour le graphiques
        IEnumerable<DtoLineForLinearChart> GetForecastFromLine(int lineNumber);
    }
}
