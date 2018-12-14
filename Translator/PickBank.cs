using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Translator
{
    class PickBank
    {
        internal PickBank(string queue)
        {
            while (true)
            {
                string input = RabbitMq.RabbitMq.Output(queue).Result;

                InputMessage inputMessage = JsonConvert.DeserializeObject<InputMessage>(input);

                switch (queue)
                {
                    case "PBAG3_Translator_RestBank":
                        Rest.SendRequest(inputMessage).Wait();
                        break;

                    case "PBAG3_Translator_JsonBank":
                        Json.SendRequest(inputMessage);
                        break;

                    case "PBAG3_Translator_XmlBank":
                        Xml.SendRequest(inputMessage);
                        break;

                    case "PBAG3_Translator_RabbitBank":
                        Rabbit.SendRequest(inputMessage);
                        break;
                }
            }
        }
    }
}
