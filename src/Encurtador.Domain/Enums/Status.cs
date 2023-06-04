namespace Encurtador.Domain.Enums
{
    public enum Status
    {
        Ativa = 0,
        Excluida = 1
    }

    public class Teste
    {
        public void TesteString()
        {
            var alfaNumericos = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var random = new Random();
            var codigo = Enumerable.Repeat(alfaNumericos, 10)
                .Select(x => x[random.Next(x.Length)])
                .ToArray()
                .ToString();
        }
    }
}