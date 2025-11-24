using Microsoft.EntityFrameworkCore;
using ReelView.Core.Models; // CONFIRA: Se a pasta no Core for "Entities", mude para .Entities

namespace ReelView.Infrastructure.Data // CORREÇÃO: Namespace correto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Midia> Midias { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        // Mudei para "Favoritos" para bater com o padrão do Repositório
        public DbSet<UsuarioFavorito> Favoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================================
            // TPH - Herança (Filme / Serie)
            // ================================
            modelBuilder.Entity<Midia>()
                .HasDiscriminator<string>("Tipo")
                .HasValue<Filme>("Filme")
                .HasValue<Serie>("Serie");

            // Propriedade calculada não deve ser mapeada
            modelBuilder.Entity<Midia>()
                .Ignore(m => m.NotaMedia);

            // ================================
            // Relacionamento: Avaliação → Usuário
            // ================================
            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================================
            // Relacionamento: Avaliação → Mídia
            // ================================
            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Midia)
                .WithMany(m => m.Avaliacoes)
                .HasForeignKey(a => a.MidiaId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================================
            // RELAÇÃO MANY-TO-MANY: UsuarioFavorito
            // ================================
            modelBuilder.Entity<UsuarioFavorito>()
                .HasKey(uf => new { uf.UsuarioId, uf.MidiaId });

            modelBuilder.Entity<UsuarioFavorito>()
                .HasOne(uf => uf.Usuario)
                .WithMany(u => u.Favoritos)
                .HasForeignKey(uf => uf.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsuarioFavorito>()
                .HasOne(uf => uf.Midia)
                .WithMany()
                .HasForeignKey(uf => uf.MidiaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}