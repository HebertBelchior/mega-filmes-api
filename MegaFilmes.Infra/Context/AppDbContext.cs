using MegaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Ator> Atores { get; set; }
    public DbSet<FilmeAtor> FilmesAtores { get; set; }
    public DbSet<Genero> Generos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
