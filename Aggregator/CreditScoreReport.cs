using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator
{
    class CreditScoreReport
    {

        public int CreditScore { get; set; }
        public string Ssn { get; set; }
        public float LoanAmount { get; set; }
        public int LoanDuration { get; set; }

        public CreditScoreReport(int CreditScore, string Ssn, float LoanAmount, int LoanDuration)
        {
            this.CreditScore = CreditScore;
            this.Ssn = Ssn;
            this.LoanAmount = LoanAmount;
            this.LoanDuration = LoanDuration;
        }
    }
}
