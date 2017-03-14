using System.Configuration;
using System.Web.Mvc;
using ClickToCall.Web.Services;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

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
        public ActionResult Connect(string salesNumber)
        {
            var twilioAuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            if (!_requestValidationService.IsValidRequest(System.Web.HttpContext.Current, twilioAuthToken))
            {
                return new HttpUnauthorizedResult();
            }

            var response = new VoiceResponse();
            response
                .Say("Thanks for contacting our sales department. Our " +
                     "next available representative will take your call.")
                .Dial(salesNumber)
                .Hangup();

            return TwiML(response);
        }
    }
}
