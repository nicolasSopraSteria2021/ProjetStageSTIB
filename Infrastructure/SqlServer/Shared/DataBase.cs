using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Shared
{
    public static class DataBase
    {
        private const string ConnectionString = @"Server=swaznldigilab01\SQLEXPRESS;Database=fake_Db_STIB;Integrated Security=SSPI";

        //Method allows to connect DB
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

    }
}
