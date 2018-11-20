using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqCommunicator
{
    class Program
    {
        static void Main(string[] args) => new Program().StartAsync().GetAwaiter()/*.GetResult()*/;

        public async Task StartAsync()
        {
            string queue = "PBAG3_GetBanks";
            object o = new {message = "Hello World!"};

            bool success = Input(queue, o);

            //await Task.Delay(5000);

            object oJson = await Output(queue);

            string stopLine = Console.ReadLine();
        }

        public static bool Input(string queue, object o)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "datdb.cphbusiness.dk",
                //VirtualHost = "student",
                UserName = "student",
                Password = "cph"
            };

            try
            {
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    string jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(o);
                    var body = Encoding.UTF8.GetBytes(jsonObject);

                    channel.BasicPublish(exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: body);
                    Console.WriteLine(" [x] Sent {0}", jsonObject);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public async Task<object> Output(string queue)
        {
            object jsonObject = null;

            var factory = new ConnectionFactory()
            {
                HostName = "datdb.cphbusiness.dk",
                //VirtualHost = "student",
                UserName = "student",
                Password = "cph"
            };

            try
            {
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    bool messageReceived = false;
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(message);

                        Console.WriteLine(" [x] Received {0}", message);
                        channel.BasicAck(ea.DeliveryTag, false);

                        messageReceived = true;
                    };
                    channel.BasicConsume(queue: queue, consumer: consumer);

                    while (!messageReceived)
                    {
                        await Task.Delay(1000);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return jsonObject;
        }
    }
}
