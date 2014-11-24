using System.Collections.Generic;
using Geta.Bring.Booking.Dtos;

namespace Geta.Bring.Booking.Mapping
{
    internal static class BookingResponseMappingExtensions
    {
        public static IEnumerable<Confirmation> ToConfirmation(this BookingResponse response)
        {
            return null;
        }
    }
}