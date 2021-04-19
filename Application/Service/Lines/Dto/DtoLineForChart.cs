using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Lines.Dto
{
    public class DtoLineForChart
    {
        //DTO utilisé comme retour d'une methofe qui renvoie le nombre de retard,le nombre d'arret ainsi que le numéro de la ligne 
        public int NumberOfDelay { get; set; }
        public int LineNumber { get; set; }
        public int CountStopName { get; set; }

        public DtoLineForChart()
        {

        }

        public DtoLineForChart(int numberOfDelay,int lineNumber,int countStopName)
        {
            NumberOfDelay = numberOfDelay;
            LineNumber = lineNumber;
            CountStopName = countStopName;
        }
       
    }
}
