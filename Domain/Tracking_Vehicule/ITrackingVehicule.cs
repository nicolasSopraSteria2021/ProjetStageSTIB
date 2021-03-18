using ProjetStageSTIB.Domain.Shared;
using ProjetStageSTIB.Domain.Vehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Tracking_Vehicule
{
    public interface ITrackingVehicule : IEntity
    {

        VehiculeModel ID_Vehicule { get; set; }

        DateTime DateObservation { get; set; }

        string DelayMin { get; set; }

        string DelayForecast { get; set; }


    }
}