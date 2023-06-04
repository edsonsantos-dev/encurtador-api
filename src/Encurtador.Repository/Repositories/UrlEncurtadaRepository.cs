using Encurtador.Domain.Entities;
using Encurtador.Shared.Enums;
using Encurtador.Repository.Context;
using Encurtador.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Encurtador.Repository.Repositories;

public class UrlEncurtadaRepository : RepositoryGeneric<UrlEncurtada>, IUrlEncurtadaRepository
{
    private readonly EncurtadorContext _context;

    public UrlEncurtadaRepository(EncurtadorContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UrlEncurtada?> ObterUrlOriginal(string codigoAlfanumerico)
    {
        return await _context.UrlEncurtadas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.CodigoAlfanumerico == codigoAlfanumerico);
    }

    public async Task<int> ExcluirExpiradosAsync(bool excluirFisicamente = false)
    {
        return await (excluirFisicamente ?
                ExcluirFisicamenteExpiradosAsync() :
                ExcluirLogicamenteExpiradosAsync());

    }

    private async Task<int> ExcluirLogicamenteExpiradosAsync()
    {
        var linhasAfetadas = await _context.UrlEncurtadas
            .AsNoTracking()
            .Where(x => x.DataExpiracao < DateTime.Now &&
                x.Status == Status.Ativa)
            .ExecuteUpdateAsync(x =>
                x.SetProperty(e => e.Status, e => Status.Excluida));

        return linhasAfetadas;
    }

    private async Task<int> ExcluirFisicamenteExpiradosAsync()
    {
        var linhasAfetadas = await _context.UrlEncurtadas
            .Where(x => x.Status == Status.Excluida)
            .ExecuteDeleteAsync();

        return linhasAfetadas;
    }
}
