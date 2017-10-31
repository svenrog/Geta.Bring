using System;

namespace Geta.Bring.Pickup.Model
{
    public class PickupZipCodeQuery : PickupQuery
    {
        /// <summary>
        /// Postal code.
        /// </summary>
        public readonly string ZipCode;

        /// <summary>
        /// A set of query parameters with location for the Pickup Point API
        /// </summary>
        /// <param name="countryCode">Country code, ISO 2 letter, allowed values: NO, DK, SE, FI</param>
        /// <param name="zipCode">Postal code.</param>
        /// <param name="queryParameters">Query parameters</param>
        public PickupZipCodeQuery(string countryCode, string zipCode, params IPickupQueryParameter[] queryParameters) : base(countryCode, queryParameters)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("zipCode must be set");

            ZipCode = zipCode;
        }

    }
}