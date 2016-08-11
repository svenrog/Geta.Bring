using System.Threading.Tasks;
using Geta.Bring.Pickup.Model;

namespace Geta.Bring.Pickup
{
    /// <summary>
    /// Bring Pickup Point API.
    /// </summary>
    public interface IPickupClient
    {
        /// <summary>
        /// Finds pickup points based on country and zipcode.
        /// </summary>
        /// <param name="query">Query parameters of type <see cref="PickupZipCodeQuery"/>.</param>
        /// <returns>A list of matching <see cref="PickupPoint"/></returns>
        Task<PickupResult> FindByZipCode(PickupZipCodeQuery query);

        /// <summary>
        /// Finds pickup points based on country and geolocation.
        /// </summary>
        /// <param name="query">Query parameters of type <see cref="PickupLocationQuery"/>.</param>
        /// <returns>A list of matching <see cref="PickupPoint"/></returns>
        Task<PickupResult> FindByLocation(PickupLocationQuery query);

        /// <summary>
        /// Finds pickup points based on country and Bring id.
        /// </summary>
        /// <param name="countryCode">Country code, ISO 2 letter, allowed values: NO, DK, SE, FI</param>
        /// <param name="id">Identifier in Bring</param>
        /// <returns>A list of matching <see cref="PickupPoint"/></returns>
        Task<PickupResult> FindById(string countryCode, string id);

        /// <summary>
        /// Lists all pickup points for a country.
        /// </summary>
        /// <param name="countryCode">Country code, ISO 2 letter, allowed values: NO, DK, SE, FI</param>
        /// <returns>A list of all <see cref="PickupPoint"/></returns>
        Task<PickupResult> All(string countryCode);
    }
}