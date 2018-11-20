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
            //get.content();

            List<Bank> banks = new List<Bank>();

            banks.add(rulebase(creditScore, loanAmount));

            //send();
        }
    }
}
