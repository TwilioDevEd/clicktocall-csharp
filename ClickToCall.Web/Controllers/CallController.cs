using System.Configuration;
using System.Web.Mvc;
using ClickToCall.Web.Domain.Services;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace ClickToCall.Web.Controllers
{
    public class CallController : TwilioController
    {
        private readonly ITwilioRequestValidatorService _twilioRequestValidatorService;

        public CallController():this(new TwilioRequestValidatorService())
        {
            // This parameterless constructor with high coupling is done in order to keep the tutorial simple, 
            // and not using a DI COntainer wich is a better approach
        }

        public CallController(ITwilioRequestValidatorService twilioRequestValidatorService)
        {
            _twilioRequestValidatorService = twilioRequestValidatorService;
        }

        [HttpPost]
        public ActionResult Connect()
        {
            var twilioAuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            if (!_twilioRequestValidatorService.ValidateCurrentRequest(System.Web.HttpContext.Current, twilioAuthToken))
                return new HttpUnauthorizedResult();

            var response = new TwilioResponse();
            response.Say("If this were a real click to call implementation, " +
                         "you would be connected to an agent at this point.");
            response.Hangup();

            return TwiML(response);
        }
    }
}