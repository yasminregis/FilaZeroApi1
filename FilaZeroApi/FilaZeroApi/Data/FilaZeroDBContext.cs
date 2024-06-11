using FilaZeroApi.models;
using Microsoft.EntityFrameworkCore;
namespace FilaZeroApi.Data
{
    public class FilaZeroDBContext: DbContext
    {
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<AgenciaCapacidade> agenciasCapacidade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        
    }
}
