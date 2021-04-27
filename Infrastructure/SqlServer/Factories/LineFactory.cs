using ProjetStageSTIB.Domain.NewLine;
using ProjetStageSTIB.Domain.Tracking_Vehicule;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using System.Data.SqlClient;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Factories
{
    public class LineFactory : IInstanceFromReaderFactory<INewLine>
    {
        public INewLine CreateFromReader(SqlDataReader reader)
        {
            return new Line
            {
                   id = reader.GetInt32(reader.GetOrdinal(LineServer.ColId)),
                  date_observation = reader.GetString(reader.GetOrdinal(LineServer.ColDateOb)),
                delays = reader.GetInt32(reader.GetOrdinal(LineServer.ColDelays)),
                trip_headsign = reader.GetString(reader.GetOrdinal(LineServer.Coltrip)),
                stop_name = reader.GetString(reader.GetOrdinal(LineServer.colStopName)),
                lineNumber = reader.GetInt32(reader.GetOrdinal(LineServer.ColLineNumber)),
                vehiculeType = reader.GetString(reader.GetOrdinal(LineServer.colvehiculeType)),
                precip1Hour = reader.GetDouble(reader.GetOrdinal(LineServer.ColPrec)),
                precip24Hour = reader.GetDouble(reader.GetOrdinal(LineServer.ColPrec)),
                precip6Hour = reader.GetDouble(reader.GetOrdinal(LineServer.ColPrec)),
                relativeHumidity = reader.GetDouble(reader.GetOrdinal(LineServer.colHumidity)),
                snow1Hour = reader.GetDouble(reader.GetOrdinal(LineServer.ColSnow)),
                snow24Hour = reader.GetDouble(reader.GetOrdinal(LineServer.ColSnow)),
                snow6Hour = reader.GetDouble(reader.GetOrdinal(LineServer.ColSnow6)),
                temperature = reader.GetDouble(reader.GetOrdinal(LineServer.ColTemp)),
                temperatureDewPo = reader.GetDouble(reader.GetOrdinal(LineServer.colTempDewPo)),
                temperatureFeelsLike = reader.GetDouble(reader.GetOrdinal(LineServer.colTempFeels)),
                temperatureMax24Hour = reader.GetDouble(reader.GetOrdinal(LineServer.colTempMax)),
                temperatureMin24Hour = reader.GetDouble(reader.GetOrdinal(LineServer.colTempMin)),
                uvIndex = reader.GetDouble(reader.GetOrdinal(LineServer.colUv)),
                visibility = reader.GetDouble(reader.GetOrdinal(LineServer.ColVis)),
                windSpeed = reader.GetDouble(reader.GetOrdinal(LineServer.ColWind)),
                prediction = reader.GetInt32(reader.GetOrdinal(LineServer.ColPrediction))
                };
            }
        }
    }
    

