using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.Lines.Dto
{
    public class DtoLineForChart
    {
        //DTO utilisé comme retour d'une methofe qui renvoie le nombre de retard,le nombre d'arret ainsi que le numéro de la ligne 
        public int delays { get; set; }
        public int LineNumber { get; set; }
        public int CountStopName { get; set; }

        public DtoLineForChart()
        {

        }

        public DtoLineForChart(int numberOfDelay,int lineNumber,int countStopName)
        {
            if(delays>=0)
                delays = numberOfDelay;
            if (LineNumber >0)
                LineNumber = lineNumber;
            if (CountStopName>0)
                CountStopName = countStopName;
        }

        public override bool Equals(object obj)
        {
            return obj is DtoLineForChart chart &&
                   delays == chart.delays &&
                   LineNumber == chart.LineNumber &&
                   CountStopName == chart.CountStopName;
        }


    }
}
