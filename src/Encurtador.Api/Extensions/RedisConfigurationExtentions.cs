using Encurtador.Shared.Config;

namespace Encurtador.Api.Extensions;

public static class RedisConfigurationExtentions
{
    public static void RedisConfiguration(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddStackExchangeRedisCache(options =>
        {
            options.InstanceName = RedisSettings.Instance.InstanceName;
            options.Configuration = RedisSettings.Instance.Connection;
        });
    }
}
