using Encurtador.Shared.Config;

namespace Encurtador.Application.Extensions;

internal static class StringExtensions
{
    internal static string GerarCodigoAlfanumerico()
    {
        var alfaNumericos = Settings.Instance.Alfanumerico;

        var random = new Random();

        int tamanhoMinimo = Settings.Instance.TamanoMinimo;
        int tamanhoMaximo = Settings.Instance.TamanoMaximo;

        int tamanho = random.Next(tamanhoMinimo, tamanhoMaximo);

        var codigoAlfanumerico = new string(Enumerable.Repeat(alfaNumericos, tamanho)
            .Select(x => x[random.Next(x.Length)])
            .ToArray());

        return codigoAlfanumerico;
    }

    internal static string MontarUrlEncurtada(this string codigoAlfanumerico) =>
        $"{Settings.Instance.UrlBase}{codigoAlfanumerico}";
}
