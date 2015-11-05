namespace ClickToCall.Web.Domain.Services
{
    public interface ITwilioService
    {
        void CallToNumber(string originNumber, string destinationNumber, string handlerUri);
    }
}