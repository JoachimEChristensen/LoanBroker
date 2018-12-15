using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Normalizer
{
    [XmlRoot("LoanResponse")]
    public class InputMessage
    {
        [XmlElement("ssn")]
        public string Ssn { get; set; }
        [XmlElement("interestRate")]
        public double interest { get; set; }
        [XmlIgnore]
        public double interestRate { get; set; }
        [XmlIgnore]
        public string ssn { get; set; }
    }
}
