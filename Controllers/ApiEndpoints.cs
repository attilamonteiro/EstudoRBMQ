using EstudoRBMQ.Relatorios;
using MassTransit;

namespace EstudoRBMQ.Controllers
{
    public static class ApiEndpoints
    {
        public static void AddApiEndpoints(this WebApplication app)
        {
            app.MapGet("solicitar-relatorio/{name}", (string name) =>
            {
                var solicitacao = new SoliitacaoRelatorio()
                {
                    Id = Guid.NewGuid(),
                    Nome = name,
                    Status = "Pendente",
                    ProcessedTime = null
                };
                Lista.Relatorios.Add(solicitacao);
                return Results.Ok(solicitacao);
            });
            app.MapGet("relatorios", () => Lista.Relatorios);

         }

    }
     
}
