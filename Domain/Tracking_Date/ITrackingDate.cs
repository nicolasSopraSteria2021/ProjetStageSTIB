using ProjetStageSTIB.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Tracking_Date
{
    interface ITrackingDate : IEntity
    {
        DateTime Date { get; set; }
    }
}
