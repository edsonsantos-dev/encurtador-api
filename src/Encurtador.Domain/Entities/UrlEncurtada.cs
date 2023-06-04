using Encurtador.Domain.Enums;

namespace Encurtador.Domain.Entities;

public class UrlEncurtada
{
    public Guid Id { get; set; }
    public required string UrlOriginal { get; set; }
    public required string Codigo { get; set; }
    public DateTime DataExpiracao { get; set; }
    public Status Status { get; set; }
}
