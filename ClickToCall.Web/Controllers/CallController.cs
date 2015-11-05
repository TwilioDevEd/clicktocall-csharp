using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using ClickToCall.Web.Domain.Services;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace ClickToCall.Web.Controllers
{
    public class CallController : Twilio.TwiML.Mvc.TwilioController
    {
        private readonly ITwilioRequestValidatorService _twilioRequestValidatorService;
        /// <summary>
        /// This parameterless with high coupling is done in order to keep the tutorial simple, 
        /// and not using a Dependency Injection which is the right approach
        /// </summary>
        public CallController()
        {
            _twilioRequestValidatorService = new TwilioRequestValidatorService();
        }


        public CallController(ITwilioRequestValidatorService twilioRequestValidatorService)
        {
            _twilioRequestValidatorService = twilioRequestValidatorService;
        }

        public ActionResult Connect()
        {
            var twilioAuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            if (!_twilioRequestValidatorService.ValidateCurrentRequest(System.Web.HttpContext.Current, twilioAuthToken))
                return new HttpUnauthorizedResult();

            var response = new TwilioResponse();
            response.Say("If this were a real click to call implementation, you would be connected to an agent at this point.");
            response.Hangup();

            return new TwiMLResult(response);
        }
    }
}