using System.Collections.Generic;
using System.Threading.Tasks;
using Geta.Bring.Booking.Model;

namespace Geta.Bring.Booking
{
    /// <summary>
    /// Bring Booking API.
    /// </summary>
    public interface IBookingClient
    {
        /// <summary>
        /// Single consignment booking.
        /// </summary>
        /// <param name="consignment">Consignment to book.</param>
        /// <returns>Booking confirmation.</returns>
        Task<Confirmation> BookAsync(Consignment consignment);

        /// <summary>
        /// Multiple consignment booking.
        /// </summary>
        /// <param name="consignments">List of consignments.</param>
        /// <returns>List of booking confirmations.</returns>
        Task<IEnumerable<Confirmation>> BookAsync(IEnumerable<Consignment> consignments);
    }
}