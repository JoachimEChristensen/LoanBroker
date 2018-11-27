using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Collections;
using MessageGateway;

namespace RecipientList
{
    class Recipient
    {
        protected BankList[] banks = { new BankXML(), new BankJSON(), new Bank1(), new Bank2() };
     
        public IMessageSender[] GetBankQueues(string ssn, int creditScore, int loanDuration, double loanAmount)
        {
            ArrayList creditors = new ArrayList();

            for (int number = 0; number < banks.Length; number++)
            {
                if(banks[number].EligibleLoanRequest(ssn, creditScore, loanDuration, loanAmount))
                {
                    creditors.Add(banks[number].Queue);
                }
            }

            IMessageSender[] creditorArray = (IMessageSender[])Array.CreateInstance(typeof(IMessageSender), creditors.Count);
            creditors.CopyTo(creditorArray);
            return creditorArray;
        }
       
        internal abstract class BankList
        {
            protected MessageSenderGateway queue;
            protected String bankName = "";
            
            public MessageSenderGateway Queue
            {
                get { return queue; }
            }

            public String BankName
            {
                get { return bankName; }
            }

            public BankList (MessageQueue queue)
            {
              this.queue = new MessageSenderGateway(queue);
            }
            
            public BankList(String queueName)
            {
              this.queue = new MessageSenderGateway(queueName);
            }

            public abstract bool EligibleLoanRequest(string ssn, int creditScore, int loanDuration, double loanAmount);
        }

        internal class BankXML : BankList
        {
            protected string bankname = "RabbbitMQ XML Bank";
            public BankXML() : base (".\\private$\\bankxmlQueue") {}

            public override bool EligibleLoanRequest(string ssn, int creditScore, int loanDuration, double loanAmount)
            {
              return loanAmount >= 999 && creditScore >= 600 && loanDuration >= 1095;
            }
        }

        internal class BankJSON : BankList
        {
          protected string bankname = "RabbbitMQ JSON Bank";
          public BankJSON() : base(".\\private$\\bankjsonQueue") {}

          public override bool EligibleLoanRequest(string ssn, int creditScore, int loanDuration, double loanAmount)
          {
            return loanAmount >= 10.0 && creditScore >= 500 && loanDuration >= 360;
          }
        }

        internal class Bank1 : BankList
        {
          protected string bankname = "RabbbitMQ 1 Bank";
          public Bank1() : base(".\\private$\\bank1Queue") {}

          public override bool EligibleLoanRequest(string ssn, int creditScore, int loanDuration, double loanAmount)
          {
            return loanAmount >= 18.0 && creditScore >= 500 && loanDuration >= 720;
          }
        }

        internal class Bank2 : BankList
        {
          protected string bankname = "RabbbitMQ 2 Bank";
          public Bank2() : base(".\\private$\\bank2Queue") {}

          public override bool EligibleLoanRequest(string ssn, int creditScore, int loanDuration, double loanAmount)
          {
            return loanAmount >= 15.5 && creditScore > -1 && loanDuration >= 555;
          }
        }
    }
}
