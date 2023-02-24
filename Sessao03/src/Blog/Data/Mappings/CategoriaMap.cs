using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class CategoriaMap : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        // Tabela
        builder.ToTable("Categoria");

        // Chave Primária
        builder.HasKey(x => x.Id);

        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        // Propriedades
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Slug)
            .IsRequired()
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        // Índices
        builder
            .HasIndex(x => x.Slug, "IX_Categoria_Slug")
            .IsUnique();
    }
}