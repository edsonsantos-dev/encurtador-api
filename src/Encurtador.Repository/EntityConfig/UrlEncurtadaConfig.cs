using Encurtador.Domain.Entities;
using Encurtador.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encurtador.Repository.EntityConfig;

public class UrlEncurtadaConfig : IEntityTypeConfiguration<UrlEncurtada>
{
    public void Configure(EntityTypeBuilder<UrlEncurtada> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id".ToLower());

        builder.Property(x => x.UrlOriginal)
            .HasColumnName("UrlOriginal".ToLower());

        builder.Property(x => x.CodigoAlfanumerico)
            .HasColumnName("CodigoAlfanumerico".ToLower())
            .HasMaxLength(10);

        builder.Property(x => x.DataExpiracao)
            .HasColumnName("DataExpiracao".ToLower());

        builder.Property(x => x.Status)
            .HasColumnName("Status".ToLower())
            .HasDefaultValue(Status.Ativa);

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.CodigoAlfanumerico);

        builder.ToTable("urlencurtadas");
    }
}
