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
    class RecipientList
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

        internal static class MessageRouter
        {
            public static void SendToRecipentList (Message msg, IMessageSender[] recipientList)
            {
                IEnumerator enumerator = recipientList.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ((IMessageSender)enumerator.Current).Send(msg);
                }
            }
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
            protected String bankname = "RabbbitMQ XML Bank";
            public BankXML() : base (".\\private$\\bankxmlQueue") {}

            public override bool EligibleLoanRequest(string ssn, int creditScore, int loanDuration, double loanAmount)
            {
              return loanAmount >= 1000 && creditScore >= 685 && loanDuration >= 1095 && ssn.Equals("12345678");
            }
        }

        internal class BankJSON : BankList
        {
          protected String bankname = "RabbbitMQ JSON Bank";
          public BankJSON() : base(".\\private$\\bankjsonQueue") {}

          public override bool EligibleLoanRequest(string ssn, int creditScore, int loanDuration, double loanAmount)
          {
            return loanAmount >= 10.0 && creditScore >= 598 && loanDuration >= 360 && ssn.Equals("1605789787");
          }
        }

        internal class Bank1 : BankList
        {
          protected String bankname = "RabbbitMQ 1 Bank";
          public Bank1() : base(".\\private$\\bank1Queue") {}

          public override bool EligibleLoanRequest(string ssn, int creditScore, int loanDuration, double loanAmount)
          {
            return loanAmount >= 20.0 && creditScore >= 698 && loanDuration >= 720 && ssn.Equals("1605605787");
          }
        }

        internal class Bank2 : BankList
        {
          protected String bankname = "RabbbitMQ 2 Bank";
          public Bank2() : base(".\\private$\\bank2Queue") {}

          public override bool EligibleLoanRequest(string ssn, int creditScore, int loanDuration, double loanAmount)
          {
            return loanAmount >= 15.5 && creditScore >= 666 && loanDuration >= 555 && ssn.Equals("1605559777");
          }
        }
    }
}
