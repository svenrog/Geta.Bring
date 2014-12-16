using System;
using System.Collections.Generic;

namespace Geta.Bring.Shipping.Model
{
    /// <summary>
    /// Estimate result.
    /// </summary>
    /// <typeparam name="T">Estimate type.</typeparam>
    public class EstimateResult<T> where T : IEstimate
    {
        /// <summary>
        /// Initializes new instance of <see cref="EstimateResult{T}"/>.
        /// </summary>
        /// <param name="estimates">List of estimates.</param>
        public EstimateResult(IEnumerable<T> estimates)
        {
            if (estimates == null) throw new ArgumentNullException("estimates");
            Estimates = estimates;
        }

        /// <summary>
        /// List of estimates.
        /// </summary>
        public IEnumerable<T> Estimates { get; private set; }
    }
}