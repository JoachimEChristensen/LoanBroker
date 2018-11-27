using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqBank
{
    class Program
    {
        static void Main(string[] args) => new Program().StartAsync().GetAwaiter();

        private static string RPC_QUEUE_NAME = "cphbusiness.bankRabbit";
        private static string queueName = "bank.rabbit.translator";
        private static string exchangeName = "translator.exch";
        private string bankExchange = "cphbusiness.bankRabbit";

        public async Task StartAsync()
        {
            string queue = queueName;
            object o = new { message = "Hello World!" };

            object oJson = await Input(queue);

           // bool success = Output(queue, o);

            string line = Console.ReadLine();
        }

        public async Task<object> Input(string queue)
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
                    channel.QueueDeclare(queue: RPC_QUEUE_NAME,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        double intrest_rate = 2 + new Random().Next(10) + new Random().NextDouble();
                        var response = "";
                        response = "{\"interestRate\":" + intrest_rate + "}";
                        var body = ea.Body;
                        body = Encoding.UTF8.GetBytes(response);
                        var message = Encoding.UTF8.GetString(body);

                        jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(message);

                        Console.WriteLine(" [x] Received {0}", message);

                        channel.BasicAck(ea.DeliveryTag, false);
                    };
                    channel.BasicConsume(queue: RPC_QUEUE_NAME, autoAck: false, consumer: consumer);
                }

                await Task.Delay(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return jsonObject;
        }       
    }
}
