using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VodaPayAuth;
using VodaPayAuth.Domain.Models;

namespace VodacomCSharpAPI.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class VodapayController : ControllerBase
    {
        private IDictionary<string, string> GetRequestHeaders()
        {
            IDictionary<string, string> headers = new Dictionary<string, string>();

            foreach (var (key, value) in Request.Headers)
            {
                headers[key] = value.ToString();
            }

            return headers;
        }

        [HttpPost("/v2/authorizations/applyToken")]
        public string Auth([FromBody] LoginAuthCode body)
        {
            return Authorization.applyToken(body);
        }

        [HttpPost("/v2/payments/pay")]
        public string Pay([FromBody] PaymentRequest body)
        {
            return Authorization.pay(body);
        }

        [HttpPost("/v2/payments/inquiryPayment")]
        public string PaymentInquiry([FromBody] InquiryObject paymentId)
        {
            return Authorization.inquiryPayment(paymentId);
        }

        [HttpPost("/v2/payments/notifyPayment")]
        public string PaymentNotifyInquiry([FromBody] PaymentNotifyBody body)
        {
            string signature = "";
            string requesttime = "";
            IDictionary<string, string> headers = GetRequestHeaders();
            if (headers.ContainsKey("signature"))
            {
                signature = headers["signature"].ToString();
            }

            if (headers.ContainsKey("request-time"))
            {
                requesttime = headers["request-time"].ToString();
            }

            return Authorization.notifyPayment(signature,requesttime,body);
        }

        [HttpPost("/v2/payments/testnotifypayment")]
        public string TestNofifyPayment([FromBody] PaymentNotifyBody body)
        {
            string signature = "";
            string requesttime = "";
            string client_id = "";

            IDictionary<string, string> headers = GetRequestHeaders();
            if (headers.ContainsKey("signature"))
            {
                signature = headers["signature"].ToString();
            }

            if (headers.ContainsKey("request-time"))
            {
                requesttime = headers["request-time"].ToString();
            }

            if (headers.ContainsKey("client-id"))
            {
                client_id = headers["client-id"].ToString();
            }
                
            return "";
        }

        }
}



