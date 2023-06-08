using Encurtador.Domain.Entities;
using FluentValidation;

namespace Encurtador.Application.Validators;

public class ObterUrlEncurtadaValidator : AbstractValidator<UrlEncurtada>
{
    public ObterUrlEncurtadaValidator()
    {
        RuleFor(x => x.DataExpiracao)
            .Must(d => d > DateTime.Now)
            .WithMessage("A validade da URL encurtada expirou.");
    }
}
