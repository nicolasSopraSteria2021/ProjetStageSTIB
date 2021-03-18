using ProjetStageSTIB.Domain.Line;
using ProjetStageSTIB.Domain.Station;
using ProjetStageSTIB.Infrastructure.SqlServer.Lines;
using ProjetStageSTIB.Infrastructure.SqlServer.Stations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Factories
{
    public class LineFactory : IInstanceFromReaderFactory<ILine>
    {
        public ILine CreateFromReader(SqlDataReader reader)
        {
            return new LineModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("countDelay")),
                LineNumber = reader.GetInt32(reader.GetOrdinal(LineServer.ColLineNumber))
            };
        }
    }
}
