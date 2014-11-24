using System.Collections.Generic;
using Geta.Bring.Booking.Model;

namespace Geta.Bring.Booking.Dtos
{
    internal class BookingRequest
    {
        public bool TestIndicator { get; set; }
        public int SchemaVersion { get; set; }
        public IEnumerable<Consignment> Consignments { get; set; }
    }
}