using Encurtador.Shared.Config;

namespace Encurtador.Api.Extensions;

public static class SettingsLoadExtensions
{
    public static void LoadSettings(this WebApplicationBuilder builder)
    {
        Settings.Initialize(builder.Configuration.GetSection(nameof(Settings)).Get<Settings>());
        RedisSettings.Initialize(builder.Configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>());
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Program>();
            var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            webBuilder.UseUrls($"http://*:{port}/");
        });
}
