﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Translator
{
    static class Xml
    {
        public static void SendRequest(InputMessage inputMessage)
        {
            DateTime dateTime = new DateTime(1970, 1, 1);
            dateTime = dateTime.AddMonths(inputMessage.LoanDuration);

            LoanRequest loanRequest = new LoanRequest
            {
                ssn = inputMessage.Ssn.Replace("-", ""),
                creditScore = inputMessage.CreditScore,
                loanAmount = inputMessage.LoanAmount,
                loanDuration = dateTime.ToString("s", System.Globalization.CultureInfo.InvariantCulture).Replace("T", " ") + ".0 CET"
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LoanRequest));

            var xmlObject = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xmlSerializer.Serialize(writer, loanRequest);
                    xmlObject = sww.ToString();
                }
            }

            bool success = RabbitMq.RabbitMq.Input("", xmlObject, "cphbusiness.bankXML", "PBAG3_Normalizer");
        }
    }

    public class LoanRequest
    {
        public string ssn { get; set; }
        public int creditScore { get; set; }
        public double loanAmount { get; set; }
        public string loanDuration { get; set; }
    }
}
