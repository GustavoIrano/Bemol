using bemol.WebMapNewCustomers.Models;
using bemol.WebMapNewCustomers.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace bemol.WebMapNewCustomers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceList _serviceList;

        public HomeController(ILogger<HomeController> logger, IServiceList serviceList)
        {
            _logger = logger;
            _serviceList = serviceList;
        }

        public IActionResult Index()
        {
            ConsumeQueue();

            return View();
        }

        private void ConsumeQueue()
        {
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
            rabbitMqChannel.QueueDeclare(queue: "address",
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

                var teste = message.Replace(@"\", "").Trim(new char[] { ' ', '"' });

                GetDadosCep(teste);

                rabbitMqChannel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
                Thread.Sleep(1000);
            };
            rabbitMqChannel.BasicConsume(queue: "address",
                                         autoAck: false,
                                         consumer: consumer);
        }

        [HttpGet]
        public JsonResult GetCoordenadas()
        {
            return Json(_serviceList.GetList());
        }

        public async void GetDadosCep(string endereoo)
        {
            var _httpClient = new HttpClient();

            var response = await _httpClient.GetAsync($"https://maps.googleapis.com/maps/api/geocode/json?address=1," + endereoo + "&key=AIzaSyC_nfJfJCdk-caJcUw3FV2I-VJgmNUcHdQ");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {

                    var teste = System.Text.Json.JsonSerializer.Deserialize<Root>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    _serviceList.SetItemList(new Coordenadas()
                    {
                        lat = teste.results.FirstOrDefault().geometry.location.lat,
                        lng = teste.results.FirstOrDefault().geometry.location.lng
                    });

                }
                catch (Exception)
                {
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        public class Root
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }


    }
}
