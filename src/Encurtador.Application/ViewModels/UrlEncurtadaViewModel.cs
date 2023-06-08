using Encurtador.Shared.Config;
using Encurtador.Application.Extensions;
using Encurtador.Domain.Entities;
using Encurtador.Shared.Enums;
using FluentValidation.Results;

namespace Encurtador.Application.ViewModels;

public class UrlEncurtadaViewModel
{
    public Guid? Id { get; set; }
    public string? UrlOriginal { get; set; }
    public string? CodigoAlfanumerico { get; set; }
    public string? UrlEncurtada { get; set; }
    public DateTime? DataExpiracao { get; set; }
    public Status? Status { get; set; }
    public ValidationResult? ValidationResult { get; set; }

    public UrlEncurtada ToModel()
    {
        var model = new UrlEncurtada
        {
            Id = Guid.NewGuid(),
            UrlOriginal = UrlOriginal!,
            CodigoAlfanumerico = StringExtensions.GerarCodigoAlfanumerico(),
            DataExpiracao = DateTime.Now.AddHours(Settings.Instance.TempoExpiracao),
        };

        return model;
    }

    public static UrlEncurtadaViewModel FromModel(UrlEncurtada model)
    {
        return new UrlEncurtadaViewModel
        {
            Id = model.Id,
            UrlOriginal = model.UrlOriginal,
            CodigoAlfanumerico = model.CodigoAlfanumerico,
            DataExpiracao = model.DataExpiracao,
            Status = model.Status,
            UrlEncurtada = model.CodigoAlfanumerico.MontarUrlEncurtada()
        };
    }
}
