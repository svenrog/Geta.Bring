using System;
using System.Threading.Tasks;
using Geta.Bring.Shipping.Model;

namespace Geta.Bring.Shipping
{
    public interface IQueryHandler
    {
        bool CanHandle(Type type);
        Task<IEstimate> FindEstimateAsync(EstimateQuery query);
    }

    public abstract class QueryHandler<T> : IQueryHandler
        where T : IEstimate
    {
        public bool CanHandle(Type type)
        {
            return type == typeof(T);
        }

        public abstract Task<T> FindAsync(EstimateQuery query);

        public async Task<IEstimate> FindEstimateAsync(EstimateQuery query)
        {
            return await FindAsync(query).ConfigureAwait(false);
        }
    }
}