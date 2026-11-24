using Microsoft.EntityFrameworkCore;
using ProjetoAutenticacaoBasica.Api.models;

namespace ProjetoAutenticacaoBasica.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Voo> Voos { get; set; }
        public DbSet<Passagem> Passagens { get; set; }

    }
}
