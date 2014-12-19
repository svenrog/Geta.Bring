using System;

namespace Geta.Bring.Booking.Model
{
    /// <summary>
    /// Sender and recipient party information.
    /// </summary>
    public class Parties
    {
        /// <summary>
        /// Initializes new instance of <see cref="Parties"/>.
        /// </summary>
        /// <param name="sender">Package sender.</param>
        /// <param name="recipient">Package recipient.</param>
        public Parties(Party sender, Party recipient)
        {
            if (sender == null) throw new ArgumentNullException("sender");
            if (recipient == null) throw new ArgumentNullException("recipient");
            Recipient = recipient;
            Sender = sender;
        }

        /// <summary>
        /// Package sender. 
        /// </summary>
        public Party Sender { get; private set; }

        /// <summary>
        /// Package recipient.
        /// </summary>
        public Party Recipient { get; private set; }
    }
}