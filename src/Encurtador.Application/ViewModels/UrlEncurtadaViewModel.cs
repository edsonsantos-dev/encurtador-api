using Encurtador.Shared.Config;
using Encurtador.Application.Extensions;
using Encurtador.Domain.Entities;

namespace Encurtador.Application.ViewModels;

public class UrlEncurtadaViewModel
{
    public required string UrlOriginal { get; set; }

    public UrlEncurtada ToModel()
    {
        var model = new UrlEncurtada
        {
            Id = Guid.NewGuid(),
            UrlOriginal = UrlOriginal,
            CodigoAlfanumerico = StringExtensions.GerarCodigoAlfanumerico(),
            DataExpiracao = DateTime.Now.AddHours(Settings.Instance.TempoExpiracao),
        };

        return model;
    }
}
