using Encurtador.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Encurtador.IoC;

public static class BootStrapper
{
    public static void RegisterIoC(this IServiceCollection services)
    {
        services.AddScoped<DbContext, EncurtadorContext>();
    }
}
