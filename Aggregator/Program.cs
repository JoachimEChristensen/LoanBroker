using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Aggregator
{
    class Program
    {
        static Input best = new Input();
        static List<Input> IN = new List<Input>();

        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Namespace;
            int counter = 60000;
            if (counter > 0) counter--;
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 60000;
            timer.Enabled = true;
            while (true)
            {
                string input = RabbitMq.RabbitMq.Output("PBAG3_Aggregator");
                Input i = JsonConvert.DeserializeObject<Input>(input);
                IN.Add(i);
                
            }
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            best.InterestRate = 9999999999999;
            foreach (Input inp in IN)
            {
                if (inp.InterestRate < best.InterestRate) best = inp;
            }
            Console.WriteLine("The best quote that you (" + best.Ssn + ") can get for your desired loan is " + best.InterestRate);
        }
    }
}
