using Encurtador.Domain.Entities;
using Encurtador.Domain.Enums;
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

    public async Task ExcluirExpiradosAsync()
    {
        await _context.UrlEncurtadas
            .AsNoTracking()
            .Where(x => x.DataExpiracao < DateTime.UtcNow)
            .ExecuteUpdateAsync(x =>
            x.SetProperty(e => e.Status, e => Status.Excluida));
    }
}
