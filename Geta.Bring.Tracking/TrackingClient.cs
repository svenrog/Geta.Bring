using System;
using System.Collections.Generic;
using Geta.Bring.Tracking.Model;

namespace Geta.Bring.Tracking
{
    public class TrackingClient
    {
        public TrackingClient(TrackingSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");
            Settings = settings;
        }

        public TrackingSettings Settings { get; private set; }

        public IEnumerable<ConsignmentStatus> Track(string trackingNumber)
        {
            return null;
        }
    }
}