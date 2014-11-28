using System.Collections.Specialized;
using System.Globalization;

namespace Geta.Bring.Shipping.Model.QueryParameters
{
    public class PackageSize : IQueryParameter
    {
        private PackageSize() { }

        public NameValueCollection Items { get; private set; }

        public static PackageSize InGrams(int grams)
        {
            return new PackageSize
            {
                Items = new NameValueCollection
                {
                    {"weightInGrams", grams.ToString(CultureInfo.InvariantCulture)}
                }
            };
        }

        public static PackageSize InDimensions(int lengthCm, int widthCm, int heightCm)
        {
            return new PackageSize
            {
                Items = new NameValueCollection
                {
                    {"length", lengthCm.ToString(CultureInfo.InvariantCulture)},
                    {"width", widthCm.ToString(CultureInfo.InvariantCulture)},
                    {"height", heightCm.ToString(CultureInfo.InvariantCulture)}
                }
            }; 
        }

        public static PackageSize InVolume(int volumeDm3)
        {
            return new PackageSize
            {
                Items = new NameValueCollection
                {
                    {"volume", volumeDm3.ToString(CultureInfo.InvariantCulture)}
                }
            };
        }
    }
}