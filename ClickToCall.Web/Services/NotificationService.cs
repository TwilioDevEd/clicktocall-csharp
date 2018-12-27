using System;
using System.Configuration;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ClickToCall.Web.Services
{
    public interface INotificationService
    {
        Task<CallResource> MakePhoneCallAsync(string to, string from, string uriHandler);
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

        public async Task<CallResource> MakePhoneCallAsync(string to, string from, string uriHandler)
        {
            return await CallResource.CreateAsync(
                    new PhoneNumber(to), new PhoneNumber(from), url: new Uri(uriHandler), client: _client,record:true);
        }
    }

}
