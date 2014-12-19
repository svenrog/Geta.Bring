using System;
using System.Globalization;
using System.Linq;

namespace Geta.Bring.EPi.Commerce.Extensions
{
    internal static class StringExtensions
    {
        public static string ToIso2CountryCode(this string iso3CountryCode, string defaultCode = "NO")
        {
            if (iso3CountryCode == null || iso3CountryCode.Length != 3)
            {
                return defaultCode;
            }

            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            var regionByIso3 = cultures
                .Select(culture => new RegionInfo(culture.LCID))
                .FirstOrDefault(
                    region =>
                        region.ThreeLetterISORegionName.Equals(iso3CountryCode,
                            StringComparison.InvariantCultureIgnoreCase));

            return regionByIso3 == null 
                ? defaultCode 
                : regionByIso3.TwoLetterISORegionName;
        }
    }
}