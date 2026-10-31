using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper
{
    // this will help to notify the gateway if there is any service down or error somewhere 
    public  class ServiceUnAvailableException:Exception
    {
        public List<string> ErrorMessages { get; set; }
        public string FriendlyErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ServiceUnAvailableException(string friendlyErrorMessage, List<string> errorMessages = default, HttpStatusCode statusCode = HttpStatusCode.ServiceUnavailable)
        {
            ErrorMessages = errorMessages;
            FriendlyErrorMessage = friendlyErrorMessage;
            StatusCode = statusCode;//Service Unavailable 503
        }

    }
}
