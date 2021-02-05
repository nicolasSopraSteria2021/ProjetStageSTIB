using ProjetStageSTIB.Application.Repositories;
using ProjetStageSTIB.Application.Service;
using ProjetStageSTIB.Domain.Categories;
using ProjetStageSTIB.Infrastructure.SqlServer.Factories;
using ProjetStageSTIB.Infrastructure.SqlServer.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        //Instance of CategoryFactory
        private readonly IInstanceFromReaderFactory<ICategory> _factory = new CategoryFactory();

        /**
        * return a list of category 
        */
        public IEnumerable<ICategory> GetAllCategory()
        {
            //init a list of category
            IList<ICategory> categories = new List<ICategory>();
            using (var connection = DataBase.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = CategoryServer.reqGetObjet;
                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //until the reader can read in the db 
                while (reader.Read())
                {
                    categories.Add(_factory.CreateFromReader(reader));
                }
            }
            return categories;

        }

        public ICategory GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
