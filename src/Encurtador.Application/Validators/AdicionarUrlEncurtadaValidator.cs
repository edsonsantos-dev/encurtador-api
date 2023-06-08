using Encurtador.Application.Extensions;
using Encurtador.Domain.Entities;
using FluentValidation;

namespace Encurtador.Application.Validators;

public class AdicionarUrlEncurtadaValidator : AbstractValidator<UrlEncurtada>
{
    public AdicionarUrlEncurtadaValidator()
    {
        RuleFor(x => x.UrlOriginal)
            .Must(u => u.ValidarUrlOriginal())
            .WithMessage("O link fornecido possui um formato inválido. É necessário que ele comece com HTTPS:// ou HTTP://.");
    }
}
