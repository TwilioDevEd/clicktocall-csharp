using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClickToCall.Web.Models;
using ClickToCall.Web.Services;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace ClickToCall.Web.Controllers
{
    public class CallCenterController : Twilio.TwiML.Mvc.TwilioController
    {
        private readonly ITwilioService _twilioService;

        public CallCenterController(ITwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Call(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}