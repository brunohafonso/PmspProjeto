using Microsoft.EntityFrameworkCore;
using PmspProjeto.Models;

namespace PmspProjeto.Repositorio
{
    public class PmspContext : DbContext 
    {
        public PmspContext(DbContextOptions options) : base(options) { }

        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servidor>().ToTable("Servidores");
            modelBuilder.Entity<Endereco>().ToTable("Enderecos");
        }
    }
}