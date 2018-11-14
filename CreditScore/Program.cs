﻿using System;
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
            creditScoreService.creditScoreCompleted += CreditScoreCompleted;

            while (true)
            {
                string ssn = Ssn();
                double loanAmount = LoanAmount();
                int loanDuration = LoanDuration();

                creditScoreService.creditScoreAsync(ssn, new { ssn, loanAmount, loanDuration});
            }
        }

        private static void CreditScoreCompleted(object sender, creditScoreCompletedEventArgs e)
        {
            int creditScore = e.Result;
            string ssn = e.UserState?.GetType().GetProperty("ssn")?.GetValue(e.UserState, null).ToString();
            double loanAmount = Convert.ToDouble(e.UserState?.GetType().GetProperty("loanAmount")?.GetValue(e.UserState, null));
            int loanDuration = Convert.ToInt32(e.UserState?.GetType().GetProperty("loanDuration")?.GetValue(e.UserState, null));

            Console.WriteLine("SSN: " + ssn + ", Credit score: " + creditScore + ", Loan amount: " + loanAmount + ", Loan duration: " + loanDuration);
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

        private static double LoanAmount()
        {
            string loanAmount = "";

            Console.WriteLine("Input loan amount:");

            Match match = Regex.Match(loanAmount, @"^\d+(?:\.\d+)?$");
            bool enter = false;
            bool firstTry = true;

            while (!match.Success && !enter)
            {
                if (!firstTry)
                {
                    Console.WriteLine("Try again: (XX.XX)");
                }
                loanAmount = Console.ReadLine();
                match = Regex.Match(loanAmount, @"^\d+(?:\.\d+)?$");

                if (firstTry)
                {
                    firstTry = false;
                }
                if (loanAmount == "")
                {
                    enter = true;
                }
            }

            if (loanAmount == "")
            {
                Random random = new Random();
                loanAmount = (random.NextDouble() * 1000).ToString("0.##");
            }

            Console.WriteLine("Loan amount: " + loanAmount);
            return Convert.ToDouble(loanAmount);
        }

        private static int LoanDuration()
        {
            string loaDuration = "";

            Console.WriteLine("Input loan amount:");

            Match match = Regex.Match(loaDuration, @"^\d+$");
            bool enter = false;
            bool firstTry = true;

            while (!match.Success && !enter)
            {
                if (!firstTry)
                {
                    Console.WriteLine("Try again: (XX.XX)");
                }
                loaDuration = Console.ReadLine();
                match = Regex.Match(loaDuration, @"^\d+$");

                if (firstTry)
                {
                    firstTry = false;
                }
                if (loaDuration == "")
                {
                    enter = true;
                }
            }

            if (loaDuration == "")
            {
                Random random = new Random();
                loaDuration = random.Next(1, 500).ToString();
            }

            Console.WriteLine("Loan duration: " + loaDuration);
            return Convert.ToInt32(loaDuration);
        }
    }
}
