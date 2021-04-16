using bemol.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace bemol.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificator _notificador;

        protected BaseController(INotificator notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.HaveNotification();
        }

        protected void PublishMessage(string newUser)
        {
            var factory = new ConnectionFactory()
            {
                VirtualHost = "main",
                HostName = "rabbitmq",
                UserName = "mc",
                Password = "mc2",
                Port = 5672
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "users",
                                          durable: false,
                                          exclusive: false,
                                          autoDelete: false,
                                          arguments: null);

                    channel.BasicPublish(exchange: "",
                                          routingKey: "users",
                                          basicProperties: null,
                                          body: Encoding.UTF8.GetBytes(newUser));
                }
            }
        }
    }
}
