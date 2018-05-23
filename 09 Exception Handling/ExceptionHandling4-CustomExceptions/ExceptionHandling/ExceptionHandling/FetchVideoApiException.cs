using System;

namespace ExceptionHandling
{
    public class FetchVideoApiException : Exception
    {
        public FetchVideoApiException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
