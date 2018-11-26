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
            int best = 0;
            string bank = "";
            //string input = RabbitMq.RabbitMq.Output("PBAG3_Aggregator").Result;
            //CreditScoreReport O = JsonConvert.DeserializeObject<CreditScoreReport>(input);
            List<CreditScoreReport> CSR = new List<CreditScoreReport>();
            //resource.get(2);
            //resource.get(3);

            foreach (var CreditScoreReport in CSR)
            {
                if (CreditScoreReport.CreditScore < best)
                {
                    bank = CreditScoreReport.Ssn;
                    best = CreditScoreReport.CreditScore;
                }
            }
            Console.WriteLine("The best quote you can get for your desired loan is " + best + " from " + bank);
        }
    }
}
