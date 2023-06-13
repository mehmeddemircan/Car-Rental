using CarRental.Business.Abstract;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public async Task<string> CreatePaymentIntentAsync(int amount)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = amount * 100,
                Currency = "try",
                Description = "Payment for your service"
            };

            var service = new PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);

            return paymentIntent.ClientSecret;
        }
    }
}
