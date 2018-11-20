using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RuleBase.Model
{
    public class Bank
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