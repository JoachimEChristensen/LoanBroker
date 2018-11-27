using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Translator
{
    class Xml
    {
        public void SendRequest()
        {
            //example:
            //< LoanRequest >
            //    < ssn > 12345678 </ ssn >
            //    < creditScore > 685 </ creditScore >
            //    < loanAmount > 1000.0 </ loanAmount >
            //    < loanDuration > 1973 - 01 - 01 01:00:00.0 CET </ loanDuration >
            //</ LoanRequest >

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(/*myObject*/));

            //var subReq = new MyObject();
            //var xml = "";

            //using (var sww = new StringWriter())
            //{
            //    using (XmlWriter writer = XmlWriter.Create(sww))
            //    {
            //        xsSubmit.Serialize(writer, subReq);
            //        xml = sww.ToString(); // Your XML
            //    }
            //}

            //https://stackoverflow.com/questions/4123590/serialize-an-object-to-xml
        }
    }
}
