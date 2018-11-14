using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleBase
{
    class RuleBaseService
    {
        @WebService(serviceName = "GetBankWebServices")
public class CreditScoreWebService
        {

            @WebMethod(operationName = "getBankRules")
    public byte[] getCreditScore(@WebParam(name = "creditScore") int creditScore) {
        System.out.println("\n{RuleBase} -- getCreditScore");
            System.out.println("Received message (credit score): " + creditScore);
            AllBanks service = new AllBanks();
            HashMap bankResults = service.getBanksByCreditScore(creditScore);
        return SerializationUtils.serialize((Serializable) bankResults);
    }
    }
}
