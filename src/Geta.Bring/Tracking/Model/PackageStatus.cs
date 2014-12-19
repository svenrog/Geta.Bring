using System;
using System.Collections.Generic;

namespace Geta.Bring.Tracking.Model
{
    /// <summary>
    /// Package status.
    /// </summary>
    public class PackageStatus
    {
        public PackageStatus(
            string statusDescription, 
            string packageNumber, 
            string previousPackageNumber, 
            string productName, 
            string productCode, 
            string brand, 
            int lengthInCm, 
            int widthInCm, 
            int heightInCm, 
            double volumeInDm3, 
            double weightInKgs, 
            string pickupCode, 
            string dateOfReturn, 
            string senderName, 
            Address recipientAddress, 
            IEnumerable<TrackingEvent> eventSet)
        {
            if (statusDescription == null) throw new ArgumentNullException("statusDescription");
            if (packageNumber == null) throw new ArgumentNullException("packageNumber");
            if (previousPackageNumber == null) throw new ArgumentNullException("previousPackageNumber");
            if (productName == null) throw new ArgumentNullException("productName");
            if (productCode == null) throw new ArgumentNullException("productCode");
            if (brand == null) throw new ArgumentNullException("brand");
            if (eventSet == null) throw new ArgumentNullException("eventSet");
            EventSet = eventSet;
            RecipientAddress = recipientAddress ?? Address.Empty;
            SenderName = senderName;
            DateOfReturn = dateOfReturn;
            PickupCode = pickupCode;
            WeightInKgs = weightInKgs;
            VolumeInDm3 = volumeInDm3;
            HeightInCm = heightInCm;
            WidthInCm = widthInCm;
            LengthInCm = lengthInCm;
            Brand = brand;
            ProductCode = productCode;
            ProductName = productName;
            PreviousPackageNumber = previousPackageNumber;
            PackageNumber = packageNumber;
            StatusDescription = statusDescription;
        }

        /// <summary>
        /// Status description.
        /// </summary>
        public string StatusDescription { get; private set; }

        /// <summary>
        /// Package number.
        /// </summary>
        public string PackageNumber { get; private set; }

        /// <summary>
        /// Previous package number.
        /// </summary>
        public string PreviousPackageNumber { get; private set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string ProductName { get; private set; }

        /// <summary>
        /// Product code.
        /// </summary>
        public string ProductCode { get; private set; }

        /// <summary>
        /// Brand name.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Length of the package in cm.
        /// </summary>
        public int LengthInCm { get; private set; }

        /// <summary>
        /// Width of the package in cm.
        /// </summary>
        public int WidthInCm { get; private set; }

        /// <summary>
        /// Height of the package in cm.
        /// </summary>
        public int HeightInCm { get; private set; }

        /// <summary>
        /// Volume of the package in dm3.
        /// </summary>
        public double VolumeInDm3 { get; private set; }

        /// <summary>
        /// Weight of the package in kilograms.
        /// </summary>
        public double WeightInKgs { get; private set; }

        /// <summary>
        /// Pickup code.
        /// </summary>
        public string PickupCode { get; private set; }

        /// <summary>
        /// Formatted date of return.
        /// </summary>
        public string DateOfReturn { get; private set; }

        /// <summary>
        /// Sender name.
        /// </summary>
        public string SenderName { get; private set; }

        /// <summary>
        /// Recipient address.
        /// </summary>
        public Address RecipientAddress { get; private set; }

        /// <summary>
        /// List of the tracking events.
        /// </summary>
        public IEnumerable<TrackingEvent> EventSet { get; private set; }
    }
}