using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClickToCall.Web.Services;

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

        public ViewResult Connect()
        {
            throw new NotImplementedException();
        }
    }
}