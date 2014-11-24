using System;

namespace Geta.Bring.Booking
{
    public class BookingSettings
    {
        public string Uid { get; private set; }
        public string Key { get; private set; }
        public Uri ClientUri { get; private set; }
        public Uri BookingEndpointUri { get; private set; }

        public BookingSettings(string uid, string key, Uri clientUri)
            : this(uid, key, clientUri, new Uri("https://api.bring.com/booking/api/booking")) { }

        public BookingSettings(string uid, string key, Uri clientUri, Uri bookingEndpointUri)
        {
            if (uid == null) throw new ArgumentNullException("uid");
            if (key == null) throw new ArgumentNullException("key");
            if (clientUri == null) throw new ArgumentNullException("clientUri");
            if (bookingEndpointUri == null) throw new ArgumentNullException("bookingEndpointUri");

            Uid = uid;
            Key = key;
            ClientUri = clientUri;
            BookingEndpointUri = bookingEndpointUri;
        }
    }
}