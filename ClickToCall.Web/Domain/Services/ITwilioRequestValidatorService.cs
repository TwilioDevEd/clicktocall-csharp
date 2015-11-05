using System.Web;

namespace ClickToCall.Web.Domain.Services
{
    public interface ITwilioRequestValidatorService
    {
        bool ValidateCurrentRequest(HttpContext context, string authToken);
    }
}