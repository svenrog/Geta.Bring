using System;

namespace Geta.Bring.Tracking
{
    public class TrackingSettings
    {
        public TrackingSettings(Uri endpointUri)
        {
            if (endpointUri == null) throw new ArgumentNullException("endpointUri");
            EndpointUri = endpointUri;
        }

        public Uri EndpointUri { get; private set; }
    }
}