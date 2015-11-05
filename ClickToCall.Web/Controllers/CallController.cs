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