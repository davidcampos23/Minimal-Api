using Microsoft.EntityFrameworkCore;
using CadastrosApi.Models;

namespace CadastrosApi.Data 
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString:"Data Source=Logons.sqlite");

            base.OnConfiguring(optionsBuilder);
        }
    }
}