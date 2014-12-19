using System;
using System.Collections.Generic;

namespace Geta.Bring.Tracking.Model
{
    /// <summary>
    /// Package consignment status.
    /// </summary>
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

        /// <summary>
        /// Consignment ID.
        /// </summary>
        public string ConsignmentId { get; private set; }
        
        /// <summary>
        /// Previous consignment ID.
        /// </summary>
        public string PreviousConsignmentId { get; private set; }

        /// <summary>
        /// Total weight in kilograms.
        /// </summary>
        public double TotalWeightInKgs { get; private set; }

        /// <summary>
        /// Total volume in dm3.
        /// </summary>
        public double TotalVolumeInDm3 { get; private set; }

        /// <summary>
        /// List of package statuses.
        /// </summary>
        public IEnumerable<PackageStatus> PackageSet { get; private set; }

    }
}