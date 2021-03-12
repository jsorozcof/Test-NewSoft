using Microsoft.EntityFrameworkCore;

namespace ConfeccionesCondor.Models
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        { }

        public DbSet<EmpleadoModel> Empleado { get; set; }
        public DbSet<AreaModel> Area { get; set; }


   
    }
}
