using Encurtador.Application.Validators;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace Encurtador.Api.Extensions;

public static class AddFluentValidationConfigurationExtentions
{
    public static void AddFluentValidation(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssemblyContaining<AdicionarUrlEncurtadaValidator>();
    }
}
