using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class InputMessage
    {
        public int creditScore { get; set; }
        public string ssn { get; set; }
        public float loanAmount { get; set; }
        public int loanDuration { get; set; }
        public Bank[] Banks { get; set; }
    }

    public class Bank
    {
        public int creditScore { get; set; }
        public object ssn { get; set; }
        public float loanAmount { get; set; }
        public int loanDuration { get; set; }
        public object[] Banks { get; set; }
    }

}
