using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestBank.Controllers
{
    public class ValuesController : ApiController
    {
        double interestRate = 2;

        // GET api/values/
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/:loanamount/:loanduration
        public string Get(double loanamount, int loanduration)
        {
            interestRate = interestRate * ((loanduration * 0.3) + (loanamount / 2)); 
            return interestRate.ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
