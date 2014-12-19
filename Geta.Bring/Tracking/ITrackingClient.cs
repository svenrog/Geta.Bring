using System.Collections.Generic;
using System.Threading.Tasks;
using Geta.Bring.Tracking.Model;

namespace Geta.Bring.Tracking
{
    /// <summary>
    /// Bring Tracking API.
    /// </summary>
    public interface ITrackingClient
    {
        /// <summary>
        /// Returns tracking information.
        /// </summary>
        /// <param name="trackingNumber">Tracking number.</param>
        /// <returns>List of package consignment statuses. See more: <see cref="ConsignmentStatus"/>.</returns>
        Task<IEnumerable<ConsignmentStatus>> TrackAsync(string trackingNumber);
    }
}