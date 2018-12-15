using Newtonsoft.Json;
using RabbitMq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqBank
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string input = RabbitMq.RabbitMq.Output("PBAG3_BankRabbit").Result;

                MessageRequest messageRequest = JsonConvert.DeserializeObject<MessageRequest>(input);

                double intrest_rate = 2 + new Random().Next(10) + new Random().NextDouble();

                MessageResponce messageResponce = new MessageResponce
                {
                    ssn = messageRequest.ssn,
                    interestRate = intrest_rate
                };

                string jsonObject = JsonConvert.SerializeObject(messageResponce);

                bool success = RabbitMq.RabbitMq.Input("PBAG3_Normalizer", jsonObject);
            }
        }
    } 
}