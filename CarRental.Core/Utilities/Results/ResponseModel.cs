using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Utilities.Results
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
