﻿using ProjetStageSTIB.Application.Service.Lines.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Lines
{
    public interface ILineService
    {
        //renvoie la méthode GetLineForChart du repository
        IEnumerable<DtoLineForChart> getLineForCharts(int vehiculeType);

        //renvoie les numeros de lignes par category
        public IEnumerable<int> getNumberLineByCategory(int vehiculeType);

        //renvoie les données de retards pour le graphique
        public IEnumerable<DtoLineForLinearChart> GetForecastFromLine(int lineNumber);
    }
}