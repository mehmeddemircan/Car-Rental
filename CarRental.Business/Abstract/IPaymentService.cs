using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IPaymentService
    {

        Task<string> CreatePaymentIntentAsync(int amount);
    }
}
