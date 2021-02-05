﻿using ProjetStageSTIB.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Factories
{
    public class CategoryFactory : IInstanceFromReaderFactory<ICategory>
    {
        public ICategory CreateFromReader(SqlDataReader reader)
        {
            //return category Object
            return new Cattegory
            {
                Id = reader.GetInt32(reader.GetOrdinal(CategoryServer.ColId)),
                Vehicule_type = reader.GetString(reader.GetOrdinal(CategoryServer.ColType))
            };
        }
    }
}
