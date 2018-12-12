using RuleBase.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace RuleBase
{
    /// <summary>
    /// Summary description for RuleBaseWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RuleBaseWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Bank> makeLoan([XmlElement("creditScore")] int creditScore, [XmlElement("loanAmount")] double loanAmount)
        {
            List<Bank> banks = new List<Bank>();
            banks = getRule(creditScore, loanAmount);
            return banks;
        }

        public List<Bank> getRule(int creditScore, double loanAmount)
        {
            List<Bank> banks = new List<Bank>();
            if(creditScore > -1 && creditScore <= 800)
            {
                if ((loanAmount >= (double)18) && (loanAmount <= (double)999) && (creditScore >= 500))
                {
                    banks.Add(new Bank("RabbbitMQ Rest Bank", "bankRest"));
                    banks.Add(new Bank("RabbbitMQ JSON Bank", "bankJson"));                   
                }

                if ((loanAmount >= (double)999) && (creditScore >= 600))
                {
                    banks.Add(new Bank("RabbbitMQ XML Bank", "bankXml"));                  
                }

                banks.Add(new Bank("RabbbitMQ rabbit Bank", "bankRabbit"));
            }

            return banks;
        }
    }
}
