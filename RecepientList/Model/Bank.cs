using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipientList.Model
{
    class Bank
    {
        public int CreditScore { get; set; }
        public string Ssn { get; set; }
        public double LoanAmount { get; set; }
        public int LoanDuration { get; set; }
        public string name { get; set; }
        public string bankId { get; set; }

        public List<Bank> Banks { get; set; }

        public Bank()
        {
            this.Banks = new List<Bank>();
        }

        public Bank(int creditScore, string ssn, double loanAmount, int loanDuration, string name, string bankId)
        {
            this.CreditScore = creditScore;
            this.Ssn = ssn;
            this.LoanAmount = loanAmount;
            this.LoanDuration = loanDuration;
            this.name = name;
            this.bankId = bankId;
        }
  }
}
