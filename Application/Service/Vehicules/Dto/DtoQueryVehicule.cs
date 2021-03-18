using ProjetStageSTIB.Domain.Categories;
using ProjetStageSTIB.Domain.Line;
using ProjetStageSTIB.Domain.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Vehicules.Dto
{
    //le dto des vehicules pour le tableau
    public class DtoQueryVehicule
    {
        public string stationArrival { get; set; }
        public string stationDeparture { get; set; }
        public string category { get; set; }

        public int id { get; set; }

        public int lineNumber { get; set; }

        public DateTime hourArrival { get; set; }

        public DateTime  hourDeparture { get; set; }

}




}
