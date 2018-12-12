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
                int creditScore = bank.creditScore;
                string ssn = bank.ssn;
                double loanAmount = bank.loanAmount;
                int loanDuration = bank.loanDuration;
                
                foreach ( Bank banks in bank.Banks)
                {
                    bank.Banks.Add(bank);                   
                }

                string jsonObject = JsonConvert.SerializeObject(bank);

                bool success = RabbitMq.RabbitMq.Input("PBAG3_Translator", jsonObject);
            }
        }   
    }
}
