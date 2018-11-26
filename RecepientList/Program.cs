using System;
using System.Collections;
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
            string input = RabbitMq.RabbitMq.Output("PBAG3_Recipient").Result;

            Bank bank = JsonConvert.DeserializeObject<Bank>(input);
            int creditScore = bank.creditScore;
            string ssn = bank.ssn;
            double loanAmount = bank.loanAmount;
            int loanDuration = bank.loanDuration;

            Recipient recipient = new Recipient();
            var items = recipient.GetBankQueues(ssn, creditScore, loanDuration, loanAmount);

            Message msg = new Message();
            msg.Body = items;

            JsonFormatter jsonFormatter = new JsonFormatter();
            jsonFormatter.Write(msg, bank);

            string jsonObject = JsonConvert.SerializeObject(bank);

            bool success = RabbitMq.RabbitMq.Input("PBAG3_Translator", jsonObject);
        }   
    }
}
