namespace ClickToCall.Web.Domain.Services
{
    public interface ITwilioRequestValidatorService
    {
        bool ValidateCurrentRequest();
    }
}