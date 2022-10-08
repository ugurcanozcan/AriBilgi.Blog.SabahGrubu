using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.AriBilgi.Blog.Shared
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(T data, ResultStatus resultStatus, string message, Exception exception)
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }
        public DataResult(T data, ResultStatus resultStatus, string message)
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
        }
        public DataResult(T data, ResultStatus resultStatus)
        {
            Data = data;
            ResultStatus = resultStatus;
        }

        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
