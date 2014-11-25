using System;

namespace Geta.Bring.Booking.Model
{
    public class ErrorMessage
    {
        public ErrorMessage(string lang, string message)
        {
            if (lang == null) throw new ArgumentNullException("lang");
            if (message == null) throw new ArgumentNullException("message");
            Message = message;
            Lang = lang;
        }

        public string Lang { get; private set; }
        public string Message { get; private set; }
    }
}