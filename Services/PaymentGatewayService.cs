using PaySkyTaskAPI.Models.Payment;
using System.Text.RegularExpressions;

namespace PaySkyTaskAPI.Services
{
    public class PaymentGatewayService
    {
        internal string GetApprovalCode(PayRequest payRequest)
        {
            //send request data to gateway to get approval code
            var approvalCode = new Random().Next(0, 1000000).ToString("D6"); ;

            return approvalCode;
        }
    }
}
