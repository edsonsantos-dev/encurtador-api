﻿using Encurtador.Domain.Entities;

namespace Encurtador.Repository.Interfaces;

public interface IUrlEncurtadaRepository : IRepository<UrlEncurtada>
{
    Task<UrlEncurtada?> ObterUrlOriginal(string codigoAlfanumerico);
    Task ExcluirExpiradosAsync(bool excluirFisicamente = false);
}
