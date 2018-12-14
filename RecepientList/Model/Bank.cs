using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipientList.Model
{
    class BankObject
    {
        public int CreditScore { get; set; }
        public string Ssn { get; set; }
        public double LoanAmount { get; set; }
        public int LoanDuration { get; set; }
        public Bank[] Banks { get; set; }

        public class Bank
        {
            public string name { get; set; }
            public string bankId { get; set; }
            public int creditScore { get; set; }
            public string ssn { get; set; }
            public double loanAmount { get; set; }
            public int loanDuration { get; set; }
        }
    }
}


