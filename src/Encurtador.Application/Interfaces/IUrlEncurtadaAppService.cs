using Encurtador.Application.ViewModels;

namespace Encurtador.Application.Interfaces;

public interface IUrlEncurtadaAppService
{
    Task<string> AdicionarAsync(UrlEncurtadaViewModel viewModel);
    Task<string?> ObterUrlOriginal(string codigoAlfanumerico);
    Task<int> ExcluirExpiradosAsync(bool excluirFisicamente = false);
}
