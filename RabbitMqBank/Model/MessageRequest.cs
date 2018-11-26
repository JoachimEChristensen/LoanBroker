using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqBank.Model
{
    class MessageRequest
    {
        public string ssn { get; set; }

        public int creditScore { get; set; }

        public double loanAmount { get; set; }

        public int loanDuration { get; set; }

        public MessageRequest()
        {

        }
    }
}