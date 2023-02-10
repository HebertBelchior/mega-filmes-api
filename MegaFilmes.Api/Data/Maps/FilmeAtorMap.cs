using MegaFilmes.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Api.Data.Maps;

public class FilmeAtorMap : IEntityTypeConfiguration<FilmeAtor>
{
    public void Configure(EntityTypeBuilder<FilmeAtor> builder)
    {
        builder.ToTable("filmes_atores");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn()
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.FilmeId)
            .HasColumnName("filme_id")
            .IsRequired();

        builder.Property(x => x.AtorId)
            .HasColumnName("ator_id")
            .IsRequired();

        builder.Property(x => x.Papel)
            .HasColumnName("papel")
            .IsRequired();
    }
}