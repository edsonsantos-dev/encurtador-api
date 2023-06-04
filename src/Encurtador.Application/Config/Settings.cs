namespace Encurtador.Application.Config;

public class Settings
{
    public static Settings Instance { get; private set; }

    public static void Initialize(Settings settings)
    {
        Instance = settings;
    }

    public required string Alfanumerico { get; set; }
    public int TamanoMinimo { get; set; }
    public int TamanoMaximo { get; set;}
}
