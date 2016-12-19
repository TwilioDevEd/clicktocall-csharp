using System.Web;
using Twilio.TwiML;

namespace ClickToCall.Web.Services
{
    public interface IRequestValidationService
    {
        bool IsValidRequest(HttpContext context, string authToken);
    }

    public class RequestValidationService : IRequestValidationService
    {
        private readonly RequestValidator _requestValidator;

        public RequestValidationService()
        {
            _requestValidator = new RequestValidator();
        }

        public bool IsValidRequest(HttpContext context, string authToken)
        {
            return _requestValidator.IsValidRequest(context, authToken);
        }
    }
}
