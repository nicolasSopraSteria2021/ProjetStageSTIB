using Microsoft.EntityFrameworkCore;

namespace ProjetStageSTIB.Infrastructure.SqlServer.TrackingVehicules
{
    public class TrackingVehiculeContext : DbContext
    {
      

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=ITEM-S37587\SQLEXPRESS;Database=fake_Db_STIB;Integrated Security=SSPI"
            );
        }





    }
}
