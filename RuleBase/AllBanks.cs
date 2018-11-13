using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleBase
{
    class AllBanks
    {
        public Dictionary<string, ArrayList> createBanks()
        {
            IDictionary banks = new Dictionary<string, ArrayList>();

            ArrayList list = new ArrayList();
            IDictionary bankOne = new Dictionary<string, ArrayList>();
            bankOne["bankName"] = "Lån & Spar";
            bankOne["bankId"] = "bank-lån-and-spar";
            bankOne["minCreditScore"] = 0;

            IDictionary bankTwo = new Dictionary<string, ArrayList>();
            bankTwo["bankName"] = "Jyske Bank";
            bankTwo["bankId"] = "bank-jyske-bank";
            bankTwo["minCreditScore"] = 200;

            IDictionary bankThree = new Dictionary<string, ArrayList>();
            bankThree.["bankName"] = "Nordea";
            bankThree.["bankId"] = "bank-nordea";
            bankThree.["minCreditScore"] = 400;

            IDictionary bankFour = new Dictionary<string, ArrayList>();
            bankFour["bankName"] = "Danske Bank";
            bankFour["bankId"] = "bank-danske-bank";
            bankFour["minCreditScore"] = 700;

            list.Add(bankOne);
            list.Add(bankTwo);
            list.Add(bankThree);
            list.Add(bankFour);

            banks["banks"] = list;

            return (Dictionary) banks;
        }

        public HashMap getBanksByCreditScore(int creditScore)
        {
            ArrayList<HashMap> allBanks = createBanks().get("banks");

            HashMap bankResults = new HashMap<String, ArrayList>();
            ArrayList<HashMap> listOfBanks = new ArrayList();

            for (HashMap bank: allBanks)
            {
                int bankCreditScore = (Integer)bank.get("minCreditScore");
                if (bankCreditScore <= creditScore)
                {
                    listOfBanks.add(bank);
                }
            }

            bankResults.put("banks", listOfBanks);

            return bankResults;
        }

        public static void main(String[] args)
        {
            AllBanks app = new AllBanks();
            ArrayList<HashMap> allBanks = app.createBanks().get("banks");


            int creditScoreOne = 100;
            int creditScoreTwo = 250;
            int creditScoreThree = 500;
            int creditScoreFour = 800;
        }
    }
}
