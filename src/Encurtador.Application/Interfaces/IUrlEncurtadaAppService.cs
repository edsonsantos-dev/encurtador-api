using Encurtador.Application.ViewModels;

namespace Encurtador.Application.Interfaces;

public interface IUrlEncurtadaAppService
{
    Task<UrlEncurtadaViewModel> AdicionarAsync(UrlEncurtadaViewModel viewModel);
    Task<UrlEncurtadaViewModel?> ObterUrlOriginal(string codigoAlfanumerico);
    Task<int> ExcluirExpiradosAsync(bool excluirFisicamente = false);
}
