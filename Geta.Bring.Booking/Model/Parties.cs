using System;

namespace Geta.Bring.Booking.Model
{
    public class Parties
    {
        public Parties(Party sender, Party recipient)
        {
            if (sender == null) throw new ArgumentNullException("sender");
            if (recipient == null) throw new ArgumentNullException("recipient");
            Recipient = recipient;
            Sender = sender;
        }

        public Party Sender { get; private set; }
        public Party Recipient { get; private set; }
    }
}