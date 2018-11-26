using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class CreditScoreReport
    {

        public int CreditScore { get; set; }
        public string Ssn { get; set; }
        public float LoanAmount { get; set; }
        public int LoanDuration { get; set; }
        public List<Bank> Banks { get; set; }

        public CreditScoreReport()
        {
            this.Banks = new List<Bank>();
        }

        public CreditScoreReport(int CreditScore, string Ssn, float LoanAmount, int LoanDuration)
        {
            this.CreditScore = CreditScore;
            this.Ssn = Ssn;
            this.LoanAmount = LoanAmount;
            this.LoanDuration = LoanDuration;
        }
    }
}
