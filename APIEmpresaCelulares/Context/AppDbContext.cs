using APIEmpresaCelulares.Model;
using Microsoft.EntityFrameworkCore;

namespace APIEmpresaCelulares.Context
{
    public class AppDbContext : DbContext
        
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
    }
}
