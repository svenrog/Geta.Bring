using System.Threading.Tasks;
using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Shipping
{
    /// <summary>
    /// Bring Shipping Guide API.
    /// </summary>
    public interface IShippingClient
    {
        /// <summary>
        /// Finds Bring Shipping estimates based on estimate query.
        /// </summary>
        /// <typeparam name="T">Type of estimates <see cref="IEstimate"/>.</typeparam>
        /// <param name="query">Query parameters of type <see cref="EstimateQuery"/>.</param>
        /// <returns></returns>
        Task<EstimateResult<T>> FindAsync<T>(EstimateQuery query) where T : IEstimate;
    }
}
