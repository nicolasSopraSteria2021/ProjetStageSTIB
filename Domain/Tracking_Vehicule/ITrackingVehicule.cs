using ProjetStageSTIB.Domain.Shared;
using System;

namespace ProjetStageSTIB.Domain.Tracking_Vehicule
{
    public interface ITrackingVehicule : IEntity
    {

     

        DateTime DateObservation { get; set; }

        string DelayMin { get; set; }

        string DelayForecast { get; set; }


    }
}