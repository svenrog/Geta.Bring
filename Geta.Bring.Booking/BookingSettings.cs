using System;

namespace Geta.Bring.Booking
{
    public class BookingSettings
    {
        public string Uid { get; private set; }
        public string Key { get; private set; }
        public Uri ClientUri { get; private set; }
        public Uri EndpointUri { get; private set; }
        public bool IsTest { get; private set; }

        public BookingSettings(string uid, string key, Uri clientUri, bool test = false)
            : this(uid, key, clientUri, new Uri("https://api.bring.com/booking/api/booking"), test) { }

        public BookingSettings(string uid, string key, Uri clientUri, Uri endpointUri, bool isTest = false)
        {
            if (uid == null) throw new ArgumentNullException("uid");
            if (key == null) throw new ArgumentNullException("key");
            if (clientUri == null) throw new ArgumentNullException("clientUri");
            if (endpointUri == null) throw new ArgumentNullException("endpointUri");

            Uid = uid;
            Key = key;
            ClientUri = clientUri;
            EndpointUri = endpointUri;
            IsTest = isTest;
        }
    }
}