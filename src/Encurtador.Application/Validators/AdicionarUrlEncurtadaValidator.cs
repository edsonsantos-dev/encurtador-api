using Encurtador.Application.Extensions;
using Encurtador.Application.ViewModels;
using FluentValidation;

namespace Encurtador.Application.Validators;

public class AdicionarUrlEncurtadaValidator : AbstractValidator<UrlEncurtadaViewModel>
{
    public AdicionarUrlEncurtadaValidator()
    {
        RuleFor(x => x.UrlOriginal)
            .Must(u => u.ValidarUrlOriginal())
            .WithMessage("O link fornecido possui um formato inválido.");
    }
}
