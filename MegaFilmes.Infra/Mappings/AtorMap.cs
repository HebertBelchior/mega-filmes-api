using MegaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Infra.Mappings;

public class AtorMap : IEntityTypeConfiguration<Ator>
{
    public void Configure(EntityTypeBuilder<Ator> builder)
    {
        builder.ToTable("atores");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn()
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasColumnName("nome")
            .IsRequired();
    }
}