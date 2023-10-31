using InkWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace InkWorks.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           

            modelBuilder.Entity<Trabalho>()
                .HasOne(t => t.Cliente)
                .WithMany(c => c.Trabalhos)
                .HasForeignKey(t => t.ClienteId);

            modelBuilder.Entity<Mensagem>()
                .HasOne(m => m.Cliente)
                .WithMany(c => c.Mensagens)
                .HasForeignKey(m => m.ClienteId);

            modelBuilder.Entity<Imagem>()
                .HasOne(i => i.Trabalho)
                .WithMany(t => t.Imagens)
                .HasForeignKey(i => i.TrabalhoId);
        }
    }
}
