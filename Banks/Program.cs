using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = RabbitMq.RabbitMq.Output("PBAG3_GetBanks").Result;

            RuleBaseWebService RBWS = new RuleBaseWebService();
            CreditScoreReport O = JsonConvert.DeserializeObject<CreditScoreReport>(input);
            int creditScore = O.CreditScore;
            float loanAmount = O.LoanAmount;

            foreach (var bank in RBWS.makeLoan(creditScore, loanAmount))
            {
                O.Banks.Add(bank);
            }
            
            string jsonObject = JsonConvert.SerializeObject(O);
            

            bool success = RabbitMq.RabbitMq.Input("PBAG3_Recipient", jsonObject);
        }
    }
}
