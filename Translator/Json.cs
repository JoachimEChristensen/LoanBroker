using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    static class Json
    {
        public static void SendRequest(InputMessage inputMessage)
        {
            inputMessage.Ssn = inputMessage.Ssn.Replace("-", "");

            string jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(new {ssn = inputMessage.Ssn, creditScore = inputMessage.CreditScore, loanAmount = inputMessage.LoanAmount, loanDuration = inputMessage.LoanDuration});

            bool success = RabbitMq.RabbitMq.Input("", jsonObject, "cphbusiness.bankJSON", "PBAG3_Normalizer");
        }
    }
}
