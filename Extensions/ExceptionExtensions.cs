using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TestCrud.Extensions
{
    static public class ExceptionExtensions
    {
        static public string GetMessage(this Exception exception)
        {
            Exception currentException = exception;
            string currentExceptionMessage = exception.Message;
            while (currentException.InnerException != null)
            {
                currentException = currentException.InnerException;
                currentExceptionMessage += "\r\n" + currentException.Message;
            }
            return currentExceptionMessage;
        }
    }
}
