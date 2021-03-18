using Microsoft.EntityFrameworkCore;
using ProjetStageSTIB.Domain.Categories;
using ProjetStageSTIB.Domain.Line;
using ProjetStageSTIB.Domain.Vehicules;
using ProjetStageSTIB.Domain.Vehicules.Dto;
using ProjetStageSTIB.Infrastructure.SqlServer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.Infrastructure.SqlServer.TrackingVehicules
{
    public class TrackingVehiculeContext : DbContext
    {
        public DbSet<VehiculeModel> vehicules { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=ITEM-S37587\SQLEXPRESS;Database=fake_Db_STIB;Integrated Security=SSPI"
            );
        }





    }
}
