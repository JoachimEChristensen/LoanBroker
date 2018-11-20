using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banks.Model
{
    class Bank
    {
        private String name { get; set; }

        private String bankId { get; set; }

        public Bank()
        {

        }

        public Bank(String name, String Id)
        {
            this.name = name;
            this.bankId = bankId;
        }
    }
}
