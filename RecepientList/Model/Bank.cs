using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipientList.Model
{
    class Bank
    {
        public int creditScore { get; set; }
        public string ssn { get; set; }
        public double loanAmount { get; set; }
        public int loanDuration { get; set; }

        public List<Bank> Banks { get; set; }

        public Bank()
        {
            this.Banks = new List<Bank>();
        }

        public Bank(int creditScore, string ssn, double loanAmount, int loanDuration)
        {
            this.creditScore = creditScore;
            this.ssn = ssn;
            this.loanAmount = loanAmount;
            this.loanDuration = loanDuration;
        }
  }
}
