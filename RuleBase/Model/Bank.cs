using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RuleBase.Model
{
    public class Bank
    {
        public string name { get; set; }

        public string bankId { get; set; }

        public Bank()
        {

        }

        public Bank(string name, string Id)
        {
            this.name = name;
            this.bankId = Id;
        }
    }
}