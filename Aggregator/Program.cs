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
        private static double _best = 9999999999999;
        private static readonly List<Input> Inputs = new List<Input>();
        private static readonly List<BestQuote> BestQuotes = new List<BestQuote>();

        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Namespace;

            Task.Factory.StartNew(() => new CheckTime(BestQuotes));

            while (true)
            {
                string inputString = RabbitMq.RabbitMq.Output("PBAG3_Aggregator");
                Input input = JsonConvert.DeserializeObject<Input>(inputString);

                Inputs.Add(input);

                for (var i = 0; i < Inputs.Count; i++)
                {
                    BestQuote bestQuote = new BestQuote();
                    bestQuote.Time = DateTime.Now;
                    bestQuote.Ssn = Inputs[i].Ssn;

                    _best = Inputs[i].InterestRate;

                    bestQuote.Bestquote = Inputs[i].InterestRate;
                    if (BestQuotes.All(b => b.Ssn != bestQuote.Ssn))
                    {
                        BestQuotes.Add(bestQuote);
                    }
                    else
                    {
                        foreach (BestQuote quote in BestQuotes)
                        {
                            if (quote.Ssn == bestQuote.Ssn && quote.Bestquote > bestQuote.Bestquote && !bestQuote.Given)
                            {
                                quote.Bestquote = _best;
                            }
                        }
                    }

                    Inputs.RemoveAt(i);
                }
            }
        }
    }

    internal class CheckTime
    {
        public CheckTime(List<BestQuote> bestQuotes)
        {
            while (true)
            {
                int bestQuotesCount = bestQuotes.Count;

                if (bestQuotesCount > 0)
                {
                    for (var i = 0; i < bestQuotesCount; i++)
                    {
                        BestQuote bestQuote = bestQuotes[i];

                        if (bestQuote.Time.AddSeconds(10) < DateTime.Now && !bestQuote.Given)
                        {
                            Console.WriteLine("The best quote you({0}) can get for your desired loan is {1}", bestQuote.Ssn, bestQuote.Bestquote);
                            bestQuote.Given = true;
                        }
                    }
                }
            }
        }
    }
}
