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

        /// <summary>
        /// This parameterless with high coupling is done in order to keep the tutorial simple, 
        /// and not using a Dependency Injection which is the right approach
        /// </summary>
        public CallCenterController()
        {
            _twilioService = new TwilioService();
        }


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