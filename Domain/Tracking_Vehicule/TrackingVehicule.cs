using ProjetStageSTIB.Domain.Vehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Tracking_Vehicule
{
  //un trackingVehicule est composé d'un objet vehicule, d'une date d'observation ( qui va nous permettre de classer a un instant T ), le nombre de minute de retard reel et predit
    public class TrackingVehicule : ITrackingVehicule
    {
        public VehiculeModel ID_Vehicule { get; set; }
        public DateTime DateObservation { get; set; }
        public string DelayMin { get; set; }
        public string DelayForecast { get; set; }
        public int Id { get; set; }
    }
}
