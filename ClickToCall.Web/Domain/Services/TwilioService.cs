using System;
using System.Configuration;
using System.Security.Policy;
using System.Web.WebSockets;
using Twilio;

namespace ClickToCall.Web.Domain.Services
{
    public class TwilioService : ITwilioService
    {
        private static Lazy<TwilioRestClient> _twilioOutClient 
            = new Lazy<TwilioRestClient>(() => new TwilioRestClient(ConfigurationManager.AppSettings["TwilioAccountSID"], ConfigurationManager.AppSettings["TwilioAuthToken"]));

        public void CallToNumber(string originNumber, string destinationNumber, string handlerUri)
        {
            _twilioOutClient.Value.InitiateOutboundCall(originNumber, destinationNumber, handlerUri);
        }
    }
}