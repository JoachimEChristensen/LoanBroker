using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMq
{
    public class RabbitMq
    {
        /// <summary>
        /// RabbitMQ sender
        /// </summary>
        /// <param name="queue">The queue to send the object on</param>
        /// <param name="jsonString">The JSON string to send</param>
        /// <param name="replyToQueue">The queue the receiver should respond on (optional)</param>
        /// <returns>Boolean</returns>
        public static bool Input(string queue, string jsonString, string replyToQueue = "")
        {
            var factory = new ConnectionFactory()
            {
                HostName = "datdb.cphbusiness.dk",
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


                    var body = Encoding.UTF8.GetBytes(jsonString);

                    IBasicProperties props = channel.CreateBasicProperties();
                    props.ReplyTo = replyToQueue;

                    channel.BasicPublish(exchange: "",
                        routingKey: queue,
                        basicProperties: props,
                        body: body);
                    Console.WriteLine(" [x] Sent {0}", jsonString);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        /// <summary>
        /// RabbitMQ receiver
        /// </summary>
        /// <param name="queue">The queue to receiver the JSON string on</param>
        /// <returns>JSON string</returns>
        public static async Task<string> Output(string queue)
        {
            string message = "";

            var factory = new ConnectionFactory()
            {
                HostName = "datdb.cphbusiness.dk",
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
                        message = Encoding.UTF8.GetString(body);

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
                Console.WriteLine(e/*.Message*/);
            }

            return message;
        }
    }
}
