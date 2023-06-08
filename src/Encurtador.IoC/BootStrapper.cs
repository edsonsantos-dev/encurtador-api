using Encurtador.Application.AppServices;
using Encurtador.Application.Interfaces;
using Encurtador.Application.Validators;
using Encurtador.Repository.Context;
using Encurtador.Repository.Interfaces;
using Encurtador.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Encurtador.IoC;

public static class BootStrapper
{
    public static void RegisterIoC(this IServiceCollection services)
    {
        services.AddScoped<DbContext, EncurtadorContext>();
        services.AddScoped<IUrlEncurtadaAppService, UrlEncurtadaAppService>();

        services.AddScoped<IUrlEncurtadaRepository, UrlEncurtadaRepository>();
        services.AddScoped<IUrlEncurtadaCacheRepository, UrlEncurtadaCacheRepository>();

        services.AddTransient<ObterUrlEncurtadaValidator>();
        services.AddTransient<AdicionarUrlEncurtadaValidator>();
    }
}
