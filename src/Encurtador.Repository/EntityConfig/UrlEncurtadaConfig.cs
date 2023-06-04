using Encurtador.Domain.Entities;
using Encurtador.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encurtador.Repository.EntityConfig;

public class UrlEncurtadaConfig : IEntityTypeConfiguration<UrlEncurtada>
{
    public void Configure(EntityTypeBuilder<UrlEncurtada> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Codigo)
            .HasMaxLength(10);

        builder.Property(x => x.Status)
            .HasDefaultValue(Status.Ativa);

        builder.ToTable("urlencurtada");
    }
}
