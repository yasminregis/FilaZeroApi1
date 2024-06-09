using FilaZeroApi.models;
using Microsoft.EntityFrameworkCore;
namespace FilaZeroApi.Data
{
    public class FilaZeroDBContext: DbContext
    {
        public DbSet<Agencia> Agencias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite("Data Source=mydatabase.db");//cache compartilhado;?
        
    }
}
