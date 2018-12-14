using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Translator
{
    static class Rest
    {
        public static async Task SendRequest(InputMessage inputMessage)
        {
            double loanAmount = inputMessage.LoanAmount;
            int loanDuration = inputMessage.LoanDuration;

            try
            {
                string uri = "http://localhost:52577/api/values?loanamount="+ loanAmount.ToString("G", CultureInfo.InvariantCulture) + $"&loanduration={loanDuration}";
                HttpClient client = new HttpClient();
                var content = await client.GetAsync(uri);
                if (content.IsSuccessStatusCode)
                {
                    double interest = JsonConvert.DeserializeObject<double>(await content.Content.ReadAsStringAsync());
                    ServicePoint(uri);

                    string jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(new { inputMessage.Ssn, interest });

                    bool success = RabbitMq.RabbitMq.Input("PBAG3_Normalizer", jsonObject);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The request for a quote failed because of: " + e.Message);
            }
        }

        private static void ServicePoint(string uri)
        {
            var servicePoint = ServicePointManager.FindServicePoint(new Uri(uri));
            servicePoint.ConnectionLeaseTimeout = 60 * 1000;
        }
    }
}
