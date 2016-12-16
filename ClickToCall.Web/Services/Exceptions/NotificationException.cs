using System;

namespace ClickToCall.Web.Services.Exceptions
{
    public class NotificationException : Exception
    {
        public NotificationException(string message) : base(message)
        {
        }
    }
}
