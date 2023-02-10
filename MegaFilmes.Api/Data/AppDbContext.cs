using MegaFilmes.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Api.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<Filme> Filmes { get; set; }
	public DbSet<Avaliacao> Avaliacoes { get; set; }
	public DbSet<Ator> Atores { get; set; }
	public DbSet<FilmesAtores> FilmesAtores { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
