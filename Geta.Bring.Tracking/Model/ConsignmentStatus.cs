using System;
using System.Collections.Generic;

namespace Geta.Bring.Tracking.Model
{
    public class ConsignmentStatus
    {
        public ConsignmentStatus(
            string consignmentId, 
            string previousConsignmentId, 
            double totalWeightInKgs, 
            double totalVolumeInDm3, 
            IEnumerable<PackageStatus> packageSet)
        {
            if (consignmentId == null) throw new ArgumentNullException("consignmentId");
            if (previousConsignmentId == null) throw new ArgumentNullException("previousConsignmentId");
            if (packageSet == null) throw new ArgumentNullException("packageSet");
            PackageSet = packageSet;
            TotalVolumeInDm3 = totalVolumeInDm3;
            TotalWeightInKgs = totalWeightInKgs;
            PreviousConsignmentId = previousConsignmentId;
            ConsignmentId = consignmentId;
        }

        public string ConsignmentId { get; private set; }
        public string PreviousConsignmentId { get; private set; }
        public double TotalWeightInKgs { get; private set; }
        public double TotalVolumeInDm3 { get; private set; }
        public IEnumerable<PackageStatus> PackageSet { get; private set; }

    }
}