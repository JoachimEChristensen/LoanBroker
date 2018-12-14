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

                BankObject bank = JsonConvert.DeserializeObject<BankObject>(input);

                List<BankObject.Bank> recipientList = new List<BankObject.Bank>();

                foreach (var item in bank.Banks)
                {
                    item.creditScore = bank.CreditScore;
                    item.ssn = bank.Ssn;
                    item.loanAmount = bank.LoanAmount;
                    item.loanDuration = bank.LoanDuration;
                    recipientList.Add(item);
                }

                int number = recipientList.Count;
                string jsonObject;
                bool success;

                for (int i = 0; i < number; i++)
                {
                    switch(recipientList[i].bankId)
                    {
                        case "bankRest":
                            jsonObject = JsonConvert.SerializeObject(recipientList[i]);
                            success = RabbitMq.RabbitMq.Input("PBAG3_Translator_RestBank", jsonObject);
                            break;

                        case "bankJson":
                            jsonObject = JsonConvert.SerializeObject(recipientList[i]);
                            success = RabbitMq.RabbitMq.Input("PBAG3_Translator_JsonBank", jsonObject);
                            break;

                        case "bankXml":
                            jsonObject = JsonConvert.SerializeObject(recipientList[i]);
                            success = RabbitMq.RabbitMq.Input("PBAG3_Translator_XmlBank", jsonObject);
                            break;

                        case "bankRabbit":
                            jsonObject = JsonConvert.SerializeObject(recipientList[i]);
                            success = RabbitMq.RabbitMq.Input("PBAG3_Translator_RabbitBank", jsonObject);
                            break;

                        default:
                            Console.WriteLine("Error! No Bank existed");
                            break;
                    }
                }
            }
        }
    }
}
