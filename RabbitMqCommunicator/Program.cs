using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMqCommunicator
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool Input(string queue, object o)
        {
            var factory = new ConnectionFactory() /*{ HostName = "flamingo.rmq.cloudamqp.com", Password = "h1iuDwtRBSQDPkf0hdQgj6IJo-F4K4wl", UserName = "srplaybc" }*/;
            factory.uri = new Uri("amqp://srplaybc:h1iuDwtRBSQDPkf0hdQgj6IJo-F4K4wl@flamingo.rmq.cloudamqp.com/srplaybc");

            //connfac.setHost("datdb.cphbusiness.dk");
            //connfac.setVirtualHost("student");
            //connfac.setUsername("student");
            //connfac.setPassword("cph");

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "kageHello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message = "Hello World!";
                var body = /*Encoding.UTF8.GetBytes(message)*/System.IO.File.ReadAllBytes("text.txt");

                channel.BasicPublish(exchange: "",
                    routingKey: "kageHello",
                    basicProperties: null,
                    body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

            return false;
        }
    }
}
