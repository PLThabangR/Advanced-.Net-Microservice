using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapper.Exceptions
{
    //We inherit Exception
    public class CustomValidationException:Exception
    {
        public  List<string> ErrorMessages { get; set; }
        public string FriendlyErrorMessage { get; set; }
        public  HttpStatusCode StatusCode { get; set; }

        public CustomValidationException(string friendlyErrorMessage,List<string> errorMessages=default, HttpStatusCode statusCode=HttpStatusCode.BadRequest)
        {
            ErrorMessages = errorMessages;
            FriendlyErrorMessage = friendlyErrorMessage;
            StatusCode = statusCode;
        }

    }
}
