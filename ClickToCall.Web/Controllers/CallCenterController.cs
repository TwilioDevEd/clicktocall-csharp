using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using ClickToCall.Web.Services;
using ClickToCall.Web.Models;
using Twilio.TwiML.Mvc;

namespace ClickToCall.Web.Controllers
{
    public class CallCenterController : TwilioController
    {
        private readonly INotificationService _twilioService;

        public CallCenterController() : this(new NotificationService())
        {
        }

        public CallCenterController(INotificationService twilioService)
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
                var errorMessage = ModelState.Values.First().Errors.First().ErrorMessage;
                return Json(new { success = false, message = errorMessage });
            }

            var twilioNumber = ConfigurationManager.AppSettings["TwilioNumber"];
            var handlerUri = GetUri();
            _twilioService.MakePhoneCall(twilioNumber, contact.Phone.Replace(" ", ""), handlerUri);

            return Json(new { success = true, message = "Phone call incoming!"});
        }

        private string GetUri(bool isProduction = false)
        {
            // "isProduction" means that it is not exposed to the wider internet through ngrok.
            if (isProduction)
            {
                return Url.Action("Connect", "Call", null, Request.Url.Scheme);
            }

            var requestUrlScheme = Request.Url.Scheme;
            var domain = ConfigurationManager.AppSettings["TestDomain"];
            var urlAction = Url.Action("Connect", "Call");

            return $"{requestUrlScheme}://{domain}{urlAction}";
        }
    }
}
