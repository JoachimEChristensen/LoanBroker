using Banks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks
{
    class Program
    {
        static void Main(string[] args)
        {

            RuleBaseWebService RBWS = new RuleBaseWebService();
            //get.content();
            int creditScore = 0;
            int loanAmount = 0;
            List<Bank> banks = new List<Bank>();

            foreach (var bank in RBWS.makeLoan(creditScore, loanAmount))
            {
                banks.Add(bank);
            }
            
            //send();
        }
    }
}
