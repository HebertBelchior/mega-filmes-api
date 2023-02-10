using MegaFilmes.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MegaFilmes.Api.Data.Maps;

public class FilmeMap : IEntityTypeConfiguration<Filme>
{
    public void Configure(EntityTypeBuilder<Filme> builder)
    {
        builder.ToTable("filmes");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn()
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("descricao")
            .IsRequired();

        builder.Property(x => x.Ano)
            .HasColumnName("ano")
            .IsRequired();

        builder.Property(x => x.Diretor)
            .HasColumnName("diretor")
            .IsRequired();

        builder.Property(x => x.Genero)
            .HasColumnName("genero")
            .IsRequired();
    }
}
