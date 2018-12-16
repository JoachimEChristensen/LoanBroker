using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Namespace;
            while (true)
            {
                int counter = 60000;
                if (counter > 0) counter--;
                double best = 9999999999999;
                bool yeah = true;
                List<Input> IN = new List<Input>();
                string input = RabbitMq.RabbitMq.Output("PBAG3_Aggregator");
                Input i = JsonConvert.DeserializeObject<Input>(input);
                IN.Add(i);
                if (counter < 0)
                {
                    foreach (Input inp in IN)
                    {
                        if (inp.InterestRate < best) best = inp.InterestRate;
                    }
                    Console.WriteLine("The best quote you can get for your desired loan is " + best);
                }
            }
        }
    }
}
