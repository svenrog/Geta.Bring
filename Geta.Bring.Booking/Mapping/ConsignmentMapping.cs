using System.Collections.Generic;
using Geta.Bring.Booking.Dtos;
using Geta.Bring.Booking.Model;

namespace Geta.Bring.Booking.Mapping
{
    internal static class ConsignmentMapping
    {
        public static BookingRequest ToRequest(this IEnumerable<Consignment> consignments, bool test = false)
        {
            return new BookingRequest
            {
                SchemaVersion = 1,
                TestIndicator = test,
                Consignments = consignments
            };
        }
    }
}