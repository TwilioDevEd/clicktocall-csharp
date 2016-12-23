using System;
using System.Configuration;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ClickToCall.Web.Services
{
    public interface INotificationService
    {
        void MakePhoneCall(string from, string to, string uriHandler);
    }

    public class NotificationService : INotificationService
    {
        private readonly TwilioRestClient _client;

        public NotificationService()
        {
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSID"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            _client = new TwilioRestClient(accountSid, authToken);
        }

        public void MakePhoneCall(string from, string to, string uriHandler)
        {
            CallResource.Create(
                new PhoneNumber(to), new PhoneNumber(from), url: new Uri(uriHandler), client: _client);
        }
    }

}
