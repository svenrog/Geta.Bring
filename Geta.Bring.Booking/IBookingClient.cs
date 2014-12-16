using System.Collections.Generic;
using System.Threading.Tasks;
using Geta.Bring.Booking.Model;

namespace Geta.Bring.Booking
{
    public interface IBookingClient
    {
        Task<Confirmation> BookAsync(Consignment consignment);
        Task<IEnumerable<Confirmation>> BookAsync(IEnumerable<Consignment> consignments);
    }
}