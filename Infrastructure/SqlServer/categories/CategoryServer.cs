using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer
{
    public class CategoryServer
    {
        public static readonly string TableName ="category";
        public static readonly string ColId ="idCat";
        public static readonly string ColType ="vehicule_type";

        public static readonly string reqGetObjet = $" SELECT * FROM {TableName}";
        public static readonly string reqGetObjetById = reqGetObjet+$" WHERE {ColId} = @{ColId}";


    }
}
