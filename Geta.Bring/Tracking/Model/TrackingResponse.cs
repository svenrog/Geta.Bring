using System;
using System.Collections.Generic;

namespace Geta.Bring.Tracking.Model
{
    internal class TrackingResponse
    {
        public TrackingResponse(IEnumerable<ConsignmentStatus> consignmentSet)
        {
            if (consignmentSet == null) throw new ArgumentNullException("consignmentSet");
            ConsignmentSet = consignmentSet;
        }

        public IEnumerable<ConsignmentStatus> ConsignmentSet { get; private set; }
    }
}