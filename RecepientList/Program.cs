using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
               
                int creditScore = bank.CreditScore;
                string ssn = bank.Ssn;
                double loanAmount = bank.LoanAmount;
                int loanDuration = bank.LoanDuration;
                string name = bank.name;
                string bankId = bank.bankId;

                List<Bank> recipientList = new List<Bank>();

                foreach (var item in bank.Banks)
                {
                    recipientList.Add(item);     
                }

                string jsonObject = JsonConvert.SerializeObject(recipientList);

                Console.WriteLine(jsonObject);

                //bool success = RabbitMq.RabbitMq.Input("PBAG3_Translator", jsonObject);
            }
        }   
    }
}
