using Encurtador.Application.Interfaces;
using Encurtador.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Encurtador.Api.Controllers;

[ApiController]
[Route("")]
public class UrlEncurtadaController : ControllerBase
{
    private readonly IUrlEncurtadaAppService _appService;

    public UrlEncurtadaController(IUrlEncurtadaAppService appService)
    {
        _appService = appService;
    }

    [HttpGet("{codigoAlfanumerico}")]
    public async Task<IActionResult> ObterUrlOriginal(string codigoAlfanumerico)
    {
        var url = await _appService.ObterUrlOriginal(codigoAlfanumerico);

        if (url != null) 
            return Redirect(url);

        return BadRequest("A URL não foi encontrada.");
    }

    
    [HttpPost]
    public async Task<IActionResult> AdicionarAsync(UrlEncurtadaViewModel viewModel)
    {
        var urlEncurtada = await _appService.AdicionarAsync(viewModel);

        return Ok(urlEncurtada);
    }
}
