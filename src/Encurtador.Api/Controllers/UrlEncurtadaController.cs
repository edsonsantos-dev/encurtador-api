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

        return TratarRetorno(url);
    }

    
    [HttpPost]
    public async Task<IActionResult> AdicionarAsync(UrlEncurtadaViewModel viewModel)
    {
        var urlEncurtada = await _appService.AdicionarAsync(viewModel);

        return TratarRetorno(urlEncurtada, adicionar: true);
    }

    private IActionResult TratarRetorno(UrlEncurtadaViewModel? obj, bool adicionar = false)
    {
        if (obj == null)
            return NoContent();

        return obj.ValidationResult switch
        {
            { IsValid: true } when adicionar => Ok(obj.CodigoAlfanumerico),
            { IsValid: true } when !adicionar => Redirect(obj.UrlOriginal!),
            _ => BadRequest(obj.ValidationResult?.Errors)
        };
    }
}