using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace ProjetStageSTIB.Infrastructure.SqlServer.Factories
{
    interface IInstanceFromReaderFactory<out T> {
        //createFromReader will create an objet with the sql request
        T CreateFromReader(SqlDataReader reader);
    }
}
