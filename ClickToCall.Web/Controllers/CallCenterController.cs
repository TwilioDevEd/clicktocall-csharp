using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClickToCall.Web.Models;
using ClickToCall.Web.Services;
using Twilio;
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

        /// <summary>
        /// Index or default view, it loads the form for passing the number
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handle a POST from our web form and connect a call via REST API
        /// </summary>
        public JsonResult Call(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = ModelState.Values.First(), });
            }

            var twilioNumber = ConfigurationManager.AppSettings["TwilioNumber"];

            _twilioService.CallToNumber(twilioNumber, contact.Phone, Url.Action("Connect", "Call",null,Request.Url.Scheme));

            return Json(new { success = true, message = "Phone call incoming!"});
        }
    }
}