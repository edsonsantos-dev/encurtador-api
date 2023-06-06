using Encurtador.Application.Extensions;
using Encurtador.Application.Interfaces;
using Encurtador.Application.ViewModels;
using Encurtador.Domain.Entities;
using Encurtador.Repository.Interfaces;
using Encurtador.Shared.Enums;

namespace Encurtador.Application.AppServices;

public class UrlEncurtadaAppService : IUrlEncurtadaAppService
{
    private readonly IUrlEncurtadaRepository _repository;
    private readonly IUrlEncurtadaCacheRepository _cache;

    public UrlEncurtadaAppService(IUrlEncurtadaRepository repository,
        IUrlEncurtadaCacheRepository cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<string> AdicionarAsync(UrlEncurtadaViewModel viewModel)
    {
        var model = viewModel.ToModel();

        model = await _repository.AdicionarAsync(model);

        var urlEncurtada = model.CodigoAlfanumerico.MontarUrlEncurtada();

        await _repository.SaveChangesAsync();

        await _cache.SetAsync(model.CodigoAlfanumerico, model);

        return urlEncurtada;
    }

    public async Task<string?> ObterUrlOriginal(string codigoAlfanumerico)
    {
        var model = await _cache.GetAsync(codigoAlfanumerico) ??
            await _repository.ObterUrlOriginal(codigoAlfanumerico);

        if (model == null)
            return null;

        VerificarStatusEExpiracao(model);

        return model.UrlOriginal;
    }

    public async Task<int> ExcluirExpiradosAsync(bool excluirFisicamente = false)
    {
        var linhasAfetadas = await _repository.ExcluirExpiradosAsync(excluirFisicamente);

        await _repository.SaveChangesAsync();

        return linhasAfetadas;
    }

    private void VerificarStatusEExpiracao(UrlEncurtada model)
    {
        if (model.Status == Status.Excluida || model.DataExpiracao < DateTime.Now)
            throw new Exception("O tempo de vida da URL encurtada finalizou.");
    }
}
