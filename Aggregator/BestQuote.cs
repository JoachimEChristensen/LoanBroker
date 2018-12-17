using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator
{
    class BestQuote
    {
        public string Ssn { get; set; }
        public double Bestquote { get; set; }
        public DateTime Time { get; set; }
        public bool Given { get; set; }
    }
}
