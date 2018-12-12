using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqBank.Model
{
    public class MessageResponce
    {
        public double interestRate { get; set; }

        public string ssn { get; set; }

        public MessageResponce()
        {
          
        }
    }
}
