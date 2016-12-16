using System.Configuration;
using System.Web.Mvc;
using ClickToCall.Web.Services;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace ClickToCall.Web.Controllers
{
    public class CallController : TwilioController
    {
        private readonly IRequestValidationService _requestValidationService;

        public CallController() : this(new RequestValidationService())
        {
        }

        public CallController(IRequestValidationService requestValidationService)
        {
            _requestValidationService = requestValidationService;
        }

        [HttpPost]
        public ActionResult Connect()
        {
            var twilioAuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            if (!_requestValidationService.IsValidRequest(System.Web.HttpContext.Current, twilioAuthToken))
            {
                return new HttpUnauthorizedResult();
            }

            var response = new TwilioResponse();
            response.Say("If this were a real click to call implementation, " +
                         "you would be connected to an agent at this point.");
            response.Hangup();

            return TwiML(response);
        }
    }
}
