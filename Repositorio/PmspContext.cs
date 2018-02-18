using Microsoft.EntityFrameworkCore;
using PmspProjeto.Models;

namespace PmspProjeto.Repositorio
{
    public class PmspContext : DbContext 
    {
        public PmspContext(DbContextOptions options) : base(options) { }

        public DbSet<Servidor> Servidores { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servidor>().ToTable("Servidores");
        }
    }
}