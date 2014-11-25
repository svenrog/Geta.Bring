using System;

namespace Geta.Bring.Tracking.Model
{
    internal class TrackingResponse
    {
        public TrackingResponse(ConsignmentStatus consignmentSet)
        {
            if (consignmentSet == null) throw new ArgumentNullException("consignmentSet");
            ConsignmentSet = consignmentSet;
        }

        public ConsignmentStatus ConsignmentSet { get; private set; }
    }
}