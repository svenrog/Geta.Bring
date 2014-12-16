using System.Collections.Generic;
using System.Threading.Tasks;
using Geta.Bring.Tracking.Model;

namespace Geta.Bring.Tracking
{
    public interface ITrackingClient
    {
        Task<IEnumerable<ConsignmentStatus>> Track(string trackingNumber);
    }
}