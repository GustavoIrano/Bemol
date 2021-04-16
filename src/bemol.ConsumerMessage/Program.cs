using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace bemol.ConsumerMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando a aplicação!");

            var factory = new ConnectionFactory()
            {
                VirtualHost = "main",
                HostName = "rabbitmq",
                UserName = "mc",
                Password = "mc2",
                Port = 5672               
            };
            var rabbitMqConnection = factory.CreateConnection();
            var rabbitMqChannel = rabbitMqConnection.CreateModel();

            //declare the queue  
            rabbitMqChannel.QueueDeclare(queue: "users",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            //consume the message received  
            var consumer = new EventingBasicConsumer(rabbitMqChannel);

            consumer.Received += (model, args) =>
            {
                var body = args.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                Console.WriteLine("Novo usuário adicionado: " + message);
                rabbitMqChannel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
                Thread.Sleep(1000);
            };
            rabbitMqChannel.BasicConsume(queue: "users",
                                         autoAck: false,
                                         consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
