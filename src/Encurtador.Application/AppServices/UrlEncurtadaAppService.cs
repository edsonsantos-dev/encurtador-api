using Encurtador.Application.Extensions;
using Encurtador.Application.Interfaces;
using Encurtador.Application.ViewModels;
using Encurtador.Repository.Interfaces;
using Encurtador.Shared.Enums;

namespace Encurtador.Application.AppServices;

public class UrlEncurtadaAppService : IUrlEncurtadaAppService
{
    private readonly IUrlEncurtadaRepository _repository;

    public UrlEncurtadaAppService(IUrlEncurtadaRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> AdicionarAsync(UrlEncurtadaViewModel viewModel)
    {
        if (string.IsNullOrEmpty(viewModel.UrlOriginal))
            throw new ArgumentNullException("Url não pode ser vazia ou nula");

        var model = viewModel.ToModel();

        model = await _repository.AdicionarAsync(model);

        var urlEncurtada = model.CodigoAlfanumerico.MontarUrlEncurtada();

        await _repository.SaveChangesAsync();

        return urlEncurtada;
    }

    public async Task<string?> ObterUrlOriginal(string codigoAlfanumerico)
    {
        var model = await _repository.ObterUrlOriginal(codigoAlfanumerico);

        if (model == null)
            return null;

        if (model.Status == Status.Excluida || model.DataExpiracao < DateTime.Now)
            throw new Exception("O tempo de vida da url encurtada finalizou.");

        return model.UrlOriginal;
    }

    public async Task<int> ExcluirExpiradosAsync(bool excluirFisicamente = false)
    {
        var linhasAfetadas = await _repository.ExcluirExpiradosAsync(excluirFisicamente);
        await _repository.SaveChangesAsync();

        return linhasAfetadas;
    }
}
