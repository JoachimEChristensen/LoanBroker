using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Namespace;

            string input = RabbitMq.RabbitMq.Output("PBAG3_Normalizer").Result;// send to PBAG3_Aggregator
        }
    }
}
