using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.AriBilgi.Blog.Shared
{
    public class Result : IResult
    {
        public Result(ResultStatus _resultStatus, string _message, Exception _exception)
        {
            ResultStatus = _resultStatus;
            Message = _message;
            Exception = _exception;
        }
        public Result(ResultStatus _resultStatus, string _message)
        {
            ResultStatus = _resultStatus;
            Message = _message;
        }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
