using Encurtador.Application.Interfaces;
using Quartz;

namespace Encurtador.Api.Jobs;

[DisallowConcurrentExecution]
public class ExcluirLogicamenteUrlEncurtadasExpiradasJob : IJob
{
    private readonly IUrlEncurtadaAppService _urlEncurtadaAppService;
    private readonly ILogger<ExcluirLogicamenteUrlEncurtadasExpiradasJob> _logger;

    public ExcluirLogicamenteUrlEncurtadasExpiradasJob(
        IUrlEncurtadaAppService urlEncurtadaAppService,
        ILogger<ExcluirLogicamenteUrlEncurtadasExpiradasJob> logger)
    {
        _urlEncurtadaAppService = urlEncurtadaAppService;
        _logger = logger;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Iniciando a exclusão lógica das urls expiradas");
        var linhasAfetadas = await _urlEncurtadaAppService.ExcluirExpiradosAsync();
        _logger.LogInformation($"Quantidade de linhas afetadas {linhasAfetadas}");
    }
}
