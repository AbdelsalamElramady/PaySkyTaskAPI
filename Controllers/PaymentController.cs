using PaySkyTaskAPI.Models.Payment;

namespace PaySkyTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly PaymentGatewayService _paymentGatewayService;

        public PaymentController(ILogger<PaymentController> logger, PaymentGatewayService paymentGatewayService)
        {
            _logger = logger;
            _paymentGatewayService = paymentGatewayService;
        }

        [HttpPost("pay")]
        public ActionResult<PayResponse> Pay(PayRequest payRequest)
        {
            var approvalCode = _paymentGatewayService.GetApprovalCode(payRequest);
            var response = new PayResponse(ResponseMessage.Success, ResponseCode.Success, approvalCode);

            return Ok(response);
        }
    }
}
