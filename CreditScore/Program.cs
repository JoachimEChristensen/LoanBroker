using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreditScore
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditScoreService creditScoreService = new CreditScoreService();
            string ssn = Ssn();

            creditScoreService.creditScoreAsync(ssn);

            creditScoreService.creditScoreCompleted += CreditScoreCompleted;

            Console.WriteLine("Waiting for credit score.");
            Console.ReadLine();
        }

        private static void CreditScoreCompleted(object sender, creditScoreCompletedEventArgs e)
        {
            int creditScore = e.Result;

            Console.WriteLine("Credit score: " + creditScore);
        }

        private static string Ssn()
        {
            string ssn = "";

            Console.WriteLine("Input SSN:");

            Match match = Regex.Match(ssn, @"^\d{6}-\d{4}$");
            bool enter = false;
            bool firstTry = true;

            while (!match.Success && !enter)
            {
                if (!firstTry)
                {
                    Console.WriteLine("Try again: (XXXXXX-XXXX)");
                }
                ssn = Console.ReadLine();
                match = Regex.Match(ssn, @"^\d{6}-\d{4}$");

                if (firstTry)
                {
                    firstTry = false;
                }
                if (ssn == "")
                {
                    enter = true;
                }
            }

            if (ssn == "")
            {
                Random random = new Random();
                string randomBeginning = random.Next(1, 999999).ToString("000000");
                string randomEnding = random.Next(1, 9999).ToString("0000");
                ssn = randomBeginning + "-" + randomEnding;
            }

            Console.WriteLine("SSN: " + ssn);
            return ssn;
        }
    }
}
