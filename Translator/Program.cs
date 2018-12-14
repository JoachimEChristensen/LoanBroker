using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Translator
{
    class Program
    {
        private const string BasicQueue = "PBAG3_Translator_";
        private static readonly List<string> Queues = new List<string> {"RestBank", "JsonBank", "XmlBank", "RabbitBank"};

        static void Main(string[] args)
        {
            foreach (string queue in Queues)
            {
                //new PickBank(BasicQueue + queue);// for test
                Task.Factory.StartNew(() => new PickBank(BasicQueue + queue));
            }
            Task.Delay(-1).Wait();
        }
    }
}
