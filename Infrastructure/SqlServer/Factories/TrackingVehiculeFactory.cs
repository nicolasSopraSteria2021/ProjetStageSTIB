using ProjetStageSTIB.Domain.Line;
using ProjetStageSTIB.Domain.Station;
using ProjetStageSTIB.Domain.Tracking_Vehicule;
using ProjetStageSTIB.Domain.Vehicules;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using ProjetStageSTIB.Infrastructure.SqlServer.Stations;
using ProjetStageSTIB.Infrastructure.SqlServer.TrackingVehicules;
using ProjetStageSTIB.Infrastructure.SqlServer.Vehicule;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Factories
{
    public class TrackingVehiculeFactory : IInstanceFromReaderFactory<ITrackingVehicule>
    {
        public ITrackingVehicule CreateFromReader(SqlDataReader reader)
        {
            return new TrackingVehicule
            {
                DelayForecast = reader.GetString(reader.GetOrdinal("delay_forecast")),

                ID_Vehicule = new VehiculeModel
                {
                    Line = new LineModel
                    {

                        LineNumber = reader.GetInt32(reader.GetOrdinal(LineServer.ColLineNumber)),
                        HourArrival = reader.GetDateTime(reader.GetOrdinal(LineServer.colHourArrival)),
                        HourDeparture = reader.GetDateTime(reader.GetOrdinal(LineServer.ColHourDeparture)),

                        StationArrival = new Station
                        {
                            StationName = reader.GetString(reader.GetOrdinal(StationServer.ColStationName))
                        },

                        StationDeparture = new Station
                        {
                            StationName = reader.GetString(reader.GetOrdinal("stationDeparture"))
                        },
                        
                    },
                  
                },
                    };
            }
        }
    }
    

