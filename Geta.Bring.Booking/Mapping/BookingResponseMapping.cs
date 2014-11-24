using System.Collections.Generic;
using Geta.Bring.Booking.Dtos;
using Geta.Bring.Booking.Model;

namespace Geta.Bring.Booking.Mapping
{
    internal static class BookingResponseMappingExtensions
    {
        public static IEnumerable<Confirmation> ToConfirmation(this BookingResponse response)
        {
            // TODO: create confirmations from booking response
            return null;
        }
    }
}