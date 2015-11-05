using System;
using System.Configuration;
using System.Web;
using Twilio;
using Twilio.TwiML;

namespace ClickToCall.Web.Domain.Services
{
    public class TwilioRequestValidatorService : ITwilioRequestValidatorService
    {
        private static readonly Lazy<RequestValidator> TwilioRequestValidator = new Lazy<RequestValidator>(() => new RequestValidator());

        public bool ValidateCurrentRequest(HttpContext context, string authToken)
        {
            return TwilioRequestValidator.Value.IsValidRequest(context, authToken);
        }
    }
}