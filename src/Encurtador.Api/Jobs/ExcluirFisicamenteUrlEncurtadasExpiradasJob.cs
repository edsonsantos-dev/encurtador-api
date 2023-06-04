using Encurtador.Application.Interfaces;
using Quartz;

namespace Encurtador.Api.Jobs;

[DisallowConcurrentExecution]
public class ExcluirFisicamenteUrlEncurtadasExpiradasJob : IJob
{
    private readonly IUrlEncurtadaAppService _urlEncurtadaAppService;
    private readonly ILogger<ExcluirFisicamenteUrlEncurtadasExpiradasJob> _logger;

    public ExcluirFisicamenteUrlEncurtadasExpiradasJob(
        IUrlEncurtadaAppService urlEncurtadaAppService,
        ILogger<ExcluirFisicamenteUrlEncurtadasExpiradasJob> logger)
    {
        _urlEncurtadaAppService = urlEncurtadaAppService;
        _logger = logger;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Iniciando a exclusão física das urls expiradas");
        var linhasAfetadas = await _urlEncurtadaAppService.ExcluirExpiradosAsync(excluirFisicamente: true);
        _logger.LogInformation($"Quantidade de linhas afetadas {linhasAfetadas}");
    }
}
