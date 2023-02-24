using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        // Tabela
        builder.ToTable("Post");

        // Chave Primária
        builder.HasKey(x => x.Id);

        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        // Propriedades
        builder.Property(x => x.DataUltimaModificacao)
            .IsRequired()
            .HasColumnName("DataUltimaModificacao")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60)
            .HasDefaultValueSql("GETDATE()");

        // Índices
        builder
            .HasIndex(x => x.Slug, "IX_Post_Slug")
            .IsUnique();

        // Relacionamentos
        builder
            .HasOne(x => x.Autor)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_Autor")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Categoria)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_Categoria")
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamentos
        builder
            .HasMany(x => x.Tags)
            .WithMany(x => x.Posts)
            .UsingEntity<Dictionary<string, object>>(
                "PostTag",
                post => post
                    .HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("PostId")
                    .HasConstraintName("FK_PostPapel_PostId")
                    .OnDelete(DeleteBehavior.Cascade),
                tag => tag
                    .HasOne<Post>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .HasConstraintName("FK_PostTag_TagId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}