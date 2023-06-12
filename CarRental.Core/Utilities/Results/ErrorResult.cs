using CarRental.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Utilities.Results
{
    public class ErrorResult: Result
    {

        public ErrorResult(string message, bool success = false, ResultCodes resultCodes = ResultCodes.HTTP_InternalServerError, int resultCount = 0) : base(message, success, resultCodes, resultCount)
        {
        }
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }

}
