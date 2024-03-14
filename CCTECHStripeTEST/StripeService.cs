using System;
using Stripe;
namespace CCTECHStripeTEST
{
	public class StripeService
	{
		private readonly StripeClient _stripeClient;

		public StripeService()
		{
			_stripeClient = new StripeClient("sk_test_51OrLO8Rq3xShrsxlJiSjvPjtHYapSWs18z3CaVhvos3ZPPdJ7Hdcsztc04UoBB1zPWsC2JpxFJ3Ny8A30NTiiCWE005z658TNa");

		}

		public string GenerateClientSecret(int amount, string currency)
		{
			var options = new PaymentIntentCreateOptions
			{
				Amount = amount,
				Currency = currency,
				PaymentMethodTypes = new List<string> { "card" }
			};

			var service = new PaymentIntentService(_stripeClient);
			var paymentIntent = service.Create(options);


			return paymentIntent.ClientSecret;
		}
	}
}

