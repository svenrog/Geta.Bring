using System;
using System.Collections.Generic;

namespace Geta.Bring.Booking.Dtos
{
    internal class BookingResponse
    {
        public IEnumerable<Consignment> Consignments { get; set; }

        public class Consignment
        {
            public string CorrelationId { get; set; }
            public Confirmation Confirmation { get; set; }
            public IEnumerable<Error> Errors { get; set; }
        }

        public class Confirmation
        {
            public string ConsignmentNumber { get; set; }
            public Links Links { get; set; }
            public DateAndTimes DateAndTimes { get; set; }
            public IEnumerable<Package> Packages { get; set; }
        }

        public class Links
        {
            public Uri Labels { get; set; }
            public Uri Tracking { get; set; }
        }

        public class DateAndTimes
        {
            public DateTime? EarliestPickup { get; set; }
            public DateTime? ExpectedDelivery { get; set; }
        }

        public class Package
        {
            public string CorrelationId { get; set; }
            public string PackageNumber { get; set; }
        }

        public class Error
        {
            public string UniqueId { get; set; }
            public string Code { get; set; }
            public IEnumerable<ErrorMessage> Messages { get; set; }
        }

        public class ErrorMessage
        {
            public string Lang { get; set; }
            public string Message { get; set; }
        }
    }
}