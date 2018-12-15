using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    static class Rabbit
    {
        public static void SendRequest(InputMessage inputMessage)
        {
            string jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(inputMessage);

            bool success = RabbitMq.RabbitMq.Input("PBAG3_BankRabbit", jsonObject);
        }
    }
}
