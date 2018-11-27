using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Translator
{
    class Program
    {
        

        static void Main(string[] args)
        {
            while (true)
            {
                string input = RabbitMq.RabbitMq.Output("PBAG3_Translator").Result;
                
                //convert from JSON to object
                //fix InputMessage class

                //Thread thread = new Thread(() => PickBanks("object from string"));
                //thread.Start();
            }
        }

        private static void PickBanks(string someObject)
        {
            //check list of banks and foreach
            //RabbbitMQ 1 Bank
            //RabbbitMQ 2 Bank
            //RabbbitMQ JSON Bank
            //RabbbitMQ XML Bank
        }
    }
}
