using EstudoRBMQ.Relatorios;
using MassTransit;

namespace EstudoRBMQ.Bus
{
    internal sealed class RelatorioSolicitadoEventConsumer: IConsumer<RelatorioSolicitadoEvent>
    {
        private readonly ILogger<RelatorioSolicitadoEventConsumer> _logger;
        public RelatorioSolicitadoEventConsumer(ILogger<RelatorioSolicitadoEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
        {
            var message = context.Message;
            _logger.LogInformation($"Processando Relatório ID: {message.Id}, Nome:{message.Name}",message.Id, message.Name);
            await Task.Delay(1000);
            var relatorio = Lista.Relatorios.FirstOrDefault(x => x.Id == message.Id);
            
            //Delay
            await Task.Delay(10000);

            if (relatorio != null)
            {
                relatorio.Status = "Processado";
                relatorio.ProcessedTime = DateTime.Now;
            }
            _logger.LogInformation($"Relatório Processado ID: {message.Id}, Nome:{message.Name}",message.Id, message.Name);
        }
    }
}
