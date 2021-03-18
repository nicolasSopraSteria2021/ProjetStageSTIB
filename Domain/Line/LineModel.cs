using ProjetStageSTIB.Domain.Shared;
using ProjetStageSTIB.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Line
{
    /*
     * Une ligne est composé d'un numero de ligne,
     * d'une station de départ et d'arrivé ( Objet Station ) ,
     * d'une Heure de départ et d'arriver 
     * et d'un numéro d'indentification
     */
    public class LineModel : ILine
    {
        public int LineNumber { get ; set ; }
        public IStation StationDeparture { get ; set ; }
        public IStation StationArrival { get ; set ; }
        public DateTime HourDeparture { get ; set ; }
        public DateTime HourArrival { get ; set ; }
        public int Id { get ; set ; }
    }
}
