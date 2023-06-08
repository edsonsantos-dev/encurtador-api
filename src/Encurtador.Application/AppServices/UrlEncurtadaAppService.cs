using Encurtador.Application.Interfaces;
using Encurtador.Application.Validators;
using Encurtador.Application.ViewModels;
using Encurtador.Domain.Entities;
using Encurtador.Repository.Interfaces;
using FluentValidation;

namespace Encurtador.Application.AppServices;

public class UrlEncurtadaAppService : IUrlEncurtadaAppService
{
    private readonly IUrlEncurtadaRepository _repository;
    private readonly IUrlEncurtadaCacheRepository _cache;
    private readonly ObterUrlEncurtadaValidator _obterValidator;
    private readonly AdicionarUrlEncurtadaValidator _adicionarValidator;

    public UrlEncurtadaAppService(IUrlEncurtadaRepository repository,
        IUrlEncurtadaCacheRepository cache,
        ObterUrlEncurtadaValidator validator,
        AdicionarUrlEncurtadaValidator adicionarValidator)
    {
        _repository = repository;
        _cache = cache;
        _obterValidator = validator;
        _adicionarValidator = adicionarValidator;
    }

    public async Task<UrlEncurtadaViewModel> AdicionarAsync(UrlEncurtadaViewModel viewModel)
    {
        var model = viewModel.ToModel();

        model = await _repository.AdicionarAsync(model);

        viewModel = ValidarEMapearModelo(model, _adicionarValidator);

        if (viewModel.ValidationResult.IsValid)
        {
            await _repository.SaveChangesAsync();

            await _cache.SetAsync(model.CodigoAlfanumerico, model);
        }

        return viewModel;
    }

    public async Task<UrlEncurtadaViewModel?> ObterUrlOriginal(string codigoAlfanumerico)
    {
        var model = await _cache.GetAsync(codigoAlfanumerico) ??
            await _repository.ObterUrlOriginal(codigoAlfanumerico);

        if (model == null)
            return null;

        var viewModel = ValidarEMapearModelo(model, _obterValidator);

        return viewModel;
    }

    public async Task<int> ExcluirExpiradosAsync(bool excluirFisicamente = false)
    {
        var linhasAfetadas = await _repository.ExcluirExpiradosAsync(excluirFisicamente);

        await _repository.SaveChangesAsync();

        return linhasAfetadas;
    }

    private UrlEncurtadaViewModel ValidarEMapearModelo(
        UrlEncurtada model,
        AbstractValidator<UrlEncurtada> validator)
    {
        var viewModel = UrlEncurtadaViewModel.FromModel(model);
        viewModel.ValidationResult = validator.Validate(model);

        return viewModel;
    }
}
