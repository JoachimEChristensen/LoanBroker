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
                    case "RestBank":
                        Rest.SendRequest(inputMessage);
                        break;

                    case "JsonBank":
                        Json.SendRequest(inputMessage);
                        break;

                    case "XmlBank":
                        Xml.SendRequest(inputMessage);
                        break;

                    case "RabbitBank":
                        Rabbit.SendRequest(inputMessage);
                        break;
                }
            }
        }
    }
}
