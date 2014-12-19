using System;
using System.Collections.Generic;

namespace Geta.Bring.Booking.Model
{
    public class Error
    {
        public Error(string uniqueId, string code, IEnumerable<ErrorMessage> messages)
        {
            if (uniqueId == null) throw new ArgumentNullException("uniqueId");
            if (code == null) throw new ArgumentNullException("code");
            if (messages == null) throw new ArgumentNullException("messages");
            Messages = messages;
            Code = code;
            UniqueId = uniqueId;
        }

        public string UniqueId { get; private set; }
        public string Code { get; private set; }
        public IEnumerable<ErrorMessage> Messages { get; private set; }
    }
}