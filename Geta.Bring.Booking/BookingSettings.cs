using System;

namespace Geta.Bring.Booking
{
    /// <summary>
    /// Settings for <see cref="BookingClient"/>.
    /// </summary>
    public class BookingSettings
    {
        public string Uid { get; private set; }
        public string Key { get; private set; }
        public Uri ClientUri { get; private set; }
        public Uri EndpointUri { get; private set; }
        public bool IsTest { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="BookingSettings"/> with default endpoint URI: https://api.bring.com/booking/api/booking .
        /// </summary>
        /// <param name="uid">Booking API User ID.</param>
        /// <param name="key">Booking API Key.</param>
        /// <param name="clientUri">The URI of client Web site.</param>
        /// <param name="isTest">Mark if test mode in use.</param>
        public BookingSettings(string uid, string key, Uri clientUri, bool isTest = false)
            : this(uid, key, clientUri, new Uri("https://api.bring.com/booking/api/booking"), isTest) { }

        /// <summary>
        /// Initializes new instance of <see cref="BookingSettings"/>.
        /// </summary>
        /// <param name="uid">Booking API User ID.</param>
        /// <param name="key">Booking API Key.</param>
        /// <param name="clientUri">The URI of client Web site.</param>
        /// <param name="endpointUri">The URI of Bring Booking API endpoint.</param>
        /// <param name="isTest">Mark if test mode in use.</param>
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