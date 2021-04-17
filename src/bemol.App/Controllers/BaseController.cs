using bemol.Business.Interfaces;
using bemol.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        protected void PublishMessage(Customer customer)
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
                                          body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(customer.Name)));

                    channel.QueueDeclare(queue: "address",
                                          durable: false,
                                          exclusive: false,
                                          autoDelete: false,
                                          arguments: null);

                    channel.BasicPublish(exchange: "",
                                          routingKey: "address",
                                          basicProperties: null,
                                          body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(customer.Address.Street)));
                }
            }
        }
    }
}
