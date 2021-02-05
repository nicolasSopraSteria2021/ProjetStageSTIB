using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Domain.Tracking_Date
{
    public class TrackingDate : ITrackingDate
    {
        public DateTime Date { get ; set ; }
        public int Id { get ; set ; }
    }
}
