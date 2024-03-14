using System;
using Microsoft.AspNetCore.Mvc;

namespace CCTECHStripeTEST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly StripeService _stripeService;

        public PaymentController(StripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("create-payment-intent")]
        public ActionResult CreatePaymentIntent(int amount, string currency)
        {
            try
            {
                var clientSecret = _stripeService.GenerateClientSecret(amount, currency);
                return Ok(new { clientSecret });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to create payment intent.", error = ex.Message });
            }
        }
    }
}
