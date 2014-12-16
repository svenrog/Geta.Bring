using System;
using System.Collections.Generic;

namespace Geta.Bring.Shipping.Model
{
    public class EstimateResult<T> where T : IEstimate
    {
        public EstimateResult(IEnumerable<T> estimates)
        {
            if (estimates == null) throw new ArgumentNullException("estimates");
            Estimates = estimates;
        }

        public IEnumerable<T> Estimates { get; private set; }
    }
}