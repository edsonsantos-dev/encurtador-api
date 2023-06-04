using Encurtador.Domain.Entities;
using Encurtador.Repository.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Encurtador.Repository.Context;

public class EncurtadorContext : DbContext
{
    public EncurtadorContext(DbContextOptions<EncurtadorContext> options) : base(options) { }

    public DbSet<UrlEncurtada> UrlEncurtadas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UrlEncurtadaConfig());
    }
}
