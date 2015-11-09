using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using ClickToCall.Web.Domain.Services;
using ClickToCall.Web.Models;
using Twilio.TwiML.Mvc;

namespace ClickToCall.Web.Controllers
{
    public class CallCenterController : TwilioController
    {
        private readonly ITwilioService _twilioService;

        public CallCenterController(): this(new TwilioService())
        {
            // This parameterless constructor with high coupling is done in order to keep the tutorial simple, 
            // and not using a DI COntainer wich is a better approach
        }

        public CallCenterController(ITwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handle a POST from our web form and connect a call via REST API
        /// </summary>
        [HttpPost]
        public ActionResult Call(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = (ModelState.Values.First()).Errors.First().ErrorMessage, });
            }

            var twilioNumber = ConfigurationManager.AppSettings["TwilioNumber"];

            // The following line is how you should get the absolute Uri in an internet faced 
            // server or a production environment
            // var handlerUri = Url.Action("Connect", "Call", null, Request.Url.Scheme);

            // this line allow us to get the absolute Uri in a local computer using a secure instrospectable 
            // service like ngrok ;)
            var handlerUri = GetTestUri();

            _twilioService.CallToNumber(twilioNumber, contact.Phone.Replace(" ", ""), handlerUri);
            return Json(new { success = true, message = "Phone call incoming!"});
        }

        private string GetTestUri()
        {
            return String.Format("{0}://{1}{2}", 
                Request.Url.Scheme, ConfigurationManager.AppSettings["TestDomain"], Url.Action("Connect", "Call"));
        }
    }
}