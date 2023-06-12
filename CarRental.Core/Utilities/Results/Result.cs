using CarRental.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(string message, bool success, ResultCodes resultCodes, int resultCount)
        {
            Success = success;
            Message = message;
            ResultCount = resultCount;
            ResultCode = (int)resultCodes;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }

        public int ResultCount { get; set; }
        public int ResultCode { get; set; }
    }
}
