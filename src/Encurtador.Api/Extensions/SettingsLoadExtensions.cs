using Encurtador.Application.Config;

namespace Encurtador.Api.Extensions;

public static class SettingsLoadExtensions
{
    public static void LoadSettings(this WebApplicationBuilder builder)
    {
        Settings.Initialize(builder.Configuration.GetSection(nameof(Settings)).Get<Settings>());
    }
}
