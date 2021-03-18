using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Application.Service.TrackingVehicules.Dto
{
    //renvoie la date et le nombre de retard
    public class DtoSpecificTableDateObservation
    {
        public  int count { get; set; }
        public string dateObservation { get; set; }
    }
}
