using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using MessageGateway;
using Newtonsoft.Json;
using RecipientList;
using RecipientList.Model;

namespace Loan_Broker_elements
{
    class Program
    {      
        static void Main(string[] args)
        {
            while (true)
            {
                string input = RabbitMq.RabbitMq.Output("PBAG3_Recipient").Result;

                Bank bank = JsonConvert.DeserializeObject<Bank>(input);
                int creditScore = bank.creditScore;
                string ssn = bank.ssn;
                double loanAmount = bank.loanAmount;
                int loanDuration = bank.loanDuration;

                Recipient recipient = new Recipient();
                List<string> item = new List<string>();
                for (int number = 0; number < bank.Banks.Count; number++)
                {                   
                    item.Add((recipient.GetBankQueues(ssn, creditScore, loanDuration, loanAmount)).ToString());
                }

                Message msg = new Message
                {
                    Body = item
                };

                JsonFormatter jsonFormatter = new JsonFormatter();
                jsonFormatter.Write(msg, bank);

                string jsonObject = JsonConvert.SerializeObject(bank);

                bool success = RabbitMq.RabbitMq.Input("PBAG3_Translator", jsonObject);
            }
        }   
    }
}
