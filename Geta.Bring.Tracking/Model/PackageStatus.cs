using System;
using System.Collections.Generic;

namespace Geta.Bring.Tracking.Model
{
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

        public string StatusDescription { get; private set; }
        public string PackageNumber { get; private set; }
        public string PreviousPackageNumber { get; private set; }
        public string ProductName { get; private set; }
        public string ProductCode { get; private set; }
        public string Brand { get; private set; }
        public int LengthInCm { get; private set; }
        public int WidthInCm { get; private set; }
        public int HeightInCm { get; private set; }
        public double VolumeInDm3 { get; private set; }
        public double WeightInKgs { get; private set; }
        public string PickupCode { get; private set; }
        public string DateOfReturn { get; private set; }
        public string SenderName { get; private set; }
        public Address RecipientAddress { get; private set; }
        public IEnumerable<TrackingEvent> EventSet { get; private set; }
    }
}