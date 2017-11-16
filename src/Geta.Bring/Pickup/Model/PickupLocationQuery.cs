namespace Geta.Bring.Pickup.Model
{
    public class PickupLocationQuery : PickupQuery
    {
        /// <summary>
        /// Geographic coordinate specifying the north-south position.
        /// </summary>
        public readonly double Latitude;

        /// <summary>
        /// Geographic coordinate specifying the east-west position.
        /// </summary>
        public readonly double Longitude;

        /// <summary>
        /// A set of query parameters with location for the Pickup Point API
        /// </summary>
        /// <param name="countryCode">Country code, ISO 2 letter, allowed values: NO, DK, SE, FI</param>
        /// <param name="latitude">Geographic coordinate specifying the north-south position.</param>
        /// <param name="longitude">Geographic coordinate specifying the east-west position.</param>
        /// <param name="queryParameters">Query parameters</param>
        public PickupLocationQuery(string countryCode, double latitude, double longitude, params IPickupQueryParameter[] queryParameters) : base(countryCode, queryParameters)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}