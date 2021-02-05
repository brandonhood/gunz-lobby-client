using System;
using System.Net;

namespace Gunz.Lobby.Common.CustomExceptions
{
    public class CustomHttpResponseException : Exception
    {
        public CustomHttpResponseException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
