namespace Encurtador.Shared.Config;

public class RedisSettings
{
    public static RedisSettings? Instance { get; private set; }

    public static void Initialize(RedisSettings? settings)
    {
        Instance = settings;
    }

    public required string InstanceName { get; set; }
    public required string Connection { get; set; }
    public int AbsoluteExpirationRelativeToNow { get; set; }
}
