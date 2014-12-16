using System.Threading.Tasks;
using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Shipping
{
    public interface IShippingClient
    {
        Task<EstimateResult<T>> FindAsync<T>(EstimateQuery query) where T : IEstimate;
    }
}
