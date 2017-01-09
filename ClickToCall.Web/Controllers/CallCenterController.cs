using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ClickToCall.Web.Models;
using ClickToCall.Web.Services;

namespace ClickToCall.Web.Controllers
{
    public class CallCenterController : Controller
    {
        private readonly INotificationService _notificationService;
        private const string OriginHeader = "Origin";

        public CallCenterController() : this(new NotificationService())
        {
        }

        public CallCenterController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handle a POST from our web form and connect a call via REST API
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Call(CallViewModel callViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                var errorMessage = string.Join(". ", errors);
                return Json(new { success = false, message = errorMessage });
            }

            var twilioNumber = ConfigurationManager.AppSettings["TwilioNumber"];
            var uriHandler = GetUri(callViewModel.SalesNumber);
            await _notificationService.MakePhoneCallAsync(callViewModel.UserNumber, twilioNumber, uriHandler);

            return Json(new { success = true, message = "Phone call incoming!"});
        }

        private string GetUri(string salesNumber)
        {
            if (IsProduction())
            {
                return Url.Action("Connect", "Call", null, Request.Url.Scheme);
            }

            var urlAction = Url.Action("Connect", "Call", new { salesNumber });

            var origin = Request.Headers[OriginHeader];
            return $"{origin}{urlAction}";
        }

        private bool IsProduction()
        {
            var origin = Request.Headers[OriginHeader];
            return !new List<string> {"ngrok.io", "localhost"}.Any(domain => origin.Contains(domain));
        }
    }
}
