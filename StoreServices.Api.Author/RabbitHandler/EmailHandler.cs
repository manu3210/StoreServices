using StoreServices.RabbitMQ.Bus.BusRabbit;
using StoreServices.RabbitMQ.Bus.EventQueue;

namespace StoreServices.Api.Author.RabbitHandler
{
    public class EmailHandler : IEventHandler<EmailEventQueue>
    {
        private readonly ILogger<EmailHandler> _logger;

        public EmailHandler(ILogger<EmailHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(EmailEventQueue pEvent)
        {
            _logger.LogInformation($"Value from Rabbit: {pEvent.Tittle}");

            return Task.CompletedTask;
        }
    }
}
