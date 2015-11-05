namespace ClickToCall.Web.Services
{
    public interface ITwilioService
    {
        void CallToNumber(string originNumber, string destinationNumber, string handlerUri);
    }
}