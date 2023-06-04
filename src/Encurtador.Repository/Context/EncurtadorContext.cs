using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Encurtador.Repository.Context;

public class EncurtadorContext : DbContext
{
    public EncurtadorContext(DbContextOptions<EncurtadorContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
